// (c) Copyright HutongGames, LLC 2010-2018. All rights reserved.
// Made by djaydino -- http://www.jinxtergames.com/ --
/*--- __ECO__ __PLAYMAKER__ __ACTION__ ---*/
#if !DISABLESTEAMWORKS
using UnityEngine;
using Steamworks;

namespace HutongGames.PlayMaker.Actions
{
    [ActionCategory("Steamworks.NET - Client")]
    [Tooltip("Check if VR headset Streaming is Enables")]
    public class Steam_IsVRHeadsetStreamingEnabled : FsmStateAction
    {

        [UIHint(UIHint.Variable)]
        public FsmBool isEnabled;

        public override void Reset()
        {
            isEnabled = null;
        }

        public override void OnEnter()
        {
            isEnabled.Value = (bool)SteamUtils.IsVRHeadsetStreamingEnabled();
            Finish();
        }
    }
}
#endif