// (c) Copyright HutongGames, LLC 2010-2018. All rights reserved.
// Made by djaydino -- http://www.jinxtergames.com/ --
/*--- __ECO__ __PLAYMAKER__ __ACTION__ ---*/

using UnityEngine;
using Steamworks;
using System;

namespace HutongGames.PlayMaker.Actions
{
    [ActionCategory("Steamworks.NET - Client")]
    [Tooltip("Returns metadata for a DLC by index.")]
    public class Steam_GetDLCDataByIndex : FsmStateAction
    {
        [RequiredField]
        public FsmInt indexDLC;

        [RequiredField]
        public FsmInt appID;

        [UIHint(UIHint.Variable)]
        [Tooltip("Returns whether the DLC is currently available.")]
        public FsmBool available;

        [UIHint(UIHint.Variable)]
        [Tooltip("Returns the name of the DLC")]
        public FsmString dlcName;

        public FsmInt cchNameBufferSize;

        [Tooltip("give an error event if no data")]
        public FsmEvent Error;


        private AppId_t appId_t;
        private bool avBool;
        private string name;

        public override void Reset()
        {
            indexDLC = null;
            appID = null;
            available = null;
            name = null;
        }

        public override void OnEnter()
        {
            bool gotData = SteamApps.BGetDLCDataByIndex(indexDLC.Value, out appId_t, out avBool, out name, (int)cchNameBufferSize.Value);
            if(gotData)
            {
                appID.Value = Convert.ToInt32(appId_t);
                available.Value = avBool;
                dlcName.Value = name;
            }
            else
            {
                Fsm.Event(Error);
            }
            Finish();
        }
    }
}
