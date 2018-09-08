// (c) Copyright HutongGames, LLC 2010-2018. All rights reserved.
// Made by djaydino -- http://www.jinxtergames.com/ --
/*--- __ECO__ __PLAYMAKER__ __ACTION__ ---*/

using UnityEngine;
using Steamworks;
using System;

namespace HutongGames.PlayMaker.Actions
{
    [ActionCategory("Steamworks.NET Client")]
    [Tooltip("Steam server time.  Number of seconds since January 1, 1970, GMT (i.e unix time)")]
    public class Steam_GetCurrentBatteryPower : FsmStateAction
    {
        [UIHint(UIHint.Variable)]
        [Tooltip("the result will be between 0 and 100.\nBut if AC power is used, the value will be 255")]
        public FsmInt batteryPercentage;

        [UIHint(UIHint.Variable)]
        [Tooltip("returns true if AC power is used")]
        public FsmBool acPowerUsed;

        public FsmEvent acPowered;
        public FsmEvent batteryPowered;

        public override void Reset()
        {
            batteryPercentage = null;
            acPowerUsed = null;
        }

        public override void OnEnter()
        {
            int batteryLife = (int)SteamUtils.GetCurrentBatteryPower();
            bool isAC = (batteryLife == 255) ? true : false;
            if (batteryPercentage != null) batteryPercentage.Value = batteryLife;
            if (acPowerUsed != null) acPowerUsed.Value = isAC;
            if (isAC)
            {
                Fsm.Event(acPowered);
            }
            else
            {
                Fsm.Event(batteryPowered);
            }
            Finish();
        }
    }
}
