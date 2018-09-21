// (c) Copyright HutongGames, LLC 2010-2018. All rights reserved.
// Made by djaydino -- http://www.jinxtergames.com/ --
/*--- __ECO__ __PLAYMAKER__ __ACTION__ ---*/

using UnityEngine;
using Steamworks;
using System;

namespace HutongGames.PlayMaker.Actions
{
    [ActionCategory("Steamworks.NET - Friends")]
    [Tooltip("Get the friends SteamLevel")]
    public class Steam_GetFriendSteamLevel : FsmStateAction
    {
        [RequiredField]
        [Tooltip("Friends SteamID")]
        public FsmString steamID;

        [RequiredField]
        [UIHint(UIHint.Variable)]
        public FsmInt steamLevel;

        public override void Reset()
        {
            steamLevel = null;
            steamID = null;
        }

        public override void OnEnter()
        {
            ulong ID = ulong.Parse(this.steamID.Value);
            CSteamID IDsteam;
            IDsteam.m_SteamID = ID;
            steamLevel.Value = (int)SteamFriends.GetFriendSteamLevel(IDsteam);
            Finish();
        }
    }
}
