// (c) Copyright HutongGames, LLC 2010-2018. All rights reserved.
// Made by djaydino -- http://www.jinxtergames.com/ --
/*--- __ECO__ __PLAYMAKER__ __ACTION__ ---*/

using UnityEngine;
using Steamworks;

namespace HutongGames.PlayMaker.Actions
{
    [ActionCategory("Steamworks.NET - Client")]
    [Tooltip("")]
    public class Steam_ActivateGameOverlayToWebPage : FsmStateAction
    {

        [RequiredField]
        [Tooltip("full address with protocol type is required, e.g. http://www.steamgames.com/")]
        public FsmString url;

        public override void OnEnter()
        {
            SteamFriends.ActivateGameOverlayToWebPage((string)url.Value);
            Finish();
        }

    }
}
