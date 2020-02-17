// (c) Copyright HutongGames, LLC 2010-2018. All rights reserved.
// Made by djaydino -- http://www.jinxtergames.com/ --
/*--- __ECO__ __PLAYMAKER__ __ACTION__ ---*/

using UnityEngine;
using Steamworks;

namespace HutongGames.PlayMaker.Actions
{
    [ActionCategory("Steamworks.NET - Client")]
    [Tooltip("Returns the number of DLC's for the running app")]
    public class Steam_GetDLCCount : FsmStateAction
    {

        [RequiredField]
        [UIHint(UIHint.Variable)]
        public FsmInt result;

#if !DISABLESTEAMWORKS
        public override void Reset()
        {
            result = null;
        }

        public override void OnEnter()
        {
            result.Value = SteamApps.GetDLCCount();
            Finish();
        }
#endif
    }
}
