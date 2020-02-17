// (c) Copyright HutongGames, LLC 2010-2018. All rights reserved.
// Made by djaydino -- http://www.jinxtergames.com/ --
/*--- __ECO__ __PLAYMAKER__ __ACTION__ ---*/
#if !DISABLESTEAMWORKS
using UnityEngine;
using Steamworks;

namespace HutongGames.PlayMaker.Actions
{
    [ActionCategory("Steamworks.NET - Client")]
    [Tooltip("Check if Steam is running in VR mode")]
    public class Steam_IsSteamRunningInVR : FsmStateAction
    {

        [UIHint(UIHint.Variable)]
        public FsmBool isRunningInVR;

        public override void Reset()
        {
            isRunningInVR = null;
        }

        public override void OnEnter()
        {
            isRunningInVR.Value = (bool)SteamUtils.IsSteamRunningInVR();
            Finish();
        }
    }
}
#endif