// (c) Copyright HutongGames, LLC 2010-2018. All rights reserved.
// Made by djaydino -- http://www.jinxtergames.com/ --
/*--- __ECO__ __PLAYMAKER__ __ACTION__ ---*/

using UnityEngine;
using System.Collections;
using Steamworks;

namespace HutongGames.PlayMaker.Actions
{
    [ActionCategory("Steamworks.NET - Client")]
    [Tooltip("Test if client has a live connection to the Steam servers.\r\nFalse means there is no active connection due to either a networking issue on the local machine, or the Steam server is down/busy.")]
    public class Steam_IsSteamRunning : FsmStateAction
    {
        [UIHint(UIHint.Variable)]
        public FsmBool isRunning;

        public FsmEvent running;

        public FsmEvent notRunning;

        public override void Reset()
        {
            isRunning = null;
            running = null;
            notRunning = null;
        }

        public override void OnEnter()
        {
            isRunning.Value = SteamAPI.IsSteamRunning();
            if (isRunning.Value)
            {
                Fsm.Event(running);
            }
            else
            {
                Fsm.Event(notRunning);
            }

        }
    }
}