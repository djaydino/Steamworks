// (c) Copyright HutongGames, LLC 2010-2018. All rights reserved.
// Made by djaydino -- http://www.jinxtergames.com/ --
/*--- __ECO__ __PLAYMAKER__ __ACTION__ ---*/

using UnityEngine;
using Steamworks;

namespace HutongGames.PlayMaker.Actions
{
    [ActionCategory("Steamworks.NET - Client")]
    [Tooltip("Gets the available game languages from the Client")]
    public class Steam_GetAvailableGameLanguages : FsmStateAction
    {
        [RequiredField]
        [UIHint(UIHint.Variable)]
        [ArrayEditor(VariableType.String)]
        public FsmArray stringArray;

        public override void Reset()
        {
            stringArray = null;
        }

        public override void OnEnter()
        {
            stringArray.Values = SteamApps.GetAvailableGameLanguages().Split(",".ToCharArray());
            stringArray.SaveChanges();
            Finish();
        }
    }
}
