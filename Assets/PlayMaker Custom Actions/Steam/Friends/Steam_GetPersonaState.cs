// (c) Copyright HutongGames, LLC 2010-2018. All rights reserved.
// Made by djaydino -- http://www.jinxtergames.com/ --
/*--- __ECO__ __PLAYMAKER__ __ACTION__ ---*/
#if !DISABLESTEAMWORKS
using UnityEngine;
using Steamworks;
using System;

namespace HutongGames.PlayMaker.Actions
{
    [ActionCategory("Steamworks.NET - Friends")]
    [Tooltip("Get")]
    public class Steam_GetPersonaState : FsmStateAction
    {
        [Tooltip("Gets the friend status of the current user.")]
        [UIHint(UIHint.Variable)]
        public FsmString personalState;

        [Tooltip("get the result as an index 'Offline' would be 0 and 'Max' would be 7")]
        [UIHint(UIHint.Variable)]
        public FsmInt stateIndex;

        public FsmEvent offline;
        public FsmEvent online;
        public FsmEvent busy;
        public FsmEvent away;
        public FsmEvent snooze;
        public FsmEvent LookingToTrade;
        public FsmEvent lookingToPlay;
        public FsmEvent max;

        public override void Reset()
        {
            personalState = null;
        }

        public override void OnEnter()
        {
            switch (SteamFriends.GetPersonaState())
            {
                case EPersonaState.k_EPersonaStateOffline:
                    Fsm.Event(offline);
                    if (personalState != null) personalState.Value = "Offline";
                    if (stateIndex != null) stateIndex.Value = 0;
                    break;
                case EPersonaState.k_EPersonaStateOnline:
                    Fsm.Event(online);
                    if (personalState != null) personalState.Value = "Online";
                    if (stateIndex != null) stateIndex.Value = 1;
                    break;
                case EPersonaState.k_EPersonaStateBusy:
                    Fsm.Event(busy);
                    if (personalState != null) personalState.Value = "Busy";
                    if (stateIndex != null) stateIndex.Value = 2;
                    break;
                case EPersonaState.k_EPersonaStateAway:
                    Fsm.Event(away);
                    if (personalState != null) personalState.Value = "Away";
                    if (stateIndex != null) stateIndex.Value = 3;
                    break;
                case EPersonaState.k_EPersonaStateSnooze:
                    Fsm.Event(snooze);
                    if (personalState != null) personalState.Value = "Snooze";
                    if (stateIndex != null) stateIndex.Value = 4;
                    break;
                case EPersonaState.k_EPersonaStateLookingToTrade:
                    Fsm.Event(LookingToTrade);
                    if (personalState != null) personalState.Value = "Looking to trade";
                    if (stateIndex != null) stateIndex.Value = 5;
                    break;
                case EPersonaState.k_EPersonaStateLookingToPlay:
                    Fsm.Event(lookingToPlay);
                    if (personalState != null) personalState.Value = "Looking to play";
                    if (stateIndex != null) stateIndex.Value = 6;
                    break;
                case EPersonaState.k_EPersonaStateMax:
                    Fsm.Event(max);
                    if (personalState != null) personalState.Value = "Max";
                    if (stateIndex != null) stateIndex.Value = 7;
                    break;
            }
            Finish();
        }
    }
}
#endif