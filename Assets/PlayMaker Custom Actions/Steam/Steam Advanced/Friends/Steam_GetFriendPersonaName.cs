// (c) Copyright HutongGames, LLC 2010-2018. All rights reserved.
// Made by djaydino -- http://www.jinxtergames.com/ --
/*--- __ECO__ __PLAYMAKER__ __ACTION__ ---*/

using UnityEngine;
using Steamworks;
using System;

namespace HutongGames.PlayMaker.Actions
{
    [ActionCategory("Steamworks.NET - Friends")]
    [Tooltip("Gets the friends persona (display) name.")]
    public class Steam_GetFriendPersonaName : FsmStateAction
    {
        [RequiredField]
        [Tooltip("Friends SteamID")]
        public FsmString steamID;

        [RequiredField]
        [UIHint(UIHint.Variable)]
        public FsmString userName;

        public FsmEvent success;

        public FsmEvent failed;

        private int statInt;

        public override void Reset()
        {
            userName = null;
            steamID = null;
        }

        public override void OnEnter()
        {
            ulong ID = ulong.Parse(this.steamID.Value);
            CSteamID IDsteam;
            IDsteam.m_SteamID = ID;
            userName.Value = (string)SteamFriends.GetFriendPersonaName(IDsteam);
            Finish();
        }
    }
}
