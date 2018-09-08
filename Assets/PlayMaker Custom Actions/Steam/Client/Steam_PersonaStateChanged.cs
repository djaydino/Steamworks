// (c) Copyright HutongGames, LLC 2010-2018. All rights reserved.
// Made by djaydino -- http://www.jinxtergames.com/ --
/*--- __ECO__ __PLAYMAKER__ __ACTION__ ---*/
using UnityEngine;
using Steamworks;


namespace HutongGames.PlayMaker.Actions
{
    [ActionCategory("Steamworks.NET Callbacks")]
    [Tooltip("Steam server time.  Number of seconds since January 1, 1970, GMT (i.e unix time)")]
    public class Steam_PersonaStateChanged : FsmStateAction
    {

        [Tooltip("Where to send the event.")]
        public FsmEventTarget eventTarget;

        [Tooltip("Send this event when Clicked.")]
        public FsmEvent sendEvent;

        private bool stateChanged;

        public override void Reset()
        {
            sendEvent = null;
        }

        protected Callback<PersonaStateChange_t> m_PersonaStateChange;

        public override void OnPreprocess()
        {
            m_PersonaStateChange = Callback<PersonaStateChange_t>.Create(OnPersonaStateChange);
        }

        public void OnPersonaStateChange(PersonaStateChange_t pCallback)
        {
            Fsm.Event(eventTarget, sendEvent);
        }
    }
}
