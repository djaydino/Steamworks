// (c) Copyright HutongGames, LLC 2010-2018. All rights reserved.
// Made by djaydino -- http://www.jinxtergames.com/ --
/*--- __ECO__ __PLAYMAKER__ __ACTION__ ---*/

using UnityEngine;
using Steamworks;
using System;

namespace HutongGames.PlayMaker.Actions
{
    [ActionCategory("Steamworks.NET - Friends")]
    [Tooltip("Get friendcount")]
    public class Steam_GetFriendCount : FsmStateAction
    {
        [RequiredField]
        public FsmInt count;

        public override void Reset()
        {
            count = null;
        }

        public override void OnEnter()
        {
           count.Value = SteamFriends.GetFriendCount(EFriendFlags.k_EFriendFlagImmediate);
            Finish();
        }
    }
}
