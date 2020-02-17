// (c) Copyright HutongGames, LLC 2010-2018. All rights reserved.
// Made by djaydino -- http://www.jinxtergames.com/ --
/*--- __ECO__ __PLAYMAKER__ __ACTION__ ---*/
#if !DISABLESTEAMWORKS
using UnityEngine;
using Steamworks;

namespace HutongGames.PlayMaker.Actions
{
    [ActionCategory("Steamworks.NET - Client")]
    [Tooltip("true if the active user is subscribed to the current App Id via a free weekend otherwise false any other type of license.")]
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
#endif