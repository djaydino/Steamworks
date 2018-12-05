using System.Collections.Generic;
using UnityEngine;

namespace JinxterGames.EditorUtilities.EasyExporter
{
    [CreateAssetMenu(fileName = "Export Package", menuName = "New Export Package", order = 1)]
    [System.Serializable]
    // Package List
    public class PackageList : ScriptableObject
    {
        [SerializeField]
        public List<string> includeFolders = new List<string>();
        [SerializeField]
        public List<string> excludeFolders = new List<string>();
        [SerializeField]
        public List<string> includeFiles = new List<string>();
        [SerializeField]
        public List<string> excludeFiles = new List<string>();
        [SerializeField]
        public List<string> foldersToInclude = new List<string>();
        [SerializeField]
        public List<string> filesToInclude = new List<string>();
        [SerializeField]
        public List<string> foldersToExclude = new List<string>();
        [SerializeField]
        public List<string> filesToExclude = new List<string>();
        [SerializeField]
        public List<string> includeFoldersGUID = new List<string>();
        [SerializeField]
        public List<string> excludeFoldersGUID = new List<string>();
        [SerializeField]
        public List<string> includeFilesGUID = new List<string>();
        [SerializeField]
        public List<string> excludeFilesGUID = new List<string>();
        [SerializeField]
        public List<string> foldersToIncludeGUID = new List<string>();
        [SerializeField]
        public List<string> filesToIncludeGUID = new List<string>();
        [SerializeField]
        public List<string> foldersToExcludeGUID = new List<string>();
        [SerializeField]
        public List<string> filesToExcludeGUID = new List<string>();
        [SerializeField]
        public string packageName;
        [SerializeField]
        public string targetDirectory;
        [SerializeField]
        public bool fileExistsCheck = true;
        [SerializeField]
        public bool expandedList = false;
        [SerializeField]
        public bool showIncludeFolderList = true;
        [SerializeField]
        public bool showIncludeFileList = true;
        [SerializeField]
        public bool showExcludeFolderList = true;
        [SerializeField]
        public bool showExcludeFileList = true;
        [SerializeField]
        public bool showList = true;

    }
}