using UnityEngine;
using System.Collections;

public class IceBuff : Buff {

    HeroController controller = null;

    HeroManager manager;

	override public void Init()
    {

        try { controller = target_status.GetComponent<HeroController>(); }
        catch { Debug.Log("statusがセットされていないか、存在していません。また、ヒーローコントローラーが存在しない可能性もあります。"); }


        manager = target_status.GetComponent<HeroManager>();

        if (manager)
        {
            manager.ShotAnimation(HeroManager.HeroAnimState.freeze);
        }

        buff_time_sec = 2.0f;
    }



    // Update is called once per frame
    override public void Update () {

        if (controller)
        {
            controller.move = false;
        }




        if ((buff_time_sec+start_time) <= Time.time)
        {
            parentlist.Remove(this);
        }

	}

    override public void End()
    {
        if (manager)
        {
            manager.ShotAnimation(HeroManager.HeroAnimState.walking);
        }

        if (controller)
        {
            controller.move = true;
        }

    }
}
