// (c) Copyright HutongGames, LLC 2010-2018. All rights reserved.
// Made by djaydino -- http://www.jinxtergames.com/ --
/*--- __ECO__ __PLAYMAKER__ __ACTION__ ---*/
#if !DISABLESTEAMWORKS
using UnityEngine;
using Steamworks;

namespace HutongGames.PlayMaker.Actions
{
    [ActionCategory("Steamworks.NET - Client")]
    [Tooltip("initialize")]
    public class Steam_Init : FsmStateAction
    {
        public override void OnEnter()
        {
            SteamAPI.Init();
            Finish();
        }
    }
}
#endif