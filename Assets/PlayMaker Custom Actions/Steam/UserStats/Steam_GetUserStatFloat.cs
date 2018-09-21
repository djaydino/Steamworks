// (c) Copyright HutongGames, LLC 2010-2018. All rights reserved.
// Made by djaydino -- http://www.jinxtergames.com/ --
/*--- __ECO__ __PLAYMAKER__ __ACTION__ ---*/

using UnityEngine;
using Steamworks;
using System;

namespace HutongGames.PlayMaker.Actions
{
    [ActionCategory("Steamworks.NET - UserStats")]
    [Tooltip("request User float stats")]
    public class Steam_GetUserStatFloat : FsmStateAction
    {
        [RequiredField]
        public FsmString userID;

        [RequiredField]
        public FsmString statAPIname;

        [UIHint(UIHint.Variable)]
        public FsmFloat floatData;

        public FsmEvent success;

        public FsmEvent failed;

        private float statFloat;

        public override void Reset()
        {
            statAPIname = null;
            floatData = null;
            userID = null;
        }

        public override void OnEnter()
        {
            ulong ID = ulong.Parse(userID.Value);
            CSteamID steamID = SteamUser.GetSteamID();
            steamID.m_SteamID = ID;
            SteamUserStats.RequestUserStats(steamID);
            bool isSucces = SteamUserStats.GetUserStat(steamID, (string)statAPIname.Value, out statFloat);
            if (isSucces)
            {
                floatData.Value = statFloat;
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
