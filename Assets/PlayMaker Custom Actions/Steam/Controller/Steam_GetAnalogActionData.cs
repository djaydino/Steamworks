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
    [Tooltip("Returns the current state of these supplied analog game action")]
    public class Steam_GetAnalogActionData : FsmStateAction
    {
        [RequiredField]
        [Tooltip("the controller ID")]
        public FsmInt controller;

        [RequiredField]
        [Tooltip("the Controller Action Set Handle")]
        public FsmInt analogActionHandle;

        public bool everyFrame;

        [ActionSection("Result")]

        public FsmInt actionSetID;

        public override void Reset()
        {
            everyFrame = false;
            controller = null;
            analogActionHandle = null;
        }

        public override void OnEnter()
        {
            DoGetAnalogActionData();
            if(!everyFrame)
            {
                Finish();
            }
            
        }

        public override void OnUpdate()
        {
            DoGetAnalogActionData();
        }

        void DoGetAnalogActionData()
        {
          var result = SteamController.GetAnalogActionData((ControllerHandle_t)(ulong)controller.Value, (ControllerAnalogActionHandle_t)(ulong)analogActionHandle.Value);
            Vector2 theResult = new Vector2(result.x, result.y);
        }
    }
}
#endif