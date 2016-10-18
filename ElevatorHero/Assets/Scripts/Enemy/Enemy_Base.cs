using UnityEngine;
using System.Collections;

public class Enemy_Base : MonoBehaviour {

    [SerializeField]
    Animator m_anim;
    public Animator anim
    {
        get
        {
            if(m_anim == null)
            {
                m_anim = GetComponent<Animator>();
            }
            return m_anim;
        }
        set
        {
            m_anim = value;
        }
    }

    [SerializeField]
    GameObject[] m_chidren;
    public GameObject[] chidren
    {
        get
        {
            if(m_chidren == null)
            {
                m_chidren = transform.parent.gameObject.GetComponentsInChildren<GameObject>();
            }
            return m_chidren;
        }
        set
        {
            m_chidren = value;
        }
    }

   protected void AllDestroy()
    {
        if(transform.parent != null)
        {
            Destroy(transform.parent.gameObject);
        }else
        {
            foreach(GameObject obj in chidren)
            Destroy(obj);
        }
    }


}
