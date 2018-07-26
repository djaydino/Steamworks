// (c) Copyright HutongGames, LLC 2010-2018. All rights reserved.
// Made by djaydino -- http://www.jinxtergames.com/ --
/*--- __ECO__ __PLAYMAKER__ __ACTION__ ---*/

using UnityEngine;
using Steamworks;
using System;

namespace HutongGames.PlayMaker.Actions
{
    [ActionCategory("Steamworks.NET")]
    [Tooltip("Get´s steam app Build ID.")]
    public class Steam_GetAppBuildID : FsmStateAction
    {
        [RequiredField]
        public FsmInt appID;

        [RequiredField]
        [UIHint(UIHint.Variable)]
        public FsmInt appBuildID;

        public override void Reset()
        {
            appBuildID = null;
            appID = null;
        }

        public override void OnEnter()
        {
            appBuildID.Value = Convert.ToInt32(SteamAppList.GetAppBuildId((AppId_t)Convert.ToUInt32(appID.Value)));
            Finish();
        }
    }
}