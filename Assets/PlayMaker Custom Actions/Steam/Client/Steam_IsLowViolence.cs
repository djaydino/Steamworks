// (c) Copyright HutongGames, LLC 2010-2018. All rights reserved.
// Made by djaydino -- http://www.jinxtergames.com/ --
/*--- __ECO__ __PLAYMAKER__ __ACTION__ ---*/
#if !DISABLESTEAMWORKS
using UnityEngine;
using Steamworks;

namespace HutongGames.PlayMaker.Actions
{
    [ActionCategory("Steamworks.NET - Client")]
    [Tooltip("Check if the license owned by the user provides low violence depots.")]
    public class Steam_IsLowViolence : FsmStateAction
    {
        [RequiredField]
        [UIHint(UIHint.Variable)]
        public FsmBool lowViolence;

        public override void Reset()
        {
            lowViolence = null;
        }

        public override void OnEnter()
        {
            lowViolence.Value = SteamApps.BIsLowViolence();
            Finish();
        }
    }
}
#endif