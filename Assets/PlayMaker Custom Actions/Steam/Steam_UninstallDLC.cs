// (c) Copyright HutongGames, LLC 2010-2018. All rights reserved.
// Made by djaydino -- http://www.jinxtergames.com/ --
/*--- __ECO__ __PLAYMAKER__ __ACTION__ ---*/

using UnityEngine;
using Steamworks;
using System;

namespace HutongGames.PlayMaker.Actions
{
    [ActionCategory("Steamworks.NET - Client")]
    [Tooltip("Uninstall control for optional DLC")]
    public class Steam_UninstallDLC : FsmStateAction

    {

        [RequiredField]
        public FsmInt appID;

        public override void Reset()
        {
            appID = null;
        }

        public override void OnEnter()
        {
           SteamApps.UninstallDLC((AppId_t)(uint)appID.Value);
            Finish();
        }
    }
}
