// (c) Copyright HutongGames, LLC 2010-2018. All rights reserved.
// Made by djaydino -- http://www.jinxtergames.com/ --
/*--- __ECO__ __PLAYMAKER__ __ACTION__ ---*/

#if UNITY_ANDROID || UNITY_IOS || UNITY_TIZEN || UNITY_TVOS || UNITY_WEBGL || UNITY_WSA || UNITY_PS4 || UNITY_WII || UNITY_XBOXONE || UNITY_SWITCH
#define DISABLESTEAMWORKS
#endif

using UnityEngine;

#if !DISABLESTEAMWORKS
using Steamworks;
#endif

using System;

namespace HutongGames.PlayMaker.Actions
{
    [ActionCategory("Steamworks.NET - Client")]
    [Tooltip("Activate the store overlay a certain overlay type")]
    public class Steam_ActivateGameOverlayToStore : FsmStateAction
    {
#if !DISABLESTEAMWORKS
        [RequiredField]
        public FsmInt appID;

        public EOverlayToStoreFlag overlayType = EOverlayToStoreFlag.k_EOverlayToStoreFlag_None;

        public override void Reset()
        {
            appID = null;
        }


        public override void OnEnter()
        {
            if (!Application.isEditor)
            {
                SteamFriends.ActivateGameOverlayToStore((AppId_t)Convert.ToUInt32(appID.Value), overlayType);
            }
            else
            {
                Debug.LogWarning("Steam Overlay does not work in editor mode");
            }
            Finish();
        }
#else
        public override string ErrorCheck()
        {
            return "Steamworks is disabled!";
        }
#endif
    }
}