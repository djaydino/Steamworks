// (c) Copyright HutongGames, LLC 2010-2018. All rights reserved.
// Made by djaydino -- http://www.jinxtergames.com/ --
/*--- __ECO__ __PLAYMAKER__ __ACTION__ ---*/
#if !DISABLESTEAMWORKS
using UnityEngine;
using Steamworks;

namespace HutongGames.PlayMaker.Actions
{
    [ActionCategory("Steam - Controller")]
    [Tooltip("Reconfigure the controller to use the specified action set (ie 'Menu', 'Walk' or 'Drive') This is cheap, and can be safely called repeatedly. It's often easier to repeatedly call it in  your state loops, instead of trying to place it in all of your state transitions.")]
    public class Steam_ActivateActionSet : FsmStateAction
    {
        [RequiredField]
        [Tooltip("the controller id")]
        public FsmInt controller;

        [RequiredField]
        [Tooltip("the Controller Action Set Handle")]
        public FsmInt actionSetHandle;

        public override void Reset()
        {
            controller = null;
        }

        public override void OnEnter()
        {
            SteamController.ActivateActionSet((ControllerHandle_t)(ulong)controller.Value, (ControllerActionSetHandle_t)(ulong)actionSetHandle.Value);
            Finish();
        }

    }
}
#endif