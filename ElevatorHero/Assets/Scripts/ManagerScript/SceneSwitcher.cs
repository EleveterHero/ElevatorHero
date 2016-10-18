using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour {

    FadeManager m_fademanader = null;

    public FadeManager fademanager
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

    bool m_started_func = false;

    public bool started
    {
        get
        {
            return m_started_func;
        }
    }


    public string next_level_name = "title";
    public float interval = 0.5f;
    public bool autofade = true;



    public void LoadLevel()
    {
        if (m_started_func)
        {
            return;
        }

        if(fademanager == null)
        {
            Debug.Log("<color=red>FadeManagerがワールドに存在しません</color>");
            return;
        }



        m_started_func = true;

        //Scene next = SceneManager.GetSceneByName(next_level_name);
        

        fademanager.LoadLevel(next_level_name, this.interval);
       

    }

    public void LoadLevel(string _levelname)
    {
        next_level_name = _levelname;
        LoadLevel();
        return;
    }

    public void LoadLevel(float _interval)
    {
        this.interval = _interval;
        LoadLevel();
        return;
    }

    public void LoadLevel(string _levelname,float _interval)
    {
        next_level_name = _levelname;
        this.interval = _interval;
        LoadLevel();
        return;
    }

}
