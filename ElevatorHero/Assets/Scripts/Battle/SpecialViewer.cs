using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SpecialViewer : MonoBehaviour {

    Status m_hero_status = null;
    Status hero_status
    {
        get
        {
            if (m_hero_status == null)
            {
                try { m_hero_status = GameObject.Find("GameManager/Hero").GetComponent<HeroManager>().hero_status; }
                catch
                {
                    Debug.Log("オブジェクトが存在しねーぜ");
                }
            }
            return m_hero_status;
        }
    }

    Image[] images;

    int special
    {
        get
        {
            return hero_status.Special;
        }
    }


    void Awake()
    {
        images = GetComponentsInChildren<Image>();
    }

    // Update is called once per frame
    void Update () {
        foreach (Image im in images)
        {
            im.enabled = false;
        }


        if (special - 3 >= 0)
        {
            images[2].enabled = true;
        }
        if (special - 2 >= 0)
        {
            images[1].enabled = true;
        }
        if (special - 1 >= 0)
        {
            images[0].enabled = true;
        }
    }
}
