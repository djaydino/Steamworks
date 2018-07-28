// (c) Copyright HutongGames, LLC 2010-2018. All rights reserved.
// Made by djaydino -- http://www.jinxtergames.com/ --
/*--- __ECO__ __PLAYMAKER__ __ACTION__ ---*/

using UnityEngine;
using Steamworks;
using System;

namespace HutongGames.PlayMaker.Actions
{
    [ActionCategory("Steamworks.NET - UserStats")]
    [Tooltip("Sets Stat int information")]
    public class Steam_SetStatInt : FsmStateAction

    {
        [RequiredField]
        public FsmString statAPIname;

        public FsmInt intData;

        public FsmEvent success;

        public FsmEvent failed;


        public override void Reset()
        {
            statAPIname = null;
            intData = null;
        }

        public override void OnEnter()
        {
            bool isSucces = SteamUserStats.SetStat((string)statAPIname.Value, (int)intData.Value);
            if (isSucces)
            {
                bool storeStats = SteamUserStats.StoreStats();

                if (storeStats)
                {
                    Fsm.Event(success);
                }
                else
                {
                    Fsm.Event(failed);
                }
            }

            Finish();
        }
    }
}
