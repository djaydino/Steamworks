// (c) Copyright HutongGames, LLC 2010-2018. All rights reserved.
// Made by djaydino -- http://www.jinxtergames.com/ --
/*--- __ECO__ __PLAYMAKER__ __ACTION__ ---*/

using UnityEngine;
using Steamworks;
using System;
using IntPtr = System.IntPtr;

namespace HutongGames.PlayMaker.Actions
{
    [ActionCategory("Steamworks.NET - Client")]
    [Tooltip("connects to an existing global user, failing if none exists. Used by the game to coordinate with the steamUI")]
    public class Steam_GetISteamUser : FsmStateAction
    {
        [RequiredField]
        [Tooltip("the steamPipe ID")]
        public FsmInt steamUser;

        [RequiredField]
        [Tooltip("The steamPipe ID")]
        public FsmInt steamPipeId;

        public FsmString pchVersion;

        public EAccountType eAccountType;

        public override void Reset()
        {
            steamUser = null;
            steamPipeId = null;
            eAccountType = EAccountType.k_EAccountTypeAnonGameServer;
        }

        public override void OnEnter()
        {
            SteamClient.GetISteamUser((HSteamUser)steamUser.Value, (HSteamPipe)steamPipeId.Value, pchVersion.Value);
            Debug.Log(SteamClient.GetISteamUser((HSteamUser)steamUser.Value, (HSteamPipe)steamPipeId.Value, pchVersion.Value));
            Finish();
        }
    }
}
