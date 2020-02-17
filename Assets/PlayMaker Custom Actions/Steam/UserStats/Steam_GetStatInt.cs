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
    [Tooltip("Gets stat int information")]
    public class Steam_GetStatInt: FsmStateAction
    {
        [RequiredField]
        public FsmString statAPIname;

        [UIHint(UIHint.Variable)]
        public FsmInt intData;

        public FsmEvent success;

        public FsmEvent failed;

        private int statInt;

        public override void Reset()
        {
            statAPIname = null;
            intData = null;
        }

        public override void OnEnter()
        {
            bool isSucces = SteamUserStats.GetStat((string)statAPIname.Value, out statInt);
            if(isSucces)
            {
                intData.Value = statInt;
                Fsm.Event(success);
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