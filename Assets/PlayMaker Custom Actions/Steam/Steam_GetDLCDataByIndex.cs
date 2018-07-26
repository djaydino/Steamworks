// (c) Copyright HutongGames, LLC 2010-2018. All rights reserved.
// Made by djaydino -- http://www.jinxtergames.com/ --
/*--- __ECO__ __PLAYMAKER__ __ACTION__ ---*/

using UnityEngine;
using Steamworks;
using System;

namespace HutongGames.PlayMaker.Actions
{
    [ActionCategory("Steamworks.NET - Client")]
    [Tooltip("Gets the available game languages from the Client.")]
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

       

        [Tooltip("give an error event if no data")]
        public FsmEvent Error;


        private AppId_t appId_t;
        private bool avBool;
        private string name;
        private int cchNameBufferSize;
        public override void Reset()
        {
            indexDLC = null;
            appID = null;
            available = null;
            name = null;
        }

        public override void OnEnter()
        {
            bool cool = SteamApps.BGetDLCDataByIndex(indexDLC.Value, out appId_t, out avBool, out name, cchNameBufferSize);
            if(cool)
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
