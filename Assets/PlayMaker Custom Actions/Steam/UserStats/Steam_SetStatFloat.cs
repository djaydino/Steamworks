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
    [Tooltip("Set a Stat float Value")]
    public class Steam_SetStatFloat : FsmStateAction

    {
        [RequiredField]
        public FsmString statAPIname;

        public FsmFloat floatData;

        public FsmEvent success;

        public FsmEvent failed;

        public override void Reset()
        {
            statAPIname = null;
            floatData = null;
        }

        public override void OnEnter()
        {
            bool isSucces = SteamUserStats.SetStat((string)statAPIname.Value, (float)floatData.Value);
            if (isSucces)
            {
                bool storeStats = SteamUserStats.StoreStats();

                if(storeStats)
                {
                    Fsm.Event(success);
                }
                else
                {
                    Fsm.Event(failed);
                }
            }
            else
            {
                Fsm.Event(failed);
            }
            Finish();
        }
    }
}
#endif