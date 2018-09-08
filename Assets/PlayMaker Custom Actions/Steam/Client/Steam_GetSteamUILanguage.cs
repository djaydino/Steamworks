// (c) Copyright HutongGames, LLC 2010-2018. All rights reserved.
// Made by djaydino -- http://www.jinxtergames.com/ --
/*--- __ECO__ __PLAYMAKER__ __ACTION__ ---*/

using UnityEngine;
using Steamworks;

namespace HutongGames.PlayMaker.Actions
{
    [ActionCategory("Steamworks.NET - Client")]
    [Tooltip("Gets the Steam UI language")]
    public class Steam_GetSteamUILanguage : FsmStateAction
    {
        [UIHint(UIHint.Variable)]
        [Tooltip("The Steam UI language")]
        public FsmString result;

        public override void Reset()
        {
            result = null;
        }

        public override void OnEnter()
        {
            result.Value = (string)SteamUtils.GetSteamUILanguage();
            Finish();
        }
    }
}
