// (c) Copyright HutongGames, LLC 2010-2018. All rights reserved.
// Made by djaydino -- http://www.jinxtergames.com/ --
/*--- __ECO__ __PLAYMAKER__ __ACTION__ ---*/
#if !DISABLESTEAMWORKS
using UnityEngine;
using Steamworks;

namespace HutongGames.PlayMaker.Actions
{
    [ActionCategory("Steamworks.NET - Client")]
    [Tooltip("Activate the User Overlay in a certain overlay type")]
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
        [Tooltip("Users SteamID")]
        public FsmString steamID;

        public OverlayType overlayType = OverlayType.chat;

        public override void Reset()
        {
            steamID = null;
        }

        public override void OnEnter()
        {
            if (!Application.isEditor)
            {
                ulong ID = ulong.Parse(this.steamID.Value);
                CSteamID IDsteam;
                IDsteam.m_SteamID = ID;
                SteamFriends.ActivateGameOverlayToUser(overlayType.ToString(), IDsteam);
            }
            else
            {
                Debug.LogWarning("Steam Overlay does not work in editor mode");
                Finish();
            }
            Finish();
        }
    }
}
#endif