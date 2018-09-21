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

        [UIHint(UIHint.Variable)]
        public FsmString steamID;

        public FsmEvent isOwner;

        public FsmEvent isBorrowed;

        public override void Reset()
        {
            steamID = null;
        }

        public override void OnEnter()
        {
            CSteamID iD = SteamUser.GetSteamID();
            CSteamID owner = SteamApps.GetAppOwner();
            steamID.Value = Convert.ToString(owner);
            if (iD == owner) Fsm.Event(isOwner);
            else Fsm.Event(isBorrowed);
            Finish();
        }
    }
}
