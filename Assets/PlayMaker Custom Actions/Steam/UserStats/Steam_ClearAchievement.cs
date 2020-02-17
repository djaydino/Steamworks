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
    [Tooltip("Set Achievement to false (not achieved) WARNING! This is primarily only ever used for testing")]
    public class Steam_ClearAchievement : FsmStateAction
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
            isSuccess.Value = (bool)SteamUserStats.ClearAchievement((string)achievementAPIname.Value);
            if (isSuccess.Value)
            {
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