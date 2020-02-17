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
    [Tooltip("Checks how many apps the client has installed")]
    public class Steam_GetInstalledApps : FsmStateAction
    {
        [RequiredField]
        [Tooltip("The Steam App Ids to check")]
        [ArrayEditor(VariableType.Int)]
        [UIHint(UIHint.Variable)]
        public FsmArray appIDs;

        [Tooltip("Maximum IDs to add to the array")]
        public FsmInt MaxAppIDs;

        private AppId_t[] theAppIDList;

        public override void Reset()
        {
            appIDs = null;
        }

        public override void OnEnter()
        {
            Debug.Log(appIDs.Length);
            theAppIDList = new AppId_t[appIDs.Length];

            for (int i = 0; i < theAppIDList.Length; i++)
            {
                theAppIDList[1] = (AppId_t)Convert.ToUInt32(appIDs.Get(i));
            }

            uint theList = SteamAppList.GetInstalledApps(theAppIDList, (uint)MaxAppIDs.VariableType);
            Debug.Log(theList);
            Finish();
        }
    }
}
#endif