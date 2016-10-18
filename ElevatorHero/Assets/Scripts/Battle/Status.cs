using UnityEngine;
using System.Collections;
using System;

public class Status:MonoBehaviour{

    BuffList m_bufflist;
    BuffList bufflist
    {
        get
        {
            if (m_bufflist == null)
            {
                m_bufflist = new BuffList();
            }
            return m_bufflist;
        }
    }

    public bool got = false;

    public bool system_got = false;

    [SerializeField]
    bool m_dead = false;
    public bool dead
    {
        get
        {
            return m_dead;
        }
    }

    public int reset_hp = 3;
    public int max_HP = 3;

    [SerializeField]
    int m_HP = 3;
    public int HP
    {
        get
        {
            return m_HP;
        }
        set
        {
           
            m_HP = Mathf.Clamp(value, 0, max_HP);
            if (m_HP == 0)
            {
                m_dead = true;
            }
            else
            {
                m_dead = false;
            }

        }
    }

    public int max_special = 3;
    [SerializeField]
    int m_Special = 3;

    public int Special
    {
        get
        {
            return m_Special;
        }
        set
        {
            m_Special = Mathf.Clamp(value, 0, max_special);
        }
    }

    public void ResetHP()
    {
       
        HP = reset_hp;

    }

    

    public int Damage(int point)
    {
        if (got || system_got)
        {
            return HP;
        }
        int hitpoint = HP - point;
        HP = Mathf.Clamp(hitpoint, 0, max_HP);

       if(tag == "Player")
        {
            AddBuff(new NormalDamageBuff());
        }

        return HP;
    }

    public void AddBuff(Buff _buff)
    {
        _buff.target_status = this;
        _buff.parentlist = bufflist;
        bufflist.Add(_buff);
    }


    public void Update()
    {
        bufflist.Update();
    }

    public void RemoveBuff(Buff _buff)
    {
        bufflist.Remove(_buff);
    }

}
