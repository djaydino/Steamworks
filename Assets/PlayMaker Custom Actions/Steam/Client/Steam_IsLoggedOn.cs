// (c) Copyright HutongGames, LLC 2010-2018. All rights reserved.
// Made by djaydino -- http://www.jinxtergames.com/ --
/*--- __ECO__ __PLAYMAKER__ __ACTION__ ---*/

using UnityEngine;
using System.Collections;
using Steamworks;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Steamworks.NET - Client")]
	[Tooltip("Checks if the game server is logged on.")]
	public class Steam_IsLoggedOn : FsmStateAction
	{
		[UIHint(UIHint.Variable)]
		public FsmBool result;

        public FsmEvent isLoggedOn;

        public FsmEvent notLoggedOn;

        public override void Reset()
		{
            result = null;
            isLoggedOn = null;
            notLoggedOn = null;
        }
		
		public override void OnEnter()
		{
			result.Value = SteamUser.BLoggedOn();
            if(result.Value)
            {
                Fsm.Event(isLoggedOn);
            }
            else
            {
                Fsm.Event(notLoggedOn);
            }

		}
	}
}