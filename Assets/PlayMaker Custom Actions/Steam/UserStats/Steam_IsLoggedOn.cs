// (c) Copyright HutongGames, LLC 2010-2018. All rights reserved.
// Made by djaydino -- http://www.jinxtergames.com/ --
/*--- __ECO__ __PLAYMAKER__ __ACTION__ ---*/

using UnityEngine;
using System.Collections;
using Steamworks;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Steamworks.NET - UserStats")]
	[Tooltip("Test if client has a live connection to the Steam servers.\r\nFalse means there is no active connection due to either a networking issue on the local machine, or the Steam server is down/busy.")]
	public class Steam_IsLoggedOn : FsmStateAction
	{
		[UIHint(UIHint.Variable)]
		public FsmBool Connect;

        public FsmEvent connected;

        public FsmEvent notConnected;

        public override void Reset()
		{
            Connect = null;
            connected = null;
            notConnected = null;
        }
		
		public override void OnEnter()
		{
			Connect.Value = SteamUser.BLoggedOn();
            if(Connect.Value)
            {
                Fsm.Event(connected);
            }
            else
            {
                Fsm.Event(notConnected);
            }

		}
	}
}