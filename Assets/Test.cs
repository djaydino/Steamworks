using UnityEngine;
using Steamworks;

public class Test : MonoBehaviour {


    protected Callback<PersonaStateChange_t> m_PersonaStateChange;

    private void OnEnable()
    {
        m_PersonaStateChange = Callback<PersonaStateChange_t>.Create(OnPersonaStateChange);
    }

    void OnPersonaStateChange(PersonaStateChange_t pCallback)
    {
        Debug.Log("Script state Changed");
    }
}
