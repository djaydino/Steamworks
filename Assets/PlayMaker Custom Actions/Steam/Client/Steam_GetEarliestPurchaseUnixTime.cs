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
    [Tooltip("gets the Unix time of the purchase of the app. \nUse the custom action 'Read Epoch' from the Ecosystem to convert to a readable date/time")]
    public class Steam_GetEarliestPurchaseUnixTime : FsmStateAction

    {
        [RequiredField]
        public FsmInt appID;

        [RequiredField]
        [UIHint(UIHint.Variable)]
        public FsmInt unixTime;

        public override void Reset()
        {
            appID = null;
            unixTime = null;
        }

        public override void OnEnter()
        {
            unixTime.Value = (int)SteamApps.GetEarliestPurchaseUnixTime((AppId_t)Convert.ToUInt64(appID.Value));
            Finish();
        }
    }
}
#endif