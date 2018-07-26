// (c) Copyright HutongGames, LLC 2010-2018. All rights reserved.
// Made by djaydino -- http://www.jinxtergames.com/ --
/*--- __ECO__ __PLAYMAKER__ __ACTION__ ---*/

using UnityEngine;
using Steamworks;
using System;

namespace HutongGames.PlayMaker.Actions
{
    [ActionCategory("Steamworks.NET - Client")]
    [Tooltip("returns true if that app is installed (not necessarily owned)")]
    public class Steam_IsAppInstalled : FsmStateAction
    {
        [RequiredField]
        public FsmInt appID;

        [RequiredField]
        [UIHint(UIHint.Variable)]
        public FsmBool result;

        public override void Reset()
        {
            result = null;
        }

        public override void OnEnter()
        {
            result.Value = SteamApps.BIsAppInstalled((AppId_t)Convert.ToUInt32(appID.Value));
            Finish();
        }
    }
}
