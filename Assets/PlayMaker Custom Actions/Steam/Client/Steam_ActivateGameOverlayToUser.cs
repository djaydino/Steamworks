// (c) Copyright HutongGames, LLC 2010-2018. All rights reserved.
// Made by djaydino -- http://www.jinxtergames.com/ --
/*--- __ECO__ __PLAYMAKER__ __ACTION__ ---*/

using UnityEngine;
using Steamworks;

namespace HutongGames.PlayMaker.Actions
{
    [ActionCategory("Steamworks.NET - Client")]
    [Tooltip("")]
    public class Steam_ActivateGameOverlayToUser : FsmStateAction
    {
        public enum OverlayType
        {
            steamid,
            chat,
            jointrade,
            stats,
            achievements,
            friendadd,
            friendremove,
            friendrequestaccept,
            friendrequestignore
        }

        [RequiredField]
        [Tooltip("Friends SteamID")]
        public FsmString steamID;

        [Tooltip("Select avatar size to load. Warning!! Many users do not have Large avatars")]
        public OverlayType overlayType = OverlayType.achievements;

        public override void Reset()
        {
            steamID = null;
        }

        public override void OnEnter()
        {
            ulong ID = ulong.Parse(this.steamID.Value);
            CSteamID IDsteam;
            IDsteam.m_SteamID = ID;
            SteamFriends.ActivateGameOverlayToUser(overlayType.ToString(), IDsteam);
            Debug.Log(overlayType.ToString());
            Finish();
        }

    }
}
