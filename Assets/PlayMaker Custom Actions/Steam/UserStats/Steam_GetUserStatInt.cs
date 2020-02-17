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
    [Tooltip("request User int stats")]
    public class Steam_GetUserStatInt : FsmStateAction
    {
        [RequiredField]
        public FsmString userID;

        [RequiredField]
        public FsmString statAPIname;

        [UIHint(UIHint.Variable)]
        public FsmInt intData;

        public FsmEvent success;

        public FsmEvent failed;

        private int statInt;

        public override void Reset()
        {
            statAPIname = null;
            intData = null;
        }

        public override void OnEnter()
        {
            ulong ID = ulong.Parse(userID.Value);
            CSteamID steamID = SteamUser.GetSteamID();
            steamID.m_SteamID = ID;
            SteamUserStats.RequestUserStats(steamID);
            bool isSucces = SteamUserStats.GetUserStat(steamID, (string)statAPIname.Value, out statInt);
            if (isSucces)
            {
                intData.Value = statInt;
                Fsm.Event(success);
            }
            else
            {
                Fsm.Event(failed);
            }
            Finish();
        }
    }
}
#endif