// (c) Copyright HutongGames, LLC 2010-2018. All rights reserved.
// Made by djaydino -- http://www.jinxtergames.com/ --
/*--- __ECO__ __PLAYMAKER__ __ACTION__ ---*/
#if !DISABLESTEAMWORKS
using UnityEngine;
using Steamworks;
using System;

namespace HutongGames.PlayMaker.Actions
{
    [ActionCategory("Steamworks.NET - UserStats")]
    [Tooltip("Gets Achievement information")]
    public class Steam_CreateLeaderboard : FsmStateAction

    {
        [Tooltip("Sets Stat int information")]
        public FsmString LeaderboardName;

        public override void Reset()
        {
            LeaderboardName = null;
        }

        public override void OnEnter()
        {
            Finish();
        }
    }
}
#endif