// (c) Copyright HutongGames, LLC 2010-2018. All rights reserved.
// Made by djaydino -- http://www.jinxtergames.com/ --
/*--- __ECO__ __PLAYMAKER__ __ACTION__ ---*/

using UnityEngine;
using Steamworks;

namespace HutongGames.PlayMaker.Actions
{
    [ActionCategory("Steamworks.NET - Client")]
    [Tooltip("signal Steam that game files seems corrupt or missing")]
    public class _Steam_MarkContentCorrupt : FsmStateAction
    {
        [Tooltip("mark as missing file only")]
        public FsmBool missingFilesOnly;

        public override void Reset()
        {
            missingFilesOnly = false;
        }

        public override void OnEnter()
        {
            SteamApps.MarkContentCorrupt(missingFilesOnly.Value);
            Finish();
        }

    }
}
