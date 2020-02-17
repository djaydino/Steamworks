// (c) Copyright HutongGames, LLC 2010-2018. All rights reserved.
// Made by djaydino -- http://www.jinxtergames.com/ --
/*--- __ECO__ __PLAYMAKER__ __ACTION__ ---*/
#if !DISABLESTEAMWORKS
using UnityEngine;
using Steamworks;

namespace HutongGames.PlayMaker.Actions
{
    [ActionCategory("Steamworks.NET - Client")]
    [Tooltip("Check if Steam is in Big Picture Mode")]
    public class Steam_IsSteamInBigPictureMode : FsmStateAction
    {

        public FsmBool isInBigPictureMode;

        public override void Reset()
        {
            isInBigPictureMode = null;
        }

        public override void OnEnter()
        {
            isInBigPictureMode.Value = (bool)SteamUtils.IsSteamInBigPictureMode();
            Finish();
        }
    }
}
#endif