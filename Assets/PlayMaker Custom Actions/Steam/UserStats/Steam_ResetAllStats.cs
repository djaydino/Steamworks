// (c) Copyright HutongGames, LLC 2010-2018. All rights reserved.
// Made by djaydino -- http://www.jinxtergames.com/ --
/*--- __ECO__ __PLAYMAKER__ __ACTION__ ---*/

using UnityEngine;
using Steamworks;
using System;

namespace HutongGames.PlayMaker.Actions
{
    [ActionCategory("Steamworks.NET - UserStats")]
    [Tooltip("Gets Achievement information")]
    public class Steam_ResetAllStats : FsmStateAction

    {
        [Tooltip("Sets Stat int information")]
        public FsmBool includingAchievements;

        public override void Reset()
        {
            includingAchievements = null;
        }

        public override void OnEnter()
        {
            SteamUserStats.ResetAllStats(includingAchievements.Value);
            Finish();
        }
    }
}