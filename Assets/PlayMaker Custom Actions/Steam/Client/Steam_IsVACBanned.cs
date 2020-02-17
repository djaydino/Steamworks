// (c) Copyright HutongGames, LLC 2010-2018. All rights reserved.
// Made by djaydino -- http://www.jinxtergames.com/ --
/*--- __ECO__ __PLAYMAKER__ __ACTION__ ---*/
#if !DISABLESTEAMWORKS
using UnityEngine;
using Steamworks;

namespace HutongGames.PlayMaker.Actions
{
    [ActionCategory("Steamworks.NET - Client")]
    [Tooltip("Check if Client is VAC Banned")]
    public class Steam_IsVACBanned : FsmStateAction
    {
        [RequiredField]
        [UIHint(UIHint.Variable)]
        public FsmBool isVACBanned;

        public override void Reset()
        {
            isVACBanned = null;
        }

        public override void OnEnter()
        {
            isVACBanned.Value = SteamApps.BIsVACBanned();
            Finish();
        }
    }
}
#endif