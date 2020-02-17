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
    [Tooltip("Set Achievement to true (achieved)")]
    public class Steam_SetAchievement : FsmStateAction
    {
        [RequiredField]
        public FsmString achievementAPIname;

        public FsmBool isSuccess;

        public FsmEvent success;

        public FsmEvent failed;

        public override void Reset()
        {
            achievementAPIname = null;
        }

        public override void OnEnter()
        {
            isSuccess.Value = (bool)SteamUserStats.SetAchievement((string)achievementAPIname.Value);
            if (isSuccess.Value)
            {
                SteamUserStats.StoreStats();
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