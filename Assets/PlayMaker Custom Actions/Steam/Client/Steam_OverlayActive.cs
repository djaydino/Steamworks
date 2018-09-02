// (c) Copyright HutongGames, LLC 2010-2018. All rights reserved.
// Made by djaydino -- http://www.jinxtergames.com/ --
/*--- __ECO__ __PLAYMAKER__ __ACTION__ ---*/

using UnityEngine;
using Steamworks;

namespace HutongGames.PlayMaker.Actions
{
    [ActionCategory("Steamworks.NET - Client")]
    [Tooltip("")]
    public class Steam_OverlayActive : FsmStateAction
    {
        protected Callback<GameOverlayActivated_t> m_GameOverlayActivated;

        [UIHint(UIHint.Variable)]
        [Tooltip("Set to true if overlay is active")]
        public FsmBool overlayActive;

        public FsmEvent active;

        public FsmEvent notActive;


        public override void Reset()
        {
            overlayActive = null;
        }

        public void OnEnable()
        {
            m_GameOverlayActivated = Callback<GameOverlayActivated_t>.Create(OnGameOverlayActivated);
        }

        private void OnGameOverlayActivated(GameOverlayActivated_t pCallback)
        {
            if (pCallback.m_bActive != 0)
            {
                overlayActive.Value = true;
                Fsm.Event(active);
                Debug.Log("Steam Overlay has been activated");
            }
            else
            {
                overlayActive.Value = false;
                Fsm.Event(notActive);
                Debug.Log("Steam Overlay has been closed");
            }

        }
    }
}
