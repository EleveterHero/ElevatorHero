using UnityEngine;
using System.Collections;

public class IceBuff : Buff {

    HeroController controller = null;

    bool effecting = false;

    float downspeed = 0.0f;
	override public void Init()
    {

        try { controller = target_status.GetComponent<HeroController>(); }
        catch { Debug.Log("statusがセットされていないか、存在していません。また、ヒーローコントローラーが存在しない可能性もあります。"); }

        if (controller != null)
        {
            downspeed = controller.speed * 0.5f;
            controller.speed -= downspeed;
            effecting = true;
        }

    }

    // Update is called once per frame
    override public void Update () {
	if((buff_time_sec+start_time) <= Time.time)
        {
            parentlist.Remove(this);
        }

	}

    override public void End()
    {
        if(controller != null && effecting)
        {
            controller.speed += downspeed;
            effecting = false;
        }
    }
}
