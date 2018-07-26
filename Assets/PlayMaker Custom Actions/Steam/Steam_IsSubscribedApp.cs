// (c) Copyright HutongGames, LLC 2010-2018. All rights reserved.
// Made by djaydino -- http://www.jinxtergames.com/ --
/*--- __ECO__ __PLAYMAKER__ __ACTION__ ---*/

using UnityEngine;
using Steamworks;
using System;

namespace HutongGames.PlayMaker.Actions
{
    [ActionCategory("Steamworks.NET - Client")]
    [Tooltip("Check if client owns a certain app")]
    public class Steam_IsSubscribedApp : FsmStateAction

    {

        [RequiredField]
        public FsmInt appID;

        [RequiredField]
        [UIHint(UIHint.Variable)]
        public FsmBool result;

        public override void Reset()
        {
            appID = null;
            result = null;
        }

        public override void OnEnter()
        {
            result.Value = SteamApps.BIsSubscribedApp((AppId_t)(uint)appID.Value);
            Finish();
        }
    }
}
