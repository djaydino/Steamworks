// (c) Copyright HutongGames, LLC 2010-2018. All rights reserved.
// Made by djaydino -- http://www.jinxtergames.com/ --
/*--- __ECO__ __PLAYMAKER__ __ACTION__ ---*/

using UnityEngine;
using Steamworks;
using System;

namespace HutongGames.PlayMaker.Actions
{
    [ActionCategory("Steamworks.NET Client")]
    [Tooltip("Steam server time.  Number of seconds since January 1, 1970, GMT (i.e unix time)")]
    public class Steam_SteamServerTime : FsmStateAction
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
