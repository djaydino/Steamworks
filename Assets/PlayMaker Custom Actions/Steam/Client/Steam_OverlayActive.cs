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

        [UIHint(UIHint.Variable)]
        [Tooltip("Set to true if overlay is active")]
        public FsmBool result;

       // [Tooltip("Where to send the event.")]
       // public FsmEventTarget eventTargetOne;

        [Tooltip("Send this event when Clicked.")]
        public FsmEvent active;

      //  [Tooltip("Where to send the event.")]
      //  public FsmEventTarget eventTargetTwo;

        [Tooltip("Send this event when Clicked.")]
        public FsmEvent notActive;

        protected Callback<GameOverlayActivated_t> m_GameOverlayActivated;

        public override void Reset()
        {
            result = null;
        }


        public override void OnPreprocess()
        {
            m_GameOverlayActivated = Callback<GameOverlayActivated_t>.Create(OnGameOverlayActivated);
        }

        private void OnGameOverlayActivated(GameOverlayActivated_t pCallback)
        {
            
            if (pCallback.m_bActive != 0)
            {
                result.Value = false;
                Fsm.Event(active);
            }
            else
            {
                result.Value = true;
                Fsm.Event(notActive);
            }
        }
    }
}
