// (c) Copyright HutongGames, LLC 2010-2018. All rights reserved.
// Made by djaydino -- http://www.jinxtergames.com/ --
/*--- __ECO__ __PLAYMAKER__ __ACTION__ ---*/

using UnityEngine;
using Steamworks;

namespace HutongGames.PlayMaker.Actions
{
    [ActionCategory("Steamworks.NET - Parental Settings")]
    [Tooltip("Get parental settings")]
    public class Steam_ParentalLock : FsmStateAction
    {
        [UIHint(UIHint.Variable)]
        public FsmBool isParentalLockEnabled;

        [UIHint(UIHint.Variable)]
        public FsmBool isParentalLockLocked;

        public override void Reset()
        {
            isParentalLockEnabled = null;
            isParentalLockLocked = null;
        }

        public override void OnEnter()
        {
            if(isParentalLockEnabled != null) isParentalLockEnabled.Value = (bool)SteamParentalSettings.BIsParentalLockEnabled();
            if (isParentalLockLocked != null) isParentalLockLocked.Value = (bool)SteamParentalSettings.BIsParentalLockLocked();
            Finish();
        }

    }
}
