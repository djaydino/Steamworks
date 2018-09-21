// (c) Copyright HutongGames, LLC 2010-2018. All rights reserved.
// Made by djaydino -- http://www.jinxtergames.com/ --
/*--- __ECO__ __PLAYMAKER__ __ACTION__ ---*/

using UnityEngine;
using Steamworks;

namespace HutongGames.PlayMaker.Actions
{
    [ActionCategory("Steamworks.NET - Client")]
    [Tooltip("Activate the gameoverlay in a certain overlay type")]
    public class Steam_ActivateGameOverlay : FsmStateAction
    {
        public enum OverlayType
        {
            friends,
            community,
            players,
            settings,
            officialgamegroup,
            stats,
            achievements
        }
        public OverlayType overlayType = OverlayType.friends;

        public override void OnEnter()
        {
            if (!Application.isEditor)
            {
                SteamFriends.ActivateGameOverlay(overlayType.ToString());
            }
                else
            {
                Debug.LogWarning("Steam Overlay does not work in editor mode");
            }
            Finish();
        }
    }
}
