// (c) Copyright HutongGames, LLC 2010-2018. All rights reserved.
// Made by djaydino -- http://www.jinxtergames.com/ --
/*--- __ECO__ __PLAYMAKER__ __ACTION__ ---*/

using UnityEngine;
using Steamworks;

namespace HutongGames.PlayMaker.Actions
{
    [ActionCategory("Steamworks.NET - Client")]
    [Tooltip("")]
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
        [Tooltip("Select avatar size to load. Warning!! Many users do not have Large avatars")]
        public OverlayType overlayType = OverlayType.friends;

        public override void OnEnter()
        {
            SteamFriends.ActivateGameOverlay(overlayType.ToString());
            Debug.Log(overlayType.ToString());
            Finish();
        }

    }
}
