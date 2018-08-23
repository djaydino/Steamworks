// (c) Copyright HutongGames, LLC 2010-2018. All rights reserved.
// Made by djaydino -- http://www.jinxtergames.com/ --
/*--- __ECO__ __PLAYMAKER__ __ACTION__ ---*/

using UnityEngine;
using Steamworks;
using System;

namespace HutongGames.PlayMaker.Actions
{
    [ActionCategory("Steamworks.NET - UserStats")]
    [Tooltip("request current stats")]
    public class Steam_RequestCurrentStats : FsmStateAction
    {
        public FsmEvent done;

        public FsmEvent failed;

        public override void OnEnter()
        {
           // UserStatsReceived_t test = RequestIsDone;

                bool currentStat = SteamUserStats.RequestCurrentStats();
                if(currentStat)
                {
                    Fsm.Event(done);
                }
                else
                {
                    Debug.Log("there is no user logged in");
                    Fsm.Event(failed);
                }
                Fsm.Event(failed);
            Finish();
        }
    }
}
