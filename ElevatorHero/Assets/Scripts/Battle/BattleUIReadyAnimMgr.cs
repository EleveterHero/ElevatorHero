using UnityEngine;
using System.Collections;

public class BattleUIReadyAnimMgr : MonoBehaviour {

 //   bool isRunning = false;

    Animator m_anim = null;
    Animator anim
    {
        get
        {
            if (m_anim == null)
            {
                m_anim = GetComponent<Animator>();
            }
            return m_anim;
        }
    }


    public void ShotReadyAnim()
    {

        anim.Play("Base Layer.BattleUI_Ready");
    }
	 

    public void StopReadyAnim()
    {
        anim.Play("Base Layer.BattleUI_wait");
    }

    double time = 0;
    public void PauseReadyAnim()
    {
        time = anim.GetTime();
        anim.Stop();
    }

    public void StartReadyAnim()
    {
        anim.Play("Base Layer.BattleUI_Ready");
        anim.SetTime(time);
    }
}
