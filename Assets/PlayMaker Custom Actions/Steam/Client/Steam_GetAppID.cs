// (c) Copyright HutongGames, LLC 2010-2018. All rights reserved.
// Made by djaydino -- http://www.jinxtergames.com/ --
/*--- __ECO__ __PLAYMAKER__ __ACTION__ ---*/

using UnityEngine;
using Steamworks;
using System;

namespace HutongGames.PlayMaker.Actions
{
    [ActionCategory("Steamworks.NET Client")]
    [Tooltip("Get´s steam app ID.")]
    public class Steam_GetAppID : FsmStateAction
    {
        [RequiredField]
        [UIHint(UIHint.Variable)]
        public FsmInt appID;

        public override void Reset()
        {
            appID = null;
        }

        public override void OnEnter()
        {
            appID.Value = Convert.ToInt32(SteamUtils.GetAppID());
            Finish();
        }

    }
}