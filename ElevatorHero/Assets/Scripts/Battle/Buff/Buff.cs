using UnityEngine;
using System.Collections;
using System;


public class Buff
{
    public Status target_status = null;

    public BuffList parentlist = null;

    public string baff_name;
    public int buff_count;
    public float buff_time_sec;
    public float start_time;
    
    virtual public void TimerInit()
    {
        start_time = Time.time;
    }

    virtual public void Init()
    {
        return;
    }

    virtual public void Update()
    {
        return;
    }

    virtual public void End()
    {
        return;
    }

}



