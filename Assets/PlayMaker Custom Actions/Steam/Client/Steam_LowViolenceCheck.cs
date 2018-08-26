// (c) Copyright HutongGames, LLC 2010-2018. All rights reserved.
// Made by djaydino -- http://www.jinxtergames.com/ --
/*--- __ECO__ __PLAYMAKER__ __ACTION__ ---*/

using UnityEngine;
using Steamworks;

namespace HutongGames.PlayMaker.Actions
{
    [ActionCategory("Steamworks.NET - Client")]
    [Tooltip("Check if client is a low violence client")]
    public class Steam_LowViolenceCheck : FsmStateAction
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
            result.Value = SteamApps.BIsLowViolence();
            Finish();
        }
    }
}
