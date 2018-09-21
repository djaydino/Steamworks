// (c) Copyright HutongGames, LLC 2010-2018. All rights reserved.
// Made by djaydino -- http://www.jinxtergames.com/ --
/*--- __ECO__ __PLAYMAKER__ __ACTION__ ---*/

using UnityEngine;
using Steamworks;

namespace HutongGames.PlayMaker.Actions
{
    [ActionCategory("Steamworks.NET - Client")]
    [Tooltip("Checks if the active user is subscribed to the current App ID.")]
    public class Steam_IsSubscribed : FsmStateAction
    {
        [RequiredField]
        [UIHint(UIHint.Variable)]
        public FsmBool isSubscribed;


        public override void Reset()
        {
            isSubscribed = null;
        }

        public override void OnEnter()
        {
            isSubscribed.Value = SteamApps.BIsSubscribed();
            Finish();
        }
    }
}
