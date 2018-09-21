// (c) Copyright HutongGames, LLC 2010-2018. All rights reserved.
// Made by djaydino -- http://www.jinxtergames.com/ --
/*--- __ECO__ __PLAYMAKER__ __ACTION__ ---*/

using UnityEngine;
using Steamworks;
using System;

namespace HutongGames.PlayMaker.Actions
{
    [ActionCategory("Steamworks.NET - UserStats")]
    [Tooltip("Gets Stat float information")]
    public class Steam_GetStatFloat : FsmStateAction

    {
        [RequiredField]
        public FsmString statAPIname;

        [UIHint(UIHint.Variable)]
        public FsmFloat floatData;

        public FsmEvent success;

        public FsmEvent failed;

        private float statFloat;

        public override void Reset()
        {
            statAPIname = null;
            floatData = null;
        }

        public override void OnEnter()
        {
            bool isSucces = SteamUserStats.GetStat((string)statAPIname.Value, out statFloat);
            if (isSucces)
            {
                floatData.Value = statFloat;
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