// (c) Copyright HutongGames, LLC 2010-2018. All rights reserved.
// Made by djaydino -- http://www.jinxtergames.com/ --
/*--- __ECO__ __PLAYMAKER__ __ACTION__ ---*/

using UnityEngine;
using Steamworks;
using System;

namespace HutongGames.PlayMaker.Actions
{
    [ActionCategory("Steamworks.NET - UserStats")]
    [Tooltip("Gets Achievement information")]
    public class Steam_GetUserAchievementInfo : FsmStateAction

    {
        [RequiredField]
        public FsmString userID;

        [RequiredField]
        public FsmString statAPIname;

        [UIHint(UIHint.Variable)]
        public FsmBool isAchieved;

        [UIHint(UIHint.Variable)]
        public FsmInt unlockTimeUnix;



        private bool pbAchieved;
        private uint punUnlockTime;
        private uint achName;
        uint nCurProgress;
        uint nMaxProgress;

        public override void Reset()
        {
            statAPIname = null;
            isAchieved = null;
            unlockTimeUnix = null;

        }

        public override void OnEnter()
        {
            ulong ID = ulong.Parse(userID.Value);
            CSteamID steamID = SteamUser.GetSteamID();
            steamID.m_SteamID = ID;
            SteamUserStats.RequestUserStats(steamID);
            SteamUserStats.GetUserAchievementAndUnlockTime(steamID, (string)statAPIname.Value, out pbAchieved, out punUnlockTime);

            unlockTimeUnix.Value = (int)punUnlockTime;
            isAchieved.Value = pbAchieved;
            Finish();
        }
    }
}
