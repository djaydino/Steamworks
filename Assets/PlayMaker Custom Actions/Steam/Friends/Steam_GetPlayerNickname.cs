// (c) Copyright HutongGames, LLC 2010-2018. All rights reserved.
// Made by djaydino -- http://www.jinxtergames.com/ --
/*--- __ECO__ __PLAYMAKER__ __ACTION__ ---*/

using UnityEngine;
using Steamworks;
using System;

namespace HutongGames.PlayMaker.Actions
{
    [ActionCategory("Steamworks.NET - Friends")]
    [Tooltip("Get the nickname that the current user has set for the specified user.")]
    public class Steam_GetPlayerNickname : FsmStateAction
    {
        [RequiredField]
        public FsmString steamID;

        [RequiredField]
        [UIHint(UIHint.Variable)]
        public FsmString playerNickName;

        public FsmEvent nickNameSet;
        public FsmEvent noNickNameSet;

        public override void Reset()
        {
            playerNickName = null;
            steamID = null;
        }

        public override void OnEnter()
        {
            ulong ID = ulong.Parse(this.steamID.Value);
            CSteamID IDsteam;
            IDsteam.m_SteamID = ID;
            string nickname = (string)SteamFriends.GetPlayerNickname(IDsteam);
            if (nickname != null && nickname != "")
            {
                playerNickName.Value = nickname;
                Fsm.Event(nickNameSet);
            }
            else Fsm.Event(noNickNameSet); 
            Finish();
        }
    }
}
