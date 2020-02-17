// (c) Copyright HutongGames, LLC 2010-2018. All rights reserved.
// Made by djaydino -- http://www.jinxtergames.com/ --
/*--- __ECO__ __PLAYMAKER__ __ACTION__ ---*/
#if !DISABLESTEAMWORKS
using UnityEngine;
using Steamworks;

namespace HutongGames.PlayMaker.Actions
{
    [ActionCategory("Steamworks.NET - Client")]
    [Tooltip("Check if the Persona state is changed")]
    public class Steam_PersonaStateChanged : FsmStateAction
    {

        [Tooltip("Where to send the event.")]
        public FsmEventTarget eventTarget;

        public FsmEvent Changed;

        private bool stateChanged;

        public override void Reset()
        {
            Changed = null;
        }

        protected Callback<PersonaStateChange_t> m_PersonaStateChange;

        public override void OnEnter()
        {
            m_PersonaStateChange = Callback<PersonaStateChange_t>.Create(OnPersonaStateChange);
        }

        public void OnPersonaStateChange(PersonaStateChange_t pCallback)
        {
            Fsm.Event(eventTarget, Changed);
        }
    }
}
#endif