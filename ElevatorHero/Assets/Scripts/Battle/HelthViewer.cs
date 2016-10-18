using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HelthViewer : MonoBehaviour {

    Status m_hero_status = null;
    Status hero_status
    {
        get
        {
            if(m_hero_status == null)
            {
                m_hero_status = GameObject.Find("GameManager/Hero").GetComponent<HeroManager>().hero_status;
            }
            return m_hero_status;
        }
    }

    Image[] images;

    int helth
    {
        get
        {
            return hero_status.HP;
        }
    }

    void Awake()
    {
        images = GetComponentsInChildren<Image>();
    }

	// Update is called once per frame
	void Update () {

        foreach(Image im in images)
        {
            im.enabled = false;
        }


        if (helth - 3 >= 0)
        {
            images[2].enabled = true;
        }
        if (helth - 2 >= 0)
        {
            images[1].enabled = true;
        }
        if (helth - 1 >= 0)
        {
            images[0].enabled = true;
        }
	}
}
