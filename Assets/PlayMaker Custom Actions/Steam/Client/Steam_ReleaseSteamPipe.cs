// (c) Copyright HutongGames, LLC 2010-2018. All rights reserved.
// Made by djaydino -- http://www.jinxtergames.com/ --
/*--- __ECO__ __PLAYMAKER__ __ACTION__ ---*/

using UnityEngine;
using Steamworks;
using System;

namespace HutongGames.PlayMaker.Actions
{
    [ActionCategory("Steamworks.NET - Client")]
    [Tooltip("Releases a previously created communications pipe. NOT THREADSAFE - ensure that no other threads are accessing Steamworks API when calling")]
    public class Steam_ReleaseSteamPipe : FsmStateAction
    {
        [RequiredField]
        [Tooltip("the steamPipe ID")]
        public FsmInt steamPipeId;

        public override void Reset()
        {
            steamPipeId = null;
        }

        public override void OnEnter()
        {
            SteamClient.BReleaseSteamPipe((HSteamPipe)steamPipeId.Value);
            Finish();
        }
    }
}
