// (c) Copyright HutongGames, LLC 2010-2018. All rights reserved.
// Made by djaydino -- http://www.jinxtergames.com/ --
/*--- __ECO__ __PLAYMAKER__ __ACTION__ ---*/

using UnityEngine;
using Steamworks;
using System;

namespace HutongGames.PlayMaker.Actions
{
    [ActionCategory("Steamworks.NET - Friends")]
    [Tooltip("Set a new personal name (display) name.")]
    public class Steam_GetPersonaState : FsmStateAction
    {
        [Tooltip("get the result as a string")]
        [UIHint(UIHint.Variable)]
        public FsmString personalState;

        [Tooltip("get the result as an index 'Away' would be 0 and 'Snooze' would be 7")]
        [UIHint(UIHint.Variable)]
        public FsmInt stateIndex;

        public FsmEvent away;
        public FsmEvent busy;
        public FsmEvent lookingToPlay;
        public FsmEvent LookingToTrade;
        public FsmEvent stateMax;
        public FsmEvent offline;
        public FsmEvent online;
        public FsmEvent snooze;

        public override void Reset()
        {
            personalState = null;
        }

        public override void OnEnter()
        {
            var myState = SteamFriends.GetPersonaState();

            switch(SteamFriends.GetPersonaState())
            {
                case EPersonaState.k_EPersonaStateAway:
                    Fsm.Event(away);
                    if(personalState != null) personalState.Value = "away";
                    if (stateIndex != null) stateIndex.Value = 0;
                    break;
                case EPersonaState.k_EPersonaStateBusy:
                    Fsm.Event(busy);
                    if (personalState != null) personalState.Value = "busy";
                    if (stateIndex != null) stateIndex.Value = 1;
                    break;
                case EPersonaState.k_EPersonaStateLookingToPlay:
                    Fsm.Event(lookingToPlay);
                    if (personalState != null) personalState.Value = "looking To Play";
                    if (stateIndex != null) stateIndex.Value = 2;
                    break;
                case EPersonaState.k_EPersonaStateLookingToTrade:
                    Fsm.Event(LookingToTrade);
                    if (personalState != null) personalState.Value = "Looking To Trade";
                    if (stateIndex != null) stateIndex.Value = 3;
                    break;
                case EPersonaState.k_EPersonaStateMax:
                    Fsm.Event(stateMax);
                    if (personalState != null) personalState.Value = "state Max";
                    if (stateIndex != null) stateIndex.Value = 4;
                    break;
                case EPersonaState.k_EPersonaStateOffline:
                    Fsm.Event(offline);
                    if (personalState != null) personalState.Value = "offline";
                    if (stateIndex != null) stateIndex.Value = 5;
                    break;
                case EPersonaState.k_EPersonaStateOnline:
                    Fsm.Event(online);
                    if (personalState != null) personalState.Value = "online";
                    if (stateIndex != null) stateIndex.Value = 6;
                    break;
                case EPersonaState.k_EPersonaStateSnooze:
                    Fsm.Event(snooze);
                    if (personalState != null) personalState.Value = "snooze";
                    if (stateIndex != null) stateIndex.Value = 7;
                    break;
            }
            Finish();
        }
    }
}
