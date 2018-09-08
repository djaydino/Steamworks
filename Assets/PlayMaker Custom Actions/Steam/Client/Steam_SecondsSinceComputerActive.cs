// (c) Copyright HutongGames, LLC 2010-2018. All rights reserved.
// Made by djaydino -- http://www.jinxtergames.com/ --
/*--- __ECO__ __PLAYMAKER__ __ACTION__ ---*/

using UnityEngine;
using Steamworks;
using System;

namespace HutongGames.PlayMaker.Actions
{
    [ActionCategory("Steamworks.NET Client")]
    [Tooltip("Returns the number of seconds since the user last moved the mouse.")]
    public class Steam_SecondsSinceComputerActive : FsmStateAction
    {
        [UIHint(UIHint.Variable)]
        public FsmInt result;

        public bool everyFrame;

        public override void Reset()
        {
            result = null;
        }

        public override void OnEnter()
        {
            ServerRealTime();
            if (!everyFrame)
            {
                Finish();
            }
            
        }

        public override void OnUpdate()
        {
            ServerRealTime();
        }

        void ServerRealTime()
        {
            result.Value = (int)SteamUtils.GetServerRealTime();
        }
    }
}
