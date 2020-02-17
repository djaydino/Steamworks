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
    [Tooltip("Returns the 2 digit ISO 3166-1-alpha-2 format country code which client is running in. e.g US or UK.")]
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
#endif