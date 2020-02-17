// (c) Copyright HutongGames, LLC 2010-2018. All rights reserved.
// Made by djaydino -- http://www.jinxtergames.com/ --
/*--- __ECO__ __PLAYMAKER__ __ACTION__ ---*/
#if !DISABLESTEAMWORKS
using UnityEngine;
using Steamworks;
using System;

namespace HutongGames.PlayMaker.Actions
{
    [ActionCategory("Steam - Controller")]
    [Tooltip("Lookup the handle for an Action Set. Best to do this once on startup, and store the handles for all future API calls.")]
    public class Steam_GetActionSetHandle : FsmStateAction
    {
        [RequiredField]
        [Tooltip("The action set name to look up")]
        public FsmString actionSetName;

        [ActionSection("Result")]
        [RequiredField]
        [ObjectType(typeof(SteamControllerAction))]
        [UIHint(UIHint.Variable)]
        public FsmObject ControllerAction;

        public override void Reset()
        {
            ControllerAction = null;
        }

        public override void OnEnter()
        {

            ControllerAction.Value = new SteamControllerAction(SteamController.GetActionSetHandle(actionSetName.Value));
      
            Finish();
        }

    }
}
#endif