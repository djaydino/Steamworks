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
    [Tooltip("Gets Achievement information")]
    public class Steam_GetAchievementInfo : FsmStateAction

    {
        [RequiredField]
        public FsmString statAPIname;

        [UIHint(UIHint.Variable)]
        public FsmString name;

        [UIHint(UIHint.Variable)]
        public FsmString description;

        [UIHint(UIHint.Variable)]
        public FsmBool isAchieved;

        [UIHint(UIHint.Variable)]
        public FsmBool hidden;

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
            name = null;
            description = null;
            isAchieved = null;
            hidden = null;
            unlockTimeUnix = null;
        }

        public override void OnEnter()
        {
            SteamUserStats.GetAchievementAndUnlockTime((string)statAPIname.Value, out pbAchieved, out punUnlockTime);

            name.Value = SteamUserStats.GetAchievementDisplayAttribute((string)statAPIname.Value, "name");
            description.Value = SteamUserStats.GetAchievementDisplayAttribute((string)statAPIname.Value, "desc");
            string isHidden = SteamUserStats.GetAchievementDisplayAttribute((string)statAPIname.Value, "hidden");
            unlockTimeUnix.Value = (int)punUnlockTime;
            isAchieved.Value = pbAchieved;
            if (isHidden == "1")
            {
                hidden.Value = true;
            }
            else
            {
                hidden.Value = false;
            }
            Finish();
        }
    }
}
#endif