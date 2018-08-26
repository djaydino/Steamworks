// (c) Copyright HutongGames, LLC 2010-2018. All rights reserved.
// Made by djaydino -- http://www.jinxtergames.com/ --
/*--- __ECO__ __PLAYMAKER__ __ACTION__ ---*/

using UnityEngine;
using Steamworks;
using System;

namespace HutongGames.PlayMaker.Actions
{
    [ActionCategory("Steamworks.NET - Client")]
    [Tooltip("install control for optional DLC")]
    public class Steam_InstallDLC : FsmStateAction
    {
        [RequiredField]
        public FsmInt appID;


        [UIHint(UIHint.Variable)]
        [Tooltip("Returns the dowload progress in presentage")]
        public FsmInt progress;

        public FsmEvent complete;

        private ulong punBytesDownloaded;
        private ulong punBytesTotal;


        public override void Reset()
        {
            appID = null;
            progress = null;
            complete = null;

        }

        public override void OnEnter()
        {
           SteamApps.InstallDLC((AppId_t)(uint)appID.Value);
            Finish();
        }

        public override void OnUpdate()
        {
            SteamApps.GetDlcDownloadProgress(((AppId_t)(uint)appID.Value), out punBytesDownloaded, out punBytesTotal);
            progress.Value = Convert.ToInt32(punBytesDownloaded / punBytesTotal) * 100;
            if(progress.Value == 100)
            {
                Fsm.Event(complete);
                Finish();
            }
        }
    }
}
