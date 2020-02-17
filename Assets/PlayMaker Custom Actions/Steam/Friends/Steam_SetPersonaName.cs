// (c) Copyright HutongGames, LLC 2010-2018. All rights reserved.
// Made by djaydino -- http://www.jinxtergames.com/ --
/*--- __ECO__ __PLAYMAKER__ __ACTION__ ---*/
#if !DISABLESTEAMWORKS
using UnityEngine;
using Steamworks;
using System;

namespace HutongGames.PlayMaker.Actions
{
    [ActionCategory("Steamworks.NET - Friends")]
    [Tooltip("Set a new personal name (display) name.")]
    public class Steam_SetPersonaName : FsmStateAction
    {
        [RequiredField]
        public FsmString userName;

        public override void Reset()
        {
            userName = null;
        }

        public override void OnEnter()
        {
            SteamFriends.SetPersonaName((string)userName.Value);
            Finish();
        }
    }
}
#endif