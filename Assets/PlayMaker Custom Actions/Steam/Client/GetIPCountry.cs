// (c) Copyright HutongGames, LLC 2010-2018. All rights reserved.
// Made by djaydino -- http://www.jinxtergames.com/ --
/*--- __ECO__ __PLAYMAKER__ __ACTION__ ---*/

using UnityEngine;
using Steamworks;
using System;

namespace HutongGames.PlayMaker.Actions
{
    [ActionCategory("Steam")]
    [Tooltip("Steam server time.  Number of seconds since January 1, 1970, GMT (i.e unix time)")]
    public class Steam_GetIPCountry : FsmStateAction
    {
        [UIHint(UIHint.Variable)]
        public FsmString result;

        public override void Reset()
        {
            result = null;
        }

        public override void OnEnter()
        {
            result.Value = (string)SteamUtils.GetIPCountry();
                Finish();
        }
    }
}
