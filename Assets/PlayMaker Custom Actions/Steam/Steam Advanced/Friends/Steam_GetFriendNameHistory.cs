// (c) Copyright HutongGames, LLC 2010-2018. All rights reserved.
// Made by djaydino -- http://www.jinxtergames.com/ --
/*--- __ECO__ __PLAYMAKER__ __ACTION__ ---*/

using UnityEngine;
using Steamworks;
using System;

namespace HutongGames.PlayMaker.Actions
{
    [ActionCategory("Steamworks.NET - Friends")]
    [Tooltip("Gets the friends name history")]
    public class Steam_GetFriendNameHistory : FsmStateAction
    {
        [RequiredField]
        public FsmString steamID;

        [RequiredField]
        [UIHint(UIHint.Variable)]
        [ArrayEditor(VariableType.String)]
        public FsmArray userNameHistory;

        public FsmEvent noHistory;
        public FsmEvent historyFound;

        public override void Reset()
        {
            userNameHistory = null;
            steamID = null;
        }

        public override void OnEnter()
        {
            ulong ID = ulong.Parse(this.steamID.Value);
            CSteamID IDsteam;
            IDsteam.m_SteamID = ID;
            userNameHistory.Resize(0);
            int index = 1;
            bool done = false;
            while (!done)
            {
                string userName = SteamFriends.GetFriendPersonaNameHistory(IDsteam, index);
                if (userName != "")
                {
                    userNameHistory.Resize(userNameHistory.Length + 1);
                    userNameHistory.Set(userNameHistory.Length - 1, userName);
                    index++;
                }
                else
                {
                    done = true;
                    if (index < 2)
                    {
                        Fsm.Event(noHistory);
                    }
                    else Fsm.Event(historyFound);
                }
            }
            Finish();
        }
    }
}
