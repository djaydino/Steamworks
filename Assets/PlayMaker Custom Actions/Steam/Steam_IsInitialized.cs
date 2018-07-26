// (c) Copyright HutongGames, LLC 2010-2018. All rights reserved.
// Made by djaydino -- http://www.jinxtergames.com/ --
/*--- __ECO__ __PLAYMAKER__ __ACTION__ ---*/

using UnityEngine;
using Steamworks;

namespace HutongGames.PlayMaker.Actions
{
    [ActionCategory("Steamworks.NET")]
    [Tooltip("check if steam is initialized")]
    public class Steam_IsInitialized : FsmStateAction
    {
        [UIHint(UIHint.Variable)]
        public FsmBool isInitialized;

        public FsmEvent initialized;

        public FsmEvent notInitialized;

        public override void Reset()
        {
            isInitialized = null;
            initialized = null;
            notInitialized = null;
        }

        public override void OnEnter()
        {
            if (SteamManager.Initialized)
            {
                SteamAPI.Init();
                isInitialized.Value = true;
                Fsm.Event(initialized);
            }
            else
            {
                isInitialized.Value = false;
                Fsm.Event(notInitialized);
            }
            Finish();
        }
    }
}
