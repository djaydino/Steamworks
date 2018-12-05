// (c) Copyright HutongGames, LLC 2010-2018. All rights reserved.
// Made by djaydino -- http://www.jinxtergames.com/ --
/*--- __ECO__ __PLAYMAKER__ __ACTION__ ---*/

using UnityEngine;
using Steamworks;
using System;

namespace HutongGames.PlayMaker.Actions
{
    [ActionCategory("Steam AppList")]
    [Tooltip("returns -1 if no dir was found")]
    public class Steam_GetAppInfo : FsmStateAction
    {
        [RequiredField]
        [Tooltip("The Steam App Id")]
        public FsmInt appID;

        [Tooltip("The Maximum string lenght of the directory")]
        public FsmInt maxDirectoryLenght;

        [Tooltip("The Maximum string lenght of the name")]
        public FsmInt maxNameLenght;

        [ActionSection("Result")]

        [UIHint(UIHint.Variable)]
        public FsmString appName;

        [UIHint(UIHint.Variable)]
        public FsmString appDirectory;

        [UIHint(UIHint.Variable)]
        public FsmInt buildID;



        [Tooltip("send event when directory is not found")]
        public FsmEvent notFound;

        private int found;

        public override void Reset()
        {
            appID = null;
            maxDirectoryLenght = null;
            maxNameLenght = null;
            appName = null;
            appDirectory = null;
            buildID = null;
        }

        public override void OnEnter()
        {
            AppId_t theAppId = (AppId_t)Convert.ToUInt32(appID.Value);
            buildID.Value = SteamAppList.GetAppBuildId(theAppId);

            string directory = "";
            found = SteamAppList.GetAppInstallDir((AppId_t)Convert.ToUInt32(appID.Value),out directory, maxDirectoryLenght.Value);
            if(found != -1)
            {
                appDirectory.Value = directory;
            }
            else
            {
                Fsm.Event(notFound);
            }
            string name = "";
            SteamAppList.GetAppName(theAppId, out name, maxNameLenght.Value);
            if (found != -1)
            {
                appName.Value = name;
            }
            else
            {
                Fsm.Event(notFound);
            }
            Finish();
        }
    }
}
