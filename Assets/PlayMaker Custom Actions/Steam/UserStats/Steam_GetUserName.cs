// (c) Copyright HutongGames, LLC 2010-2018. All rights reserved.
// Made by djaydino -- http://www.jinxtergames.com/ --
/*--- __ECO__ __PLAYMAKER__ __ACTION__ ---*/
#if !DISABLESTEAMWORKS
using UnityEngine;
using Steamworks;
using System;

namespace HutongGames.PlayMaker.Actions
{
    [ActionCategory("Steamworks.NET - UserStats")]
    [Tooltip("Get user Name")]
    public class Steam_GetUserName : FsmStateAction
    {
        [RequiredField]
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

        }

        public override void OnEnter()
        {
            ulong ID = ulong.Parse(this.steamID.Value);
            CSteamID IdSteam = SteamUser.GetSteamID();
            IdSteam.m_SteamID = ID;
            userName.Value = (string)SteamFriends.GetFriendPersonaName(IdSteam);
            Finish();
        }
    }
}
#endif