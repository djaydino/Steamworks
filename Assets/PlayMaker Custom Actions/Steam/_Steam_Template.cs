// (c) Copyright HutongGames, LLC 2010-2018. All rights reserved.
// Made by djaydino -- http://www.jinxtergames.com/ --
/*--- __ECO__ __PLAYMAKER__ __ACTION__ ---*/

using UnityEngine;
using Steamworks;

namespace HutongGames.PlayMaker.Actions
{
    [ActionCategory("Steam")]
    [Tooltip("")]
    public class _Steam_Template : FsmStateAction
    {

        public override void Reset()
        {

        }

        public override void OnEnter()
        {

            Finish();
        }

    }
}
