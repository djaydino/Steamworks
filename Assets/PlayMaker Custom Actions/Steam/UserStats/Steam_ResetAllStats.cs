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
    [Tooltip("Resets the current users stats and, optionally achievements. \nThis should typically only be used for testing purposes during development.")]
    public class Steam_ResetAllStats : FsmStateAction

    {
        [Tooltip("Also Reset the Achievements")]
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
#endif