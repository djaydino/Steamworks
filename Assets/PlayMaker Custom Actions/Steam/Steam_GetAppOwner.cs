// (c) Copyright HutongGames, LLC 2010-2018. All rights reserved.
// Made by djaydino -- http://www.jinxtergames.com/ --
/*--- __ECO__ __PLAYMAKER__ __ACTION__ ---*/

using UnityEngine;
using Steamworks;
using System;

namespace HutongGames.PlayMaker.Actions
{
    [ActionCategory("Steamworks.NET - Client")]
    [Tooltip("returns the SteamID of the original owner. If different from current user, it's borrowed")]
    public class Steam_GetAppOwner : FsmStateAction
    {
        [RequiredField]
        public FsmInt appID;

        [RequiredField]
        [UIHint(UIHint.Variable)]
        public FsmString steamID64;

        public override void Reset()
        {
            steamID64 = null;
        }

        public override void OnEnter()
        {
            steamID64.Value = Convert.ToString(SteamApps.GetAppOwner());
            Finish();
        }
    }
}
