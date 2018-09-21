// (c) Copyright HutongGames, LLC 2010-2018. All rights reserved.
// Made by djaydino -- http://www.jinxtergames.com/ --
/*--- __ECO__ __PLAYMAKER__ __ACTION__ ---*/

using UnityEngine;
using Steamworks;
using System;
using System.Collections;

namespace HutongGames.PlayMaker.Actions
{
    [ActionCategory("Steamworks.NET - UserStats")]
    [Tooltip("Get the achievent Icon. WARNING! the image is upside down. Set y scale to -1 or z rotation to 180 on your image to get the right placement")]
    public class Steam_GetAchievementIcon : FsmStateAction

    {
        [RequiredField]
        [Tooltip("The API name from the Achievement")]
        public FsmString achievementAPIname;

        [Tooltip("Number of frames to retry to get the image. average is about 6-15 frames")]
        public FsmInt retryCounter;

        [Tooltip("The achievement image. WARNING! the image is upside down. Set y scale to -1 or z rotation to 180 on your image to get the right placement")]
        [UIHint(UIHint.Variable)]
        [ObjectType(typeof(UnityEngine.Sprite))]
        public FsmObject icon;

        public FsmEvent noImageFound;

        private Coroutine routine;
        private uint icon_width;
        private uint icon_height;

        public override void Reset()
        {
            achievementAPIname = null;
            retryCounter = 100;
            icon = null;
        }

        public override void OnEnter()
        {
            routine = StartCoroutine(_GetAchivementIcon((string)achievementAPIname.Value));
        }

        IEnumerator _GetAchivementIcon(string ID)
        {
            int iconInt = 0;
            int counter = 0;

            while (iconInt <= 0 && counter < retryCounter.Value)
            {
                iconInt = SteamUserStats.GetAchievementIcon(ID);
                counter++;
                yield return null;
            }
            if (iconInt <= 0)
            {
                Fsm.Event(noImageFound);
                Finish();
            }
            else
            {
                SteamUtils.GetImageSize(iconInt, out icon_width, out icon_height);
                byte[] iconStream = new byte[4 * (int)icon_width * (int)icon_height];
                SteamUtils.GetImageRGBA(iconInt, iconStream, 4 * (int)icon_width * (int)icon_height);
                Texture2D downloadIcon = new Texture2D((int)icon_width, (int)icon_height, TextureFormat.RGBA32, false);
                downloadIcon.LoadRawTextureData(iconStream);
                downloadIcon.Apply();
                Sprite spriteTemp = Sprite.Create(downloadIcon, new Rect(0, 0, downloadIcon.width, downloadIcon.height), new Vector2(.5f, .5f));
                Debug.Log(downloadIcon.width + "+" + downloadIcon.height);
                icon.Value = (Sprite)spriteTemp;
                spriteTemp = null;
                Finish();
            }
        }
        public override void OnExit()
        {
            StopCoroutine(routine);
        }
    }
}
