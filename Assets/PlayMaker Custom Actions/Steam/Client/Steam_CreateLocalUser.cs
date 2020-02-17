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
    [Tooltip("Used by game servers, create a steam user that won't be shared with anyone else. NOT THREADSAFE - ensure that no other threads are accessing Steamworks API when calling")]
    public class Steam_CreateLocalUser : FsmStateAction
    {
        [ActionSection("Result")]

        [RequiredField]
        [Tooltip("the steamPipe ID")]
        [UIHint(UIHint.Variable)]
        public FsmInt steamPipeId;

        [RequiredField]
        [Tooltip("Steam user")]
        [UIHint(UIHint.Variable)]
        public FsmInt steamUser;

        public EAccountType eAccountType;

        public override void Reset()
        {
            steamPipeId = null;
            steamUser = null;
            eAccountType = EAccountType.k_EAccountTypeAnonGameServer;
        }

        public override void OnEnter()
        {
            HSteamPipe theSteamPipeId;
            steamUser.Value = (int)SteamClient.CreateLocalUser(out theSteamPipeId, eAccountType);
            steamPipeId.Value = (int)theSteamPipeId;
            Finish();
        }
    }
}
#endif