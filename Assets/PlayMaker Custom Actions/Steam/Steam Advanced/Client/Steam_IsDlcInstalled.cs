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
    [Tooltip("Check if client has a certain DLC installed. (use the DLC AppID")]
    public class Steam_IsDlcInstalled : FsmStateAction
    {
        [RequiredField]
        public FsmInt dlcAppID;

        [RequiredField]
        [UIHint(UIHint.Variable)]
        public FsmBool result;

        public override void Reset()
        {
            dlcAppID = null;
            result = null;
        }

        public override void OnEnter()
        {
            result.Value = SteamApps.BIsDlcInstalled((AppId_t)(uint)dlcAppID.Value);
            Finish();
        }
    }
}
#endif