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
    [Tooltip("removes an allocated user. NOT THREADSAFE - ensure that no other threads are accessing Steamworks API when calling")]
    public class Steam_ReleaseUser : FsmStateAction
    {
        [RequiredField]
        [Tooltip("The steamPipe ID")]
        public FsmInt steamPipeId;

        [RequiredField]
        [Tooltip("Steam User")]
        public FsmInt steamUser;


        public override void Reset()
        {
            steamPipeId = null;
        }

        public override void OnEnter()
        {
            SteamClient.ReleaseUser((HSteamPipe)steamPipeId.Value, (HSteamUser)steamUser.Value);
            Finish();
        }
    }
}
#endif