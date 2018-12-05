// (c) Copyright HutongGames, LLC 2010-2018. All rights reserved.
// Made by djaydino -- http://www.jinxtergames.com/ --
/*--- __ECO__ __PLAYMAKER__ __ACTION__ ---*/

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

        public FsmInt actionSetID;

        public override void Reset()
        {
            actionSetName = null;
        }

        public override void OnEnter()
        {
            actionSetID.Value = Convert.ToInt32((ulong)SteamController.GetActionSetHandle(actionSetName.Value));
            Finish();
        }

    }
}
