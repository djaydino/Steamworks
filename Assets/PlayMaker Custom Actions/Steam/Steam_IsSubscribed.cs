// (c) Copyright HutongGames, LLC 2010-2018. All rights reserved.
// Made by djaydino -- http://www.jinxtergames.com/ --
/*--- __ECO__ __PLAYMAKER__ __ACTION__ ---*/

using UnityEngine;
using Steamworks;

namespace HutongGames.PlayMaker.Actions
{
    [ActionCategory("Steamworks.NET - Client")]
    [Tooltip("Returns whenever the client is subscribed to the specified Steam Workshop item")]
    public class Steam_IsSubscribed : FsmStateAction
    {
        [RequiredField]
        [UIHint(UIHint.Variable)]
        public FsmBool result;


        public override void Reset()
        {
            result = null;
        }

        public override void OnEnter()
        {
            result.Value = SteamApps.BIsSubscribed();
            Finish();
        }
    }
}
