// (c) Copyright HutongGames, LLC 2010-2018. All rights reserved.
// Made by djaydino -- http://www.jinxtergames.com/ --
/*--- __ECO__ __PLAYMAKER__ __ACTION__ ---*/

using UnityEngine;
using Steamworks;
using System;

namespace HutongGames.PlayMaker.Actions
{
    [ActionCategory("Steamworks.NET - Friends")]
    [Tooltip("Get friend relationship info")]
    public class Steam_GetFriendRelationship : FsmStateAction
    {
        [RequiredField]
        public FsmString steamID;

        [Tooltip("Friend relationship")]
        [UIHint(UIHint.Variable)]
        public FsmString friendRelationship;

        [Tooltip("get the result as an index 'none' would be 0 and 'max' would be 7")]
        [UIHint(UIHint.Variable)]
        public FsmInt index;

        public FsmEvent none;
        public FsmEvent blocked;
        public FsmEvent requestRecipient;
        public FsmEvent friend;
        public FsmEvent requestInitiator;
        public FsmEvent ignored;
        public FsmEvent ignoredFriend;
        public FsmEvent Suggested_DEPRECATED;
        public FsmEvent max;


        public override void Reset()
        {
            steamID = null;
            friendRelationship = null;
        }

        public override void OnEnter()
        {
            ulong ID = ulong.Parse(this.steamID.Value);
            CSteamID steamID;
            steamID.m_SteamID = ID;
            switch (SteamFriends.GetFriendRelationship(steamID))
            {
                case EFriendRelationship.k_EFriendRelationshipNone:
                    Fsm.Event(none);
                    if (friendRelationship != null) friendRelationship.Value = "None";
                    if (index != null) index.Value = 0;
                    break;
                case EFriendRelationship.k_EFriendRelationshipBlocked:
                    Fsm.Event(blocked);
                    if (friendRelationship != null) friendRelationship.Value = "Blocked";
                    if (index != null) index.Value = 1;
                    break;
                case EFriendRelationship.k_EFriendRelationshipRequestRecipient:
                    Fsm.Event(requestRecipient);
                    if (friendRelationship != null) friendRelationship.Value = "Request Recipient";
                    if (index != null) index.Value = 2;
                    break;
                case EFriendRelationship.k_EFriendRelationshipFriend:
                    Fsm.Event(friend);
                    if (friendRelationship != null) friendRelationship.Value = "Friend";
                    if (index != null) index.Value = 3;
                    break;
                case EFriendRelationship.k_EFriendRelationshipRequestInitiator:
                    Fsm.Event(requestInitiator);
                    if (friendRelationship != null) friendRelationship.Value = "Request Initiator";
                    if (index != null) index.Value = 4;
                    break;
                case EFriendRelationship.k_EFriendRelationshipIgnored:
                    Fsm.Event(ignored);
                    if (friendRelationship != null) friendRelationship.Value = "Ignored";
                    if (index != null) index.Value = 5;
                    break;
                case EFriendRelationship.k_EFriendRelationshipIgnoredFriend:
                    Fsm.Event(ignoredFriend);
                    if (friendRelationship != null) friendRelationship.Value = "Ignored Friend";
                    if (index != null) index.Value = 6;
                    break;
                case EFriendRelationship.k_EFriendRelationshipSuggested_DEPRECATED:
                    Fsm.Event(Suggested_DEPRECATED);
                    if (friendRelationship != null) friendRelationship.Value = "Suggested";
                    if (index != null) index.Value = 7;
                    break;
                case EFriendRelationship.k_EFriendRelationshipMax:
                    Fsm.Event(max);
                    if (friendRelationship != null) friendRelationship.Value = "Max";
                    if (index != null) index.Value = 8;
                    break;
            }
            Finish();
        }
    }
}
