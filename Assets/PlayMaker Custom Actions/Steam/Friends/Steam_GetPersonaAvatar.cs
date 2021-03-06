// (c) Copyright HutongGames, LLC 2010-2018. All rights reserved.
// Made by djaydino -- http://www.jinxtergames.com/ --
/*--- __ECO__ __PLAYMAKER__ __ACTION__ ---*/
#if !DISABLESTEAMWORKS
using UnityEngine;
using Steamworks;
using System;

namespace HutongGames.PlayMaker.Actions
{
    [ActionCategory("Steamworks.NET - Friends")]
    [Tooltip("Returns avatar from  the current user.")]
    public class Steam_GetPersonaAvatar : FsmStateAction
    {

        public enum AvaterSize
        {
            Small,
            Medium,
            Large
        }
        protected Callback<AvatarImageLoaded_t> m_AvatarImageLoaded;
        private int imageID;

        [Tooltip("Select avatar size to load. Warning!! Many users do not have Large avatars")]
        public AvaterSize avatarSize = AvaterSize.Small;

        [RequiredField]
        [UIHint(UIHint.Variable)]
        public FsmTexture avatar;

        public FsmEvent noAvatar;
        public FsmEvent imageNotLoadedYet;

        public override void Reset()
        {
            avatar = null;
        }

        public override void OnEnter()
        {
            imageID = 0;

            switch (avatarSize)
            {
                case AvaterSize.Small:
                    imageID = SteamFriends.GetSmallFriendAvatar(SteamUser.GetSteamID());
                    break;
                case AvaterSize.Medium:
                    imageID = SteamFriends.GetMediumFriendAvatar(SteamUser.GetSteamID());

                    break;
                case AvaterSize.Large:
                    imageID = SteamFriends.GetLargeFriendAvatar(SteamUser.GetSteamID());

                    break;
            }
            if (imageID != 0)
            {
                if(imageID != -1) GetAvatar(imageID);
                else
                {
                    m_AvatarImageLoaded = Callback<AvatarImageLoaded_t>.Create(OnAvatarImageLoaded);
                    Fsm.Event(imageNotLoadedYet);
                }
            }
            else Fsm.Event(noAvatar);
            Finish();
        }

        void GetAvatar(int iImage)
        {
            uint ImageWidth, ImageHeight;
            bool success = SteamUtils.GetImageSize(iImage, out ImageWidth, out ImageHeight);
            if (!success)
            {
                Fsm.Event(noAvatar);
            }
            else
            {
                byte[] Image = new byte[ImageWidth * ImageHeight * 4];
                success = SteamUtils.GetImageRGBA(iImage, Image, (int)(ImageWidth * ImageHeight * 4));
                if (success)
                {
                    Texture2D ret = null;
                    ret = new Texture2D((int)ImageWidth, (int)ImageHeight, TextureFormat.RGBA32, false, true);
                    ret.LoadRawTextureData(Image);
                    ret.Apply();
                    avatar.Value = ret;
                }
            }
        }

        void OnAvatarImageLoaded(AvatarImageLoaded_t pCallback)
        {
            GetAvatar(imageID);
        }
    }
}
#endif