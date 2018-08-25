// (c) Copyright HutongGames, LLC 2010-2018. All rights reserved.
// Made by djaydino -- http://www.jinxtergames.com/ --
/*--- __ECO__ __PLAYMAKER__ __ACTION__ ---*/

using UnityEngine;
using Steamworks;
using System;

namespace HutongGames.PlayMaker.Actions
{
    [ActionCategory("Steamworks.NET - Friends")]
    [Tooltip("get restrictions from current user")]
    public class Steam_GetUserRestrictions : FsmStateAction
    {
        [Tooltip("if current user is chat restricted, he can't send or receive any text/voice chat messages. the user can't see custom avatars. But the user can be online and send/recv game invites. a chat restricted user can't add friends or join any groups.")]
        [UIHint(UIHint.Variable)]
        public FsmString restriction;

        [Tooltip("get the result as an index 'none' would be 0 and 'trading' would be 7")]
        [UIHint(UIHint.Variable)]
        public FsmInt index;

        public FsmEvent none;
        public FsmEvent unknown;
        public FsmEvent anyChat;
        public FsmEvent voiceChat;
        public FsmEvent groupChat;
        public FsmEvent rating;
        public FsmEvent gameInvites;
        public FsmEvent trading;

        public override void Reset()
        {
            restriction = null;
            index = null;
        }

        public override void OnEnter()
        {
            switch (SteamFriends.GetUserRestrictions())
            {
                case 0:
                    Fsm.Event(none);
                    if (restriction != null) restriction.Value = "None";
                    if (index != null) index.Value = 0;
                    break;
                case 1:
                    Fsm.Event(unknown);
                    if (restriction != null) restriction.Value = "Unknown";
                    if (index != null) index.Value = 1;
                    break;
                case 2:
                    Fsm.Event(anyChat);
                    if (restriction != null) restriction.Value = "Any Chat";
                    if (index != null) index.Value = 2;
                    break;
                case 4:
                    Fsm.Event(voiceChat);
                    if (restriction != null) restriction.Value = "Voice Chat";
                    if (index != null) index.Value = 3;
                    break;
                case 8:
                    Fsm.Event(groupChat);
                    if (restriction != null) restriction.Value = "Group Chat";
                    if (index != null) index.Value = 4;
                    break;
                case 16:
                    Fsm.Event(rating);
                    if (restriction != null) restriction.Value = "Rating";
                    if (index != null) index.Value = 5;
                    break;
                case 32:
                    Fsm.Event(gameInvites);
                    if (restriction != null) restriction.Value = "Game Invites";
                    if (index != null) index.Value = 6;
                    break;
                case 64:
                    Fsm.Event(trading);
                    if (restriction != null) restriction.Value = "Trading";
                    if (index != null) index.Value = 7;
                    break;
            }
            Finish();
        }
    }
}
