// (c) Copyright HutongGames, LLC 2010-2018. All rights reserved.
// Made by djaydino -- http://www.jinxtergames.com/ --
/*--- __ECO__ __PLAYMAKER__ __ACTION__ ---*/

using UnityEngine;
using Steamworks;
using System;

namespace HutongGames.PlayMaker.Actions
{
    [ActionCategory("Steamworks.NET - Parental Settings")]
    [Tooltip("Get parental settings")]
    public class Steam_AppBlocked : FsmStateAction
    {
        [RequiredField]
        public FsmInt appID;

        [UIHint(UIHint.Variable)]
        public FsmBool isAppBlocked;

        [UIHint(UIHint.Variable)]
        public FsmBool isAppInBlockList;

        public override void Reset()
        {
            isAppBlocked = null;
            isAppInBlockList = null;
            appID = null;
        }

        public override void OnEnter()
        {
            if (isAppBlocked != null) isAppBlocked.Value = (bool)SteamParentalSettings.BIsAppBlocked((AppId_t)Convert.ToUInt32(appID.Value));
            if (isAppInBlockList != null) isAppInBlockList.Value = (bool)SteamParentalSettings.BIsAppInBlockList((AppId_t)Convert.ToUInt32(appID.Value));
            Finish();
        }

    }
}
