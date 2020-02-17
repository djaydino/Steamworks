// (c) Copyright HutongGames, LLC 2010-2018. All rights reserved.
// Made by djaydino -- http://www.jinxtergames.com/ --
/*--- __ECO__ __PLAYMAKER__ __ACTION__ ---*/
#if !DISABLESTEAMWORKS
using UnityEngine;
using Steamworks;
using System;

namespace HutongGames.PlayMaker.Actions
{
    [ActionCategory("Steamworks.NET - Friends")]
    [Tooltip("Check If friend is Playing a game and extra info")]
    public class Steam_GetFriendIsPlayingGame : FsmStateAction
    {
        [RequiredField]
        public FsmString steamID;

        [Tooltip("game ID")]
        [UIHint(UIHint.Variable)]
        public FsmString gameName;

        [Tooltip("Maximum string lenght for the game name")]
        public FsmInt maxStringLenght;

        [Tooltip("game ID")]
        [UIHint(UIHint.Variable)]
        public FsmString appID;

        [Tooltip("The IP From the server")]
        [UIHint(UIHint.Variable)]
        public FsmString gameIP;

        [Tooltip("The Game Port From the server")]
        [UIHint(UIHint.Variable)]
        public FsmInt gamePort;

        [Tooltip("The QueryPort From the server")]
        [UIHint(UIHint.Variable)]
        public FsmInt queryPort;

        [Tooltip("The IP From the server")]
        [UIHint(UIHint.Variable)]
        public FsmString steamIDLobby;

        private FriendGameInfo_t friendGameInfo;

        [Tooltip("True if friend is playing a game")]
        [UIHint(UIHint.Variable)]
        public FsmBool isPlaying;

        public FsmEvent yes;
        public FsmEvent no;

        private int statInt;

        public override void Reset()
        {
            appID = null;
            gameName = null;
            steamID = null;
            gameIP = null;
            gamePort = null;
            queryPort = null;
            steamIDLobby = null;
            maxStringLenght = 100;
        }

        public override void OnEnter()
        {

            ulong ID = ulong.Parse(this.steamID.Value);
            CSteamID IDsteam;
            IDsteam.m_SteamID = ID;
            isPlaying.Value = SteamFriends.GetFriendGamePlayed(IDsteam, out friendGameInfo);
            if (isPlaying.Value)
            {
                string gameID = Convert.ToString(friendGameInfo.m_gameID);
                if (appID != null)
                {
                    appID.Value = gameID;
                }
                if (gameName != null && maxStringLenght.Value > 0)
                {
                    string name;
                    int ifNegative = SteamAppList.GetAppName((AppId_t)Convert.ToUInt32(gameID), out name, maxStringLenght.Value);
                    if (ifNegative != -1)
                    {
                        gameName.Value = name;
                    }
                    else
                    {
                        gameName.Value = "No Name";
                    }
                }
                if (gameIP != null)
                {
                    gameIP.Value = Convert.ToString(friendGameInfo.m_unGameIP);
                }
                if (gamePort != null)
                {
                    gamePort.Value = (int)friendGameInfo.m_usGamePort;
                }
                if (queryPort != null)
                {
                    queryPort.Value = (int)friendGameInfo.m_usGamePort;
                }
                if (steamIDLobby != null)
                {
                    steamIDLobby.Value = Convert.ToString(friendGameInfo.m_steamIDLobby);
                }
            }
            Finish();
        }
    }
}
#endif