// (c) Copyright HutongGames, LLC 2010-2018. All rights reserved.
// Made by djaydino -- http://www.jinxtergames.com/ --
/*--- __ECO__ __PLAYMAKER__ __ACTION__ ---*/
#if !DISABLESTEAMWORKS
using UnityEngine;
using Steamworks;
using System;

namespace HutongGames.PlayMaker.Actions
{
    [ActionCategory("Steamworks.NET - Client")]
    [Tooltip("Allows you to uninstall an optional DLC.")]
    public class Steam_UninstallDLC : FsmStateAction
    {
        [RequiredField]
        public FsmInt dlcAppID;

        public override void Reset()
        {
            dlcAppID = null;
        }

        public override void OnEnter()
        {
           SteamApps.UninstallDLC((AppId_t)(uint)dlcAppID.Value);
            Finish();
        }
    }
}
#endif