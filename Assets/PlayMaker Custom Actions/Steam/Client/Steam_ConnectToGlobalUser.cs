// (c) Copyright HutongGames, LLC 2010-2018. All rights reserved.
// Made by djaydino -- http://www.jinxtergames.com/ --
/*--- __ECO__ __PLAYMAKER__ __ACTION__ ---*/

using UnityEngine;
using Steamworks;
using System;

namespace HutongGames.PlayMaker.Actions
{
    [ActionCategory("Steamworks.NET - Client")]
    [Tooltip("connects to an existing global user, failing if none exists. Used by the game to coordinate with the steamUI")]
    public class Steam_ConnectToGlobalUser : FsmStateAction
    {
        [RequiredField]
        [Tooltip("the steamPipe ID")]
        public FsmInt steamPipeId;

        public EAccountType eAccountType;

        public override void Reset()
        {
            steamPipeId = null;
            eAccountType = EAccountType.k_EAccountTypeAnonGameServer;
        }

        public override void OnEnter()
        {
            SteamClient.ConnectToGlobalUser((HSteamPipe)steamPipeId.Value);
            Finish();
        }
    }
}
