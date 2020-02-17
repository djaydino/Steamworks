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
    [Tooltip("Returns the associated launch param if the game is run via steam://run/&lt;appid&gt;//?param1=value1;param2=value2;param3=value3 etc. Parameter names starting with the character '@' are reserved for internal use and will always return and empty string. Parameter names starting with an underscore '_' are reserved for steam features -- they can be queried by the game but it is advised that you not param names beginning with an underscore for your own features.")]
    public class Steam_GetLaunchQueryParam : FsmStateAction
    {

        [ActionSection("Result")]

        [RequiredField]
        [Tooltip("the param")]
        [UIHint(UIHint.Variable)]
        public FsmString param;

        public override void Reset()
        {
            param = null;
        }

        public override void OnEnter()
        {
            
            SteamApps.GetLaunchQueryParam((string)param.Value);

            Finish();
        }

    }
}
#endif