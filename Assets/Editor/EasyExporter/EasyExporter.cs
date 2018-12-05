using UnityEngine;
using UnityEditor;
using System.Collections;
using System.IO;
using System.Collections.Generic;

namespace JinxterGames.EditorUtilities.EasyExporter
{

    [CustomEditor(typeof(PackageList))]
    public class EasyExporter : Editor
    {
        PackageList pl;
        private string folderToAddGUID;
        private string folderToAdd;
        private string fileToAdd;
        public string op;
        private List<string> includeFileList = new List<string>();
        private string packageType;
        private string get_targetDirectory;
        private Texture folderImage;
        private Texture logo;
        private bool overwriteWaring;
        private string addItemPath;

        private string displayIncludeFolderList;
        private string displayIncludeFileList;
        private string displayExcludeFolderList;
        private string displayExcludeFileList;
        private string displayList;
        private string guidID;
        private string foldertypeName;
        private string fileToAddGUID;

        private void OnEnable()
        {

            pl = (PackageList)target;
            folderImage = (Texture)AssetDatabase.LoadAssetAtPath("Assets/Editor/EasyExporter/Images/folderIcon.png", typeof(Texture));
            logo = (Texture)AssetDatabase.LoadAssetAtPath("Assets/Editor/EasyExporter/Images/logo.png", typeof(Texture));
        }

        #region Inspector
        public override void OnInspectorGUI()
        {
            EditorGUI.BeginChangeCheck();
            GUILayout.BeginVertical();
            GUILayout.BeginHorizontal();
            GUILayout.FlexibleSpace();
            if (GUILayout.Button(logo, "Label", GUILayout.Height(66), GUILayout.Width(250)))
            {
                Application.OpenURL("http://www.jinxtergames.com/");
            }
            GUILayout.FlexibleSpace();
            GUILayout.EndHorizontal();
            GUILayout.EndVertical();

            #region Top Button
            GUILayout.BeginVertical("box");
            GUILayout.Space(5);
            GUILayout.BeginHorizontal();
            GUI.color = Color.yellow;
            if (GUILayout.Button("Create Package", GUILayout.Height(30)))
            {
                CreatePackage();
                GUIUtility.ExitGUI();
            }
            GUI.color = new Color(1, 1, 1, 1);
            GUILayout.EndHorizontal();
            GUILayout.BeginHorizontal();
            GUILayout.Label("Check if file exist", GUILayout.Width(110));
            pl.fileExistsCheck = EditorGUILayout.Toggle(pl.fileExistsCheck, GUILayout.Width(15));
            GUILayout.FlexibleSpace();
            GUILayout.EndHorizontal();


            GUILayout.EndVertical();

            #endregion

            #region Target and Package Type
            // Set Package Name
            GUILayout.BeginVertical("box");
            GUILayout.BeginHorizontal();
            GUILayout.Label("Package Name", GUILayout.Width(120));
            pl.packageName = EditorGUILayout.TextField(pl.packageName, GUILayout.MinWidth(5));
            GUILayout.EndHorizontal();

            GUILayout.Space(3);
            // Target Directory
            GUILayout.BeginHorizontal();
            GUILayout.Label("Target Directory", GUILayout.Width(120));
            pl.targetDirectory = EditorGUILayout.TextField(pl.targetDirectory, GUILayout.MinWidth(1));
            if (GUILayout.Button(folderImage, GUILayout.Height(16), GUILayout.Width(24)))
            {
                OnSetTargetDirectory();
            }
            GUILayout.EndHorizontal();
            GUILayout.Space(3);
            GUILayout.EndVertical();


            #endregion

            #region Set Folders And Files
            GUILayout.BeginVertical("box");
            GUILayout.BeginHorizontal();
            GUILayout.FlexibleSpace();
            EditorGUILayout.LabelField("Set Folders And Files", EditorStyles.boldLabel);
            GUILayout.FlexibleSpace();
            GUILayout.EndHorizontal();
            // include dropbox

            GUILayout.BeginHorizontal();
            GUILayout.Space(5);
            InCludeDropAreaGUI();
            GUILayout.Space(5);
            ExCludeDropAreaGUI();
            GUILayout.Space(5);
            GUILayout.EndHorizontal();
            GUILayout.Space(5);
            GUILayout.EndVertical();


            #endregion

            #region FileList
            GUILayout.BeginVertical("box");
            GUILayout.Space(5);
            GUILayout.BeginHorizontal();
            GUILayout.FlexibleSpace();
            GUILayout.Label("File / Folder List", EditorStyles.boldLabel);
            GUILayout.FlexibleSpace();
            if (GUILayout.Button(displayList, GUILayout.Width(50)))
            {
                pl.showList = !pl.showList;
            }
            GUILayout.EndHorizontal();
            GUILayout.Space(5);


            if (pl.showList)
            {
                displayList = "Hide";
                GUILayout.BeginVertical("box");

                // Include Folder List
                GUILayout.Space(5);
                GUILayout.BeginHorizontal();
                GUILayout.FlexibleSpace();
                GUILayout.Label("Included Folder List", EditorStyles.boldLabel);
                GUILayout.FlexibleSpace();
                if (GUILayout.Button(displayIncludeFolderList, GUILayout.Width(50)))
                {
                    pl.showIncludeFolderList = !pl.showIncludeFolderList;
                }
                GUILayout.EndHorizontal();

                if (pl.showIncludeFolderList)
                {
                    displayIncludeFolderList = "Hide";

                    if (pl.includeFoldersGUID.Count > 0)
                    {
                        GUILayout.BeginVertical("box");
                        GUILayout.Space(5);
                        GUI.color = Color.green;
                        for (int CountA = 0; CountA < pl.includeFoldersGUID.Count; CountA++)
                        {
                            GUILayout.BeginHorizontal("box");
                            string assetPath = AssetDatabase.GUIDToAssetPath(pl.includeFoldersGUID[CountA]);
                            if (!AssetDatabase.IsValidFolder(assetPath))
                            {
                             
                                assetPath = "FOLDER NOT FOUND !!!";
                            }
                            if (GUILayout.Button(assetPath, "label", GUILayout.MaxWidth(200), GUILayout.ExpandWidth(true)))
                            {

                                HighlightIncludeFolder(CountA);
                                return;
                            }

                            GUI.color = new Color(1, 1, 1, 1);
                            if (GUILayout.Button("X", GUILayout.Width(16), GUILayout.Height(15)))
                            {
                                RemoveIncludeFolder(CountA);
                                return;
                            }
                            GUI.color = Color.green;
                            GUILayout.EndHorizontal();
                        }
                        GUI.color = new Color(1, 1, 1, 1);
                        GUILayout.Space(5);
                        GUILayout.EndVertical();
                    }
                    else
                    {
                        GUILayout.BeginHorizontal("box");
                        GUILayout.FlexibleSpace();
                        GUILayout.Label("No Folders included");
                        GUILayout.FlexibleSpace();
                        GUILayout.EndHorizontal();
                    }
                }
                else
                {
                    displayIncludeFolderList = "Show";
                }
                GUILayout.Space(5);
                GUILayout.EndVertical();

                // Include File List
                GUILayout.BeginVertical("box");
                GUILayout.Space(5);
                GUILayout.BeginHorizontal();
                GUILayout.FlexibleSpace();
                GUILayout.Label("Included File List", EditorStyles.boldLabel);
                GUILayout.FlexibleSpace();
                if (GUILayout.Button(displayIncludeFileList, GUILayout.Width(50)))
                {
                    pl.showIncludeFileList = !pl.showIncludeFileList;
                }
                GUILayout.EndHorizontal();
                if (pl.showIncludeFileList)
                {
                    displayIncludeFileList = "Hide";

                    if (pl.includeFilesGUID.Count > 0)
                    {
                        GUILayout.BeginVertical("box");
                        GUILayout.Space(5);
                        GUI.color = Color.green;
                        for (int CountA = 0; CountA < pl.includeFilesGUID.Count; CountA++)
                        {
                            GUILayout.BeginHorizontal("box");
                            string assetPath = AssetDatabase.GUIDToAssetPath(pl.includeFilesGUID[CountA]);
                      
                            if (!File.Exists(assetPath))
                            {
                        
                                assetPath = "FILE NOT FOUND !!!";
                            }
                            if (GUILayout.Button(assetPath, "label", GUILayout.MinWidth(200), GUILayout.ExpandWidth(true)))
                            {
                                HighlightIncludeFile(CountA);
                                return;
                            }
                            GUI.color = new Color(1, 1, 1, 1);

                            if (GUILayout.Button("X", GUILayout.Width(16), GUILayout.Height(15)))
                            {
                                RemoveIncludeFile(CountA);
                                return;
                            }
                            GUI.color = Color.green;
                            GUILayout.EndHorizontal();
                        }
                        GUI.color = new Color(1, 1, 1, 1);
                        GUILayout.Space(5);
                        GUILayout.EndVertical();
                    }
                    else
                    {
                        GUILayout.BeginHorizontal("box");
                        GUILayout.FlexibleSpace();
                        GUILayout.Label("No Files included");
                        GUILayout.FlexibleSpace();
                        GUILayout.EndHorizontal();
                    }
                }
                else
                {
                    displayIncludeFileList = "Show";
                }
                GUILayout.Space(5);

                GUILayout.EndVertical();
                // Exclude folder List
                GUILayout.BeginVertical("box");
                GUILayout.Space(5);
                GUILayout.BeginHorizontal();
                GUILayout.FlexibleSpace();
                GUILayout.Label("Excluded Folder List", EditorStyles.boldLabel);
                GUILayout.FlexibleSpace();
                if (GUILayout.Button(displayExcludeFolderList, GUILayout.Width(50)))
                {
                    pl.showExcludeFolderList = !pl.showExcludeFolderList;
                }
                GUILayout.EndHorizontal();
                if (pl.showExcludeFolderList)
                {
                    displayExcludeFolderList = "Hide";
                    if (pl.excludeFoldersGUID.Count > 0)
                    {
                        GUILayout.BeginVertical("box");
                        GUILayout.Space(5);
                        GUI.color = Color.red;
                        for (int CountA = 0; CountA < pl.excludeFoldersGUID.Count; CountA++)
                        {
                            GUILayout.BeginHorizontal("box");
                            string assetPath = AssetDatabase.GUIDToAssetPath(pl.excludeFoldersGUID[CountA]);
                            if (!AssetDatabase.IsValidFolder(assetPath))
                            {
                      
                                assetPath = "FOLDER NOT FOUND !!!";
                            }
                            if (GUILayout.Button(assetPath, "label", GUILayout.MinWidth(200), GUILayout.ExpandWidth(true)))
                            {
                                HighlightExcludeFolder(CountA);
                                return;
                            }
                            GUI.color = new Color(1, 1, 1, 1);
                            if (GUILayout.Button("X", GUILayout.Width(16), GUILayout.Height(15)))
                            {
                                RemoveExcludeFolder(CountA);
                                return;
                            }
                            GUI.color = Color.red;
                            GUILayout.EndHorizontal();
                        }
                        GUI.color = new Color(1, 1, 1, 1);
                        GUILayout.Space(5);
                        GUILayout.EndVertical();
                    }
                    else
                    {
                        GUILayout.BeginHorizontal("box");
                        GUILayout.FlexibleSpace();
                        GUILayout.Label("No Folders included");
                        GUILayout.FlexibleSpace();
                        GUILayout.EndHorizontal();
                    }
                }
                else
                {
                    displayExcludeFolderList = "Show";
                }
                GUILayout.Space(5);
                GUILayout.EndVertical();
                // Exclude File List
                GUILayout.BeginVertical("box");
                GUILayout.Space(5);
                GUILayout.BeginHorizontal();
                GUILayout.FlexibleSpace();
                GUILayout.Label("Excluded File List", EditorStyles.boldLabel);
                GUILayout.FlexibleSpace();
                if (GUILayout.Button(displayExcludeFileList, GUILayout.Width(50)))
                {
                    pl.showExcludeFileList = !pl.showExcludeFileList;
                }
                GUILayout.EndHorizontal();
                if (pl.showExcludeFileList)
                {
                    displayExcludeFileList = "Hide";

                    if (pl.excludeFilesGUID.Count > 0)
                    {
                        GUILayout.BeginVertical("box");
                        GUILayout.Space(5);
                        GUI.color = Color.red;
                        for (int CountA = 0; CountA < pl.excludeFilesGUID.Count; CountA++)
                        {
                            GUILayout.BeginHorizontal("box");
                            string assetPath = AssetDatabase.GUIDToAssetPath(pl.excludeFilesGUID[CountA]);
                            if (!File.Exists(assetPath))
                            {
                         
                                assetPath = "FILE NOT FOUND !!!";
                            }
                            if (GUILayout.Button(assetPath, "label", GUILayout.MinWidth(200), GUILayout.ExpandWidth(true)))
                            {
                                HighlightExcludeFile(CountA);
                                return;
                            }
                            GUI.color = new Color(1, 1, 1, 1);
                            if (GUILayout.Button("X", GUILayout.Width(16), GUILayout.Height(15)))
                            {
                                RemoveExcludeFile(CountA);
                                return;
                            }
                            GUI.color = Color.red;
                            GUILayout.EndHorizontal();
                        }
                        GUI.color = new Color(1, 1, 1, 1);
                        GUILayout.Space(5);
                        GUILayout.EndVertical();
                    }
                    else
                    {
                        GUILayout.BeginHorizontal("box");
                        GUILayout.FlexibleSpace();
                        GUILayout.Label("No Files included");
                        GUILayout.FlexibleSpace();
                        GUILayout.EndHorizontal();
                    }
                }
                else
                {
                    displayExcludeFileList = "Show";
                }
                GUILayout.Space(5);
                GUILayout.EndVertical();
                GUILayout.Space(5);
            }
            else
            {
                displayList = "Show";
            }
            GUILayout.EndVertical();
            #endregion

            if (EditorGUI.EndChangeCheck())
            {
                EditorUtility.SetDirty(pl);
                Repaint();
            }
        }
        #endregion

        #region dropbox
        // TEST DROPBOX
        public void InCludeDropAreaGUI()
        {
            Event evt = Event.current;
            Rect drop_area = GUILayoutUtility.GetRect(0.0f, 60.0f, GUILayout.MinWidth(110), GUILayout.ExpandWidth(true));
            GUI.color = Color.green;
            GUI.Box(drop_area, "Drop you files and folders that you wish to include\nhere");
            GUI.color = new Color(1, 1, 1, 1);
            GUILayout.Space(5);



            //  
            //  GUILayout.Box("\nDrop you files\n and folders in here", GUILayout.Height(60), GUILayout.ExpandWidth(true));
            //   GUILayout.EndHorizontal();

            switch (evt.type)
            {
                case EventType.DragUpdated:
                case EventType.DragPerform:
                    if (!drop_area.Contains(evt.mousePosition))
                        return;

                    DragAndDrop.visualMode = DragAndDropVisualMode.Copy;

                    if (evt.type == EventType.DragPerform)
                    {
                        DragAndDrop.AcceptDrag();
                        foreach (Object dragged_object in DragAndDrop.objectReferences)
                        {
                            addItemPath = AssetDatabase.GetAssetPath(dragged_object);

                            if (AssetDatabase.IsValidFolder(addItemPath))
                            {
                                pl.foldersToInclude.Add(addItemPath);
                            }
                            else if (File.Exists(addItemPath))
                            {
                                pl.filesToInclude.Add(addItemPath);
                            }
                            else
                            {
                                EditorUtility.DisplayDialog("Invalid File Or Folder", "You dropped invalid files or folders\n\nDrop only files from the Project folder.", "Ok", "");
                            }
                        }
                    }
                    break;
            }
            if (pl.foldersToInclude.Count > 0 && Event.current.type == EventType.Layout)
            {
                IncludeFolder();
            }
            if (pl.filesToInclude.Count > 0 && Event.current.type == EventType.Layout)
            {
                IncludeFile();
            }
        }

        public void ExCludeDropAreaGUI()
        {
            Event evt = Event.current;
            Rect drop_area2 = GUILayoutUtility.GetRect(0.0f, 60.0f, GUILayout.Width(110), GUILayout.ExpandWidth(true));
            GUI.color = Color.red;
            GUI.Box(drop_area2, "Drop you files and folders that you wish to exclude\nhere");
            GUI.color = new Color(1, 1, 1, 1);

            switch (evt.type)
            {
                case EventType.DragUpdated:
                case EventType.DragPerform:
                    if (!drop_area2.Contains(evt.mousePosition))
                        return;

                    DragAndDrop.visualMode = DragAndDropVisualMode.Copy;

                    if (evt.type == EventType.DragPerform)
                    {
                        DragAndDrop.AcceptDrag();
                        foreach (Object dragged_object in DragAndDrop.objectReferences)
                        {

                            if (AssetDatabase.IsValidFolder(AssetDatabase.GetAssetPath(dragged_object)))
                            {
                                addItemPath = AssetDatabase.GetAssetPath(dragged_object);
                                string get_Folder = addItemPath;
                                pl.foldersToExclude.Add(get_Folder);
                            }
                            else
                            {
                                addItemPath = AssetDatabase.GetAssetPath(dragged_object);
                                string get_Folder = addItemPath;
                                pl.filesToExclude.Add(get_Folder);

                            }
                        }
                    }
                    break;
            }
            if (pl.foldersToExclude.Count > 0 && Event.current.type == EventType.Layout)
            {
                ExcludeFolder();
            }
            if (pl.filesToExclude.Count > 0 && Event.current.type == EventType.Layout)
            {
                ExcludeFile();
            }
        }
        // TEST END DROPBOX
        #endregion

        #region Add Strings, Folders, Files

        // Add Include Folder
        private void IncludeFolder()
        {
            for (int i = 0; i < pl.foldersToInclude.Count; i++)
            {
                folderToAddGUID = AssetDatabase.AssetPathToGUID(pl.foldersToInclude[i]);
                folderToAdd = pl.foldersToInclude[i];

                if (pl.includeFoldersGUID.Contains(folderToAddGUID) || pl.excludeFoldersGUID.Contains(folderToAddGUID) || pl.includeFolders.Contains(pl.foldersToInclude[i]))
                {
                    if (pl.includeFoldersGUID.Contains(folderToAddGUID))
                    {
                        EditorUtility.DisplayDialog("Folder Exists", pl.foldersToInclude[i] + "\n\n already included in the Include Folder", "Ok", "");
                    }
                    if (pl.excludeFoldersGUID.Contains(folderToAddGUID))
                    {
                        bool option = EditorUtility.DisplayDialog("Folder Exists", pl.foldersToInclude[i] + "\n\n already included in the Exclude Folders\n\nDo you want to remove from the Exclude Folders and add here?", "Yes", "No");
                        if (option)
                        {
                            pl.excludeFoldersGUID.Remove(folderToAddGUID);
                            pl.includeFoldersGUID.Add(folderToAddGUID);
                            pl.excludeFolders.Remove(folderToAdd);
                            pl.includeFolders.Add(folderToAdd);

                        }
                    }
                }
                else
                {
                    pl.includeFoldersGUID.Add(folderToAddGUID);
                    pl.includeFolders.Add(folderToAdd);
                }

            }
            EditorUtility.SetDirty(pl);
            Repaint();
            pl.foldersToInclude.Clear();
        }
        // Add Include File
        private void IncludeFile()
        {
            for (int i = 0; i < pl.filesToInclude.Count; i++)
            {
                fileToAddGUID = AssetDatabase.AssetPathToGUID(pl.filesToInclude[i]);
                fileToAdd = pl.filesToInclude[i];


                if (pl.includeFilesGUID.Contains(fileToAddGUID))
                {
                    EditorUtility.DisplayDialog("File Exists", pl.filesToInclude[i] + "\n\n already included in the Include Files", "Ok", "");
                }
                else if (pl.excludeFilesGUID.Contains(fileToAddGUID))
                {
                    bool option = EditorUtility.DisplayDialog("File Exists", pl.filesToInclude[i] + "\n\n already included in the Exclude files\n\nDo you want to remove from the exclude files and add here?", "Yes", "No");
                    if (option)
                    {
                        pl.excludeFilesGUID.Remove(fileToAddGUID);
                        pl.includeFilesGUID.Add(fileToAddGUID);
                        pl.excludeFiles.Remove(fileToAdd);
                        pl.includeFiles.Add(fileToAdd);
                    }
                }
                else
                {
                    pl.includeFilesGUID.Add(fileToAddGUID);
                    pl.includeFiles.Add(fileToAdd);
                }
            }
            EditorUtility.SetDirty(pl);
            Repaint();
            pl.filesToInclude.Clear();
        }
        // Add Exclude Folder
        private void ExcludeFolder()
        {
            for (int i = 0; i < pl.foldersToExclude.Count; i++)
            {
                folderToAddGUID = AssetDatabase.AssetPathToGUID(pl.foldersToExclude[i]);
                folderToAdd = pl.foldersToExclude[i];

                if (pl.excludeFoldersGUID.Contains(folderToAddGUID))
                {
                    EditorUtility.DisplayDialog("Folder Exists", pl.foldersToExclude[i] + "\n\n already included in the Include Folders", "Ok", "");
                }
                else if (pl.includeFoldersGUID.Contains(folderToAddGUID))
                {
                    bool option = EditorUtility.DisplayDialog("Folder Exists", pl.foldersToExclude[i] + "\n\n already included in the Include Folders\n\nDo you want to remove from the Include Folder and add here?", "Yes", "No");
                    if (option)
                    {
                        pl.includeFoldersGUID.Remove(folderToAddGUID);
                        pl.excludeFoldersGUID.Add(folderToAddGUID);
                        pl.includeFolders.Remove(folderToAdd);
                        pl.excludeFolders.Add(folderToAdd);
                    }
                }
                else
                {
                    pl.excludeFoldersGUID.Add(folderToAddGUID);
                    pl.excludeFolders.Add(folderToAdd);
                }

            }
            EditorUtility.SetDirty(pl);
            Repaint();
            pl.foldersToExclude.Clear();
        }
        // Add Exclude File
        private void ExcludeFile()
        {
            for (int i = 0; i < pl.filesToExclude.Count; i++)
            {
                fileToAddGUID = AssetDatabase.AssetPathToGUID(pl.filesToExclude[i]);
                fileToAdd = pl.filesToExclude[i];

                if (pl.excludeFilesGUID.Contains(fileToAddGUID))
                {
                    EditorUtility.DisplayDialog("File Exists", pl.filesToExclude[i] + "\n\n already included in the Exclude files", "Ok", "");
                }
                else if (pl.includeFilesGUID.Contains(fileToAddGUID))
                {
                    bool option = EditorUtility.DisplayDialog("File Exists", pl.filesToExclude[i] + "\n\n already included in the Include files\n\nDo you want to remove from the Include files and add here?", "Yes", "No");
                    if (option)
                    {
                        pl.includeFilesGUID.Remove(fileToAddGUID);
                        pl.excludeFilesGUID.Add(fileToAddGUID);
                        pl.includeFiles.Remove(fileToAdd);
                        pl.excludeFiles.Add(fileToAdd);
                    }
                }
                else
                {
                    pl.excludeFilesGUID.Add(fileToAddGUID);
                    pl.excludeFiles.Add(fileToAdd);
                }

            }
            EditorUtility.SetDirty(pl);
            Repaint();
            pl.filesToExclude.Clear();
        }
        #endregion

        #region Highlight Folders

        // Highlight Include Folder
        private void HighlightIncludeFolder(int index)
        {
            string path = AssetDatabase.GUIDToAssetPath(pl.includeFoldersGUID[index]);

            if (AssetDatabase.IsValidFolder(path))
            {
                EditorGUIUtility.PingObject(AssetDatabase.LoadAssetAtPath(path, typeof(Object)));
            }
            else if (AssetDatabase.IsValidFolder(pl.includeFolders[index]))
            {
                pl.includeFoldersGUID[index] = AssetDatabase.AssetPathToGUID(pl.includeFolders[index]);
            }
            else
            {
                displayNotFound(1, index, pl.includeFolders[index]);
            }
        }
        // Highlight Exclude Folder
        private void HighlightExcludeFolder(int index)
        {
            string path = AssetDatabase.GUIDToAssetPath(pl.excludeFoldersGUID[index]);
            if (AssetDatabase.IsValidFolder(path))
            {
                EditorGUIUtility.PingObject(AssetDatabase.LoadAssetAtPath(path, typeof(Object)));
            }
            else if (AssetDatabase.IsValidFolder(pl.excludeFolders[index]))
            {
                pl.excludeFoldersGUID[index] = AssetDatabase.AssetPathToGUID(pl.excludeFolders[index]);
            }
            else
            {
                displayNotFound(2, index, pl.excludeFolders[index]);
            }
        }
        // Highlight Include File
        private void HighlightIncludeFile(int index)
        {
            string path = AssetDatabase.GUIDToAssetPath(pl.includeFilesGUID[index]);
            if (File.Exists(path))
            {
                EditorGUIUtility.PingObject(AssetDatabase.LoadAssetAtPath(path, typeof(Object)));
            }
            else if (File.Exists(pl.includeFiles[index]))
            {
                pl.includeFilesGUID[index] = AssetDatabase.AssetPathToGUID(pl.includeFiles[index]);
            }
            else
            {
                displayNotFound(3, index, pl.includeFiles[index]);
            }

        }
        // Highlight Exclude File
        private void HighlightExcludeFile(int index)
        {
            string path = AssetDatabase.GUIDToAssetPath(pl.excludeFilesGUID[index]);
            if (File.Exists(path))
            {
                EditorGUIUtility.PingObject(AssetDatabase.LoadAssetAtPath(path, typeof(Object)));
            }
            else if (File.Exists(pl.excludeFiles[index]))
            {
                pl.excludeFilesGUID[index] = AssetDatabase.AssetPathToGUID(pl.excludeFiles[index]);
            }
            else
            {
                displayNotFound(4, index, pl.excludeFiles[index]);
            }
        }
        #endregion

        #region not found
        private void displayNotFound(int folderType, int index, string path)
        {
    
            if (folderType == 1 || folderType == 2)
            {
                foldertypeName = "Folder";
            }
            else
            {
                foldertypeName = "File";
            }
            string displayTitle = foldertypeName + " Not Found";
            string displayText = "the " + foldertypeName + ": " + path + " Is not found.\n\n Do you wish to remove from the list ?";
            bool option = EditorUtility.DisplayDialog(displayTitle, displayText, "Yes", "No");
            if (option)
            {
                switch (folderType)
                {
                    case 1:
                        RemoveIncludeFolder(index);
                        break;
                    case 2:
                        RemoveExcludeFolder(index);
                        break;
                    case 3:
                        RemoveIncludeFile(index);
                        break;
                    case 4:
                        RemoveExcludeFile(index);
                        break;
                }
            }



        }
        #endregion

        #region Remove Strings, Folders, Files

        // Remove Include Folder
        private void RemoveIncludeFolder(int index)
        {
            pl.includeFoldersGUID.RemoveAt(index);
            pl.includeFolders.RemoveAt(index);
            EditorUtility.SetDirty(pl);
            Repaint();
        }
        // Remove Exclude Folder
        private void RemoveExcludeFolder(int index)
        {
            pl.excludeFoldersGUID.RemoveAt(index);
            pl.excludeFolders.RemoveAt(index);
            EditorUtility.SetDirty(pl);
            Repaint();
        }
        // Remove Include File
        private void RemoveIncludeFile(int index)
        {
            pl.includeFilesGUID.RemoveAt(index);
            pl.includeFiles.RemoveAt(index);
            EditorUtility.SetDirty(pl);
            Repaint();
        }
        // Remove Exclude File
        private void RemoveExcludeFile(int index)
        {
            pl.excludeFilesGUID.RemoveAt(index);
            pl.excludeFiles.RemoveAt(index);
            EditorUtility.SetDirty(pl);
            Repaint();
        }
        #endregion

        #region BuildPackage
        // Set Target Directory
        private void OnSetTargetDirectory()
        {
            get_targetDirectory = EditorUtility.OpenFolderPanel(Application.dataPath, "", "*.*");
            pl.targetDirectory = get_targetDirectory;

            EditorUtility.SetDirty(pl);
            Repaint();
        }

        // Create the package
        public void CreatePackage()
        {
            if (pl.packageName == "" || pl.packageName == null)
            {
                bool option = EditorUtility.DisplayDialog("No Package Name", "You need to include a Package Name", "Ok", "");
                if (option)
                {
                    return;
                }
            }
            else if (pl.targetDirectory == "" || pl.packageName == null || pl.targetDirectory == null)
            {
                bool option = EditorUtility.DisplayDialog("No Target Directory", "You need to set a target directory", "Ok", "");
                if (option)
                {
                    return;
                }
            }
            else
                includeFileList.Clear();
            //Include folders
            for (int count = 0; count < pl.includeFoldersGUID.Count; count++)
            {
                string directoryPath = AssetDatabase.GUIDToAssetPath(pl.includeFoldersGUID[count]);
                if(!AssetDatabase.IsValidFolder(directoryPath))
                {
                    displayNotFound(1, count, directoryPath);
                    return;
                }
                DirectoryInfo dir = new DirectoryInfo(directoryPath);
                FileInfo[] info = dir.GetFiles("*.*", SearchOption.AllDirectories);
                if (info.Length <= 0)
                {

                }


                foreach (FileInfo f in info)
                {
                    string get_File = f.FullName;
                    int index = get_File.IndexOf("Assets");
                    fileToAdd = get_File.Substring(index);
                    fileToAdd = fileToAdd.Replace('\\', '/');

                    includeFileList.Add(fileToAdd);

                }
            }
            //Include files
            for (int count = 0; count < pl.includeFilesGUID.Count; count++)
            {
                string filePathString = AssetDatabase.GUIDToAssetPath(pl.includeFilesGUID[count]);
                if (!File.Exists(filePathString))
                {
                    displayNotFound(1, count, filePathString);
                    return;
                }
                if (!includeFileList.Contains(filePathString))
                {
                    includeFileList.Add(filePathString);
                }
            }
            // Exclude folders
            for (int count = 0; count < pl.excludeFoldersGUID.Count; count++)
            {
                string directoryPath = AssetDatabase.GUIDToAssetPath(pl.excludeFoldersGUID[count]);
                if (!AssetDatabase.IsValidFolder(directoryPath))
                {
                    displayNotFound(1, count, directoryPath);
                    return;
                }
                DirectoryInfo dir = new DirectoryInfo(directoryPath);
                FileInfo[] info = dir.GetFiles("*.*", SearchOption.AllDirectories);
                foreach (FileInfo f in info)
                {
                    string get_Folder = f.FullName;
                    int indexfolder = get_Folder.IndexOf("Assets");
                    fileToAdd = get_Folder.Substring(indexfolder);
                    fileToAdd = fileToAdd.Replace('\\', '/');
                    if (includeFileList.Contains(fileToAdd))
                    {

                        int index = includeFileList.IndexOf(fileToAdd);
                        if (index != -1)
                        {
                            includeFileList.RemoveAt(index);
                        }

                    }

                }
            }
            //Exclude files
            for (int count = 0; count < pl.excludeFilesGUID.Count; count++)
            {
                string filePathString = AssetDatabase.GUIDToAssetPath(pl.excludeFilesGUID[count]);
                if (!File.Exists(filePathString))
                {
                    displayNotFound(1, count, filePathString);
                    return;
                }
                if (includeFileList.Contains(filePathString))
                {
                    int index = includeFileList.IndexOf(filePathString);
                    if (index != -1)
                    {
                        includeFileList.RemoveAt(index);
                    }
                }
            }
            if (includeFileList.Count > 0)
            {

                BuildPackage();
            }
            else
            {
                EditorUtility.DisplayDialog("No Files / Folders to expot", "There are no files to export\nPleace check if there are files / folders\nincluded to include to export", "Ok", "");
                return;
            }

        }


        private void BuildPackage()
        {

            string exportdirectory = pl.targetDirectory + "/" + pl.packageName + ".unitypackage";
            if (!Directory.Exists(pl.targetDirectory))
            {
                Directory.CreateDirectory(pl.targetDirectory);
                EditorUtility.DisplayProgressBar("Exporting", "this might take a while depending on the size of your included files/folders\n Please wait", 10f);
                AssetDatabase.ExportPackage(includeFileList.ToArray(), exportdirectory, ExportPackageOptions.Default);
                EditorUtility.ClearProgressBar();
                EditorUtility.RevealInFinder(exportdirectory);
            }
            else
            {
                if (File.Exists(exportdirectory) && pl.fileExistsCheck == true)
                {

                    int option = EditorUtility.DisplayDialogComplex("This Package Exists already.", "Overwrite package?", "yes", "yes, Don't ask again", "No");
                    switch (option)
                    {
                        case 0:
                            File.Delete(exportdirectory);
                            EditorUtility.DisplayProgressBar("Exporting", "this might take a while depending on the size of your included files/folders\n Please wait", 10f);
                            AssetDatabase.ExportPackage(includeFileList.ToArray(), exportdirectory, ExportPackageOptions.Default);
                            EditorUtility.ClearProgressBar();
                            EditorUtility.RevealInFinder(exportdirectory);
                            break;
                        case 1:
                            pl.fileExistsCheck = false;
                            File.Delete(exportdirectory);
                            EditorUtility.DisplayProgressBar("Exporting", "this might take a while depending on the size of your included files/folders\n Please wait", 10f);
                            AssetDatabase.ExportPackage(includeFileList.ToArray(), exportdirectory, ExportPackageOptions.Default);
                            EditorUtility.ClearProgressBar();
                            EditorUtility.RevealInFinder(exportdirectory);
                            EditorUtility.SetDirty(pl);
                            Repaint();
                            break;
                        case 2:
                            EditorUtility.DisplayDialog("Build Canceled", "I saved your life!", "Thank You", "");
                            break;
                    }
                }
                else
                {
                    if (File.Exists(exportdirectory))
                    {
                        File.Delete(exportdirectory);
                    }

                    EditorUtility.DisplayProgressBar("Exporting", "this might take a while depending on the size of your included files/folders\n Please wait", 10f);
                    AssetDatabase.ExportPackage(includeFileList.ToArray(), exportdirectory, ExportPackageOptions.Default);
                    EditorUtility.ClearProgressBar();
                    EditorUtility.RevealInFinder(exportdirectory);
                }
            }


        }
        #endregion

    }
}
