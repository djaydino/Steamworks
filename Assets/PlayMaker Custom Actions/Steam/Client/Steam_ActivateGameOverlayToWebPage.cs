// (c) Copyright HutongGames, LLC 2010-2018. All rights reserved.
// Made by djaydino -- http://www.jinxtergames.com/ --
/*--- __ECO__ __PLAYMAKER__ __ACTION__ ---*/
#if !DISABLESTEAMWORKS
using UnityEngine;
using Steamworks;

namespace HutongGames.PlayMaker.Actions
{
    [ActionCategory("Steamworks.NET - Client")]
    [Tooltip("Activate the gameoverlay With a selected website")]
    public class Steam_ActivateGameOverlayToWebPage : FsmStateAction
    {
        [RequiredField]
        [Tooltip("full address with protocol type is required, e.g. http://www.jinxtergames.com/")]
        public FsmString url;

        public override void OnEnter()
        {
            if (!Application.isEditor)
            {
                SteamFriends.ActivateGameOverlayToWebPage((string)url.Value);
            }
            else
            {
                Debug.LogWarning("Steam Overlay does not work in editor mode");
                Finish();
            }
            Finish();
        }
    }
}
#endif