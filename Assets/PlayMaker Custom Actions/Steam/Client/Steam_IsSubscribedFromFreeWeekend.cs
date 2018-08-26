// (c) Copyright HutongGames, LLC 2010-2018. All rights reserved.
// Made by djaydino -- http://www.jinxtergames.com/ --
/*--- __ECO__ __PLAYMAKER__ __ACTION__ ---*/

using UnityEngine;
using Steamworks;

namespace HutongGames.PlayMaker.Actions
{
    [ActionCategory("Steamworks.NET - Client")]
    [Tooltip("Checks if the user is subscribed to the current app through a free weekend, This will return false for users who have a retail or other type of license")]
    public class Steam_IsSubscribedFromFreeWeekend : FsmStateAction
    {
        [RequiredField]
        [UIHint(UIHint.Variable)]
        public FsmBool result;


        public override void Reset()
        {
            result = null;
        }

        public override void OnEnter()
        {
            result.Value = SteamApps.BIsSubscribedFromFreeWeekend();
            Finish();
        }
    }
}
