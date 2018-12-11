
using Steamworks;

public static class PlayMakerSteamExtensions
{
    public static int m_ControllerActionSetHandleAsInt(this ControllerActionSetHandle_t st)
    {
        return (int)st.m_ControllerActionSetHandle;
    }
}
