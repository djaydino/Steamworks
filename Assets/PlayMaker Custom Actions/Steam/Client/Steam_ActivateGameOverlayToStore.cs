// (c) Copyright HutongGames, LLC 2010-2018. All rights reserved.
// Made by djaydino -- http://www.jinxtergames.com/ --
/*--- __ECO__ __PLAYMAKER__ __ACTION__ ---*/

using UnityEngine;
using Steamworks;
using System;

namespace HutongGames.PlayMaker.Actions
{
    [ActionCategory("Steamworks.NET - Client")]
    [Tooltip("Activate the store overlay a certain overlay type")]
    public class Steam_ActivateGameOverlayToStore : FsmStateAction
    {
        [RequiredField]
        public FsmInt appID;

        public EOverlayToStoreFlag overlayType = EOverlayToStoreFlag.k_EOverlayToStoreFlag_None;

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
    }
}
