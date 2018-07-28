// (c) Copyright HutongGames, LLC 2010-2018. All rights reserved.
// Made by djaydino -- http://www.jinxtergames.com/ --
/*--- __ECO__ __PLAYMAKER__ __ACTION__ ---*/

using UnityEngine;
using Steamworks;
using System;

namespace HutongGames.PlayMaker.Actions
{
    [ActionCategory("Steamworks.NET - UserStats")]
    [Tooltip("request User stats")]
    public class Steam_GetUserName : FsmStateAction
    {
        [RequiredField]
        [UIHint(UIHint.Variable)]
        public FsmString userName;

        public FsmEvent success;

        public FsmEvent failed;

        private int statInt;

        public override void Reset()
        {
            userName = null;

        }

        public override void OnEnter()
        {
            userName.Value = SteamFriends.GetPersonaName();

            Finish();
        }
    }
}
