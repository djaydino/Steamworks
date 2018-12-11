using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Steamworks;

public class SteamControllerAction : UnityEngine.Object
{
    ControllerActionSetHandle_t ControllerAction;

    public SteamControllerAction (ControllerActionSetHandle_t value)
    {
        ControllerAction = value;
    }

    public int m_ControllerActionSetHandle
    {
        get{
            return (int)ControllerAction.m_ControllerActionSetHandle;
        }
    }
}