// (c) Copyright HutongGames, LLC 2010-2018. All rights reserved.
// Made by djaydino -- http://www.jinxtergames.com/ --
/*--- __ECO__ __PLAYMAKER__ __ACTION__ ---*/

using UnityEngine;
using Steamworks;
using System;

namespace HutongGames.PlayMaker.Actions
{
    [ActionCategory("Steamworks.NET - Client")]
    [Tooltip("gets the Unix time of the purchase of the app. Use the custom action 'Read Epoch' from the Ecosystem to convert to a readable date/time")]
    public class Steam_GetBetaInfo : FsmStateAction

    {

        [RequiredField]
        [UIHint(UIHint.Variable)]
        [Tooltip("beta name will only be given if user is running from a beta branch")]
        public FsmString betaName;

        [UIHint(UIHint.Variable)]
        [Tooltip("get bytes")]
        public FsmBool userOnBeta;

        public FsmEvent isOnBeta;

        public FsmEvent isNotOnBeta;

        private string betaN;
        private int cchNameBufferSize;
        public override void Reset()
        {
            betaName = null;
            
            userOnBeta = null;
            isOnBeta = null;
            isNotOnBeta = null;
        }

        public override void OnEnter()
        {
            userOnBeta.Value = (SteamApps.GetCurrentBetaName(out betaN, cchNameBufferSize));
            if(userOnBeta.Value)
            {
                betaName.Value = betaN;
                Fsm.Event(isOnBeta);
            }
            else
            {
                Fsm.Event(isNotOnBeta);
            }

            Finish();
        }
    }
}
