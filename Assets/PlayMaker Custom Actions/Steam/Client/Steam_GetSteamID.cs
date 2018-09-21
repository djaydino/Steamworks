// (c) Copyright HutongGames, LLC 2010-2018. All rights reserved.
// Made by djaydino -- http://www.jinxtergames.com/ --
/*--- __ECO__ __PLAYMAKER__ __ACTION__ ---*/

using UnityEngine;
using Steamworks;

namespace HutongGames.PlayMaker.Actions
{
    [ActionCategory("Steamworks.NET - Client")]
    [Tooltip("Gets the Steam ID of the account currently logged into the Steam client. This is commonly called the 'current user', or 'local user'.")]
    public class Steam_GetSteamID : FsmStateAction
    {
        [RequiredField]
        [UIHint(UIHint.Variable)]
        public FsmString steamID;

        public override void Reset()
        {
            steamID = null;

        }

        public override void OnEnter()
        {
            CSteamID ID = SteamUser.GetSteamID();
            steamID.Value = ID.ToString();
            Finish();
        }
    }
}
