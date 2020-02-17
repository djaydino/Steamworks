// (c) Copyright HutongGames, LLC 2010-2018. All rights reserved.
// Made by djaydino -- http://www.jinxtergames.com/ --
/*--- __ECO__ __PLAYMAKER__ __ACTION__ ---*/
#if !DISABLESTEAMWORKS
using UnityEngine;
using Steamworks;
using System;

namespace HutongGames.PlayMaker.Actions
{
    [ActionCategory("Steamworks.NET - Client")]
    [Tooltip("Get beta info")]
    public class Steam_GetBetaInfo : FsmStateAction

    {

        [RequiredField]
        [UIHint(UIHint.Variable)]
        [Tooltip("beta name will only be given if user is running from a beta branch")]
        public FsmString betaName;

        [UIHint(UIHint.Variable)]
        [Tooltip("get if user is on beta")]
        public FsmBool userOnBeta;

        [Tooltip("Set a maximum length for the name to display")]
        public FsmInt MaxNameLenght;

        public FsmEvent isOnBeta;

        public FsmEvent isNotOnBeta;

        private string betaN;
        public override void Reset()
        {
            betaName = null;
            MaxNameLenght = 20;
            userOnBeta = null;
            isOnBeta = null;
            isNotOnBeta = null;
        }

        public override void OnEnter()
        {
            userOnBeta.Value = (SteamApps.GetCurrentBetaName(out betaN, (int)MaxNameLenght.Value));
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
#endif