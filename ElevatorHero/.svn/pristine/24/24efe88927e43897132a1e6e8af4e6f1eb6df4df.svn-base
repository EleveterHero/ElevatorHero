using UnityEngine;
using System.Collections;


public class Title_SceneSwitcher : MonoBehaviour {

    FadeManager m_fademanader = null;

    FadeManager fademanager
    {
        get
        {
            if (m_fademanader == null)
            {
                m_fademanader = GameObject.Find("FadeManager").GetComponent<FadeManager>();
                return m_fademanader;
            }
            else
            {
                return m_fademanader;
            }
        }
    }

    public void ChangeScene()
    {
        fademanager.LoadLevel("setsumei",0.5f);
        return;
    }
}
