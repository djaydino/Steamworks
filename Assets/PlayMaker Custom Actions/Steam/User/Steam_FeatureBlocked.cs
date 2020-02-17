// (c) Copyright HutongGames, LLC 2010-2018. All rights reserved.
// Made by djaydino -- http://www.jinxtergames.com/ --
/*--- __ECO__ __PLAYMAKER__ __ACTION__ ---*/
#if !DISABLESTEAMWORKS
using UnityEngine;
using Steamworks;

namespace HutongGames.PlayMaker.Actions
{
    [ActionCategory("Steamworks.NET - Parental Settings")]
    [Tooltip("check if certain feature is parental locked")]
    public class Steam_FeatureBlocked : FsmStateAction
    {
        public EParentalFeature parentalFeature = EParentalFeature.k_EFeatureBrowser;

        [UIHint(UIHint.Variable)]
        public FsmBool isAppBlocked;

        [UIHint(UIHint.Variable)]
        public FsmBool isAppInBlockList;

        public override void Reset()
        {

        }

        public override void OnEnter()
        {
            if (isAppBlocked != null) isAppBlocked.Value = SteamParentalSettings.BIsFeatureBlocked(parentalFeature);
            if (isAppInBlockList != null) isAppInBlockList.Value = SteamParentalSettings.BIsFeatureInBlockList(parentalFeature);
            Finish();
        }

    }
}
#endif