// (c) Copyright HutongGames, LLC 2010-2018. All rights reserved.
// Made by djaydino -- http://www.jinxtergames.com/ --
/*--- __ECO__ __PLAYMAKER__ __ACTION__ ---*/

using UnityEngine;
using Steamworks;
using System;

namespace HutongGames.PlayMaker.Actions
{
    [ActionCategory("Steamworks.NET - Client")]
    [Tooltip("Checks if the active user is subscribed to a specified AppId.")]
    public class Steam_IsSubscribedApp : FsmStateAction

    {
        [RequiredField]
        public FsmInt appID;

        [RequiredField]
        [UIHint(UIHint.Variable)]
        public FsmBool isSubscribed;

        public override void Reset()
        {
            appID = null;
            isSubscribed = null;
        }

        public override void OnEnter()
        {
            isSubscribed.Value = SteamApps.BIsSubscribedApp((AppId_t)(uint)appID.Value);
            Finish();
        }
    }
}
