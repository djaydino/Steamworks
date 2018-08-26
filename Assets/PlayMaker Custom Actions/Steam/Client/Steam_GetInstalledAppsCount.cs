// (c) Copyright HutongGames, LLC 2010-2018. All rights reserved.
// Made by djaydino -- http://www.jinxtergames.com/ --
/*--- __ECO__ __PLAYMAKER__ __ACTION__ ---*/

using UnityEngine;
using Steamworks;

namespace HutongGames.PlayMaker.Actions
{
    [ActionCategory("Steamworks.NET - Client")]
    [Tooltip("Checks how many apps the client has installed")]
    public class Steam_GetNumInstalledApps : FsmStateAction
    {
        [RequiredField]
        [UIHint(UIHint.Variable)]
        public FsmInt installedAppsCount;


        private AppId_t appIDuint;
        private string pchName;

        public override void Reset()
        {
            installedAppsCount = null;
        }

        public override void OnEnter()
        {
            installedAppsCount.Value = (int)SteamAppList.GetNumInstalledApps();
            Finish();
        }
    }
}
