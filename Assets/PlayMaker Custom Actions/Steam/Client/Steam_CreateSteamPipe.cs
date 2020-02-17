// (c) Copyright HutongGames, LLC 2010-2018. All rights reserved.
// Made by djaydino -- http://www.jinxtergames.com/ --
/*--- __ECO__ __PLAYMAKER__ __ACTION__ ---*/
#if !DISABLESTEAMWORKS
using UnityEngine;
using Steamworks;
using System;

namespace HutongGames.PlayMaker.Actions
{
    [ActionCategory("Steamworks.NET - Client")]
    [Tooltip("Creates a communication pipe to the Steam client. NOT THREADSAFE - ensure that no other threads are accessing Steamworks API when calling")]
    public class Steam_CreateSteamPipe : FsmStateAction
    {
        [ActionSection("Result")]

        [RequiredField]
        [Tooltip("the steamPipe ID")]
        [UIHint(UIHint.Variable)]
        public FsmInt steamPipeId;

        public override void Reset()
        {
            steamPipeId = null;
        }

        public override void OnEnter()
        {
            steamPipeId.Value = (int)SteamClient.CreateSteamPipe();
            Finish();
        }
    }
}
#endif