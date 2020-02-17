// (c) Copyright HutongGames, LLC 2010-2018. All rights reserved.
// Made by djaydino -- http://www.jinxtergames.com/ --
/*--- __ECO__ __PLAYMAKER__ __ACTION__ ---*/
#if !DISABLESTEAMWORKS
using UnityEngine;
using Steamworks;
using System;

namespace HutongGames.PlayMaker.Actions
{
    [ActionCategory("Steamworks.NET - Client")]
    [Tooltip("Gets a list of all installed depots for a given App ID in mount order.")]
    public class Steam_GetInstalledDepots : FsmStateAction
    {
        [RequiredField]
        [Tooltip("The Steam App Id")]
        public FsmInt appID;

        [Tooltip("The Maximum of depots to get")]
        public FsmInt maxDepots;

        [ActionSection("Result")]

        [UIHint(UIHint.Variable)]
        [ArrayEditor(VariableType.Int)]
        public FsmArray depotIds;

        DepotId_t[] depots;

        public override void Reset()
        {
            appID = null;
            maxDepots = null;
            depotIds = null;
        }

        public override void OnEnter()
        {
            
            SteamApps.GetInstalledDepots((AppId_t)Convert.ToUInt32(appID.Value), depots, (uint)maxDepots.Value);

            for (int i = 0; i < depots.Length; i++)
            {
                depotIds.Resize(depotIds.Length + 1);
                depotIds.Set(depotIds.Length - 1, Convert.ToInt32(depots[i]));
            }

            Finish();
        }

    }
}
#endif