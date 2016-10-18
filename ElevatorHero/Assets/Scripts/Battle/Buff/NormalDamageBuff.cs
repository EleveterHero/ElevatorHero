using UnityEngine;
using System.Collections;

public class NormalDamageBuff : Buff {

    HeroController controller = null;

    HeroManager manager;

    override public void Init()
    {

        try { controller = target_status.GetComponent<HeroController>(); }
        catch { Debug.Log("statusがセットされていないか、存在していません。また、ヒーローコントローラーが存在しない可能性もあります。"); }

        manager = target_status.GetComponent<HeroManager>();


        target_status.got = true;

        buff_time_sec = 1.0f;
        manager.ShotAnimation(HeroManager.HeroAnimState.damage);
        
    }

    // Update is called once per frame
    override public void Update()
    {

        if (controller)
        {
            controller.move = false;
        }

        if ((buff_time_sec + start_time) <= Time.time)
        {
            parentlist.Remove(this);
        }

    }

    override public void End()
    {
        manager.ShotAnimation(HeroManager.HeroAnimState.walking);
        target_status.got = false;
        controller.move = true;
    }
}
