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
    [Tooltip("set the local IP and Port to bind to. this must be set before CreateLocalUser")]
    public class Steam_SetLocalIPBinding : FsmStateAction
    {
        [RequiredField]
        [Tooltip("the local IP")]
        public FsmInt localIp;

        [RequiredField]
        [Tooltip("the steamPipe ID")]
        public FsmInt port;

        public override void Reset()
        {
            localIp = null;
            port = null;
        }

        public override void OnEnter()
        {
            SteamClient.SetLocalIPBinding((uint)localIp.Value, (ushort)port.Value);
            Finish();
        }
    }
}
#endif