// (c) Copyright HutongGames, LLC 2010-2018. All rights reserved.
// Made by djaydino -- http://www.jinxtergames.com/ --
/*--- __ECO__ __PLAYMAKER__ __ACTION__ ---*/

using UnityEngine;
using Steamworks;
using System;

namespace HutongGames.PlayMaker.Actions
{
    [ActionCategory("Steamworks.NET - Friends")]
    [Tooltip("Get a list of your friends SteamID's")]
    public class Steam_GetFriendsSteamIDList : FsmStateAction
    {
        [RequiredField]
        [Tooltip("SteamID array")]
        [UIHint(UIHint.Variable)]
        [ArrayEditor(VariableType.String)]
        public FsmArray steamIDList;

        public override void Reset()
        {
            steamIDList = null;
        }

        public override void OnEnter()
        {
            steamIDList.Resize(0);
            int count = SteamFriends.GetFriendCount(EFriendFlags.k_EFriendFlagImmediate);
            for (int i = 0; i < count; i++)
            {
                CSteamID ID = SteamFriends.GetFriendByIndex(i, EFriendFlags.k_EFriendFlagImmediate);
                steamIDList.Resize(steamIDList.Length + 1);
                steamIDList.Set(steamIDList.Length - 1, ID.ToString());
            }
            Finish();
        }
    }
}
