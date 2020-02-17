// (c) Copyright HutongGames, LLC 2010-2018. All rights reserved.
// Made by djaydino -- http://www.jinxtergames.com/ --
/*--- __ECO__ __PLAYMAKER__ __ACTION__ ---*/
#if !DISABLESTEAMWORKS
using UnityEngine;
using Steamworks;

namespace HutongGames.PlayMaker.Actions
{
    [ActionCategory("Steamworks.NET - Client")]
    [Tooltip("Gets the current game language that is set on the client")]
    public class Steam_GetCurrentGameLanguage : FsmStateAction
    {
        [RequiredField]
        [UIHint(UIHint.Variable)]
        public FsmString Result;

        public override void Reset()
        {
            Result = null;
        }

        public override void OnEnter()
        {
            Result.Value = SteamApps.GetCurrentGameLanguage();
            Finish();
        }
    }
}
#endif