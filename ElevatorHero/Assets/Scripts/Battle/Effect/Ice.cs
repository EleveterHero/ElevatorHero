using UnityEngine;
using System.Collections;

public class Ice : MonoBehaviour {

    

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.tag == "Player")
        {
            IceBuff ice = new IceBuff();
            ice.buff_time_sec = 1;
            coll.GetComponent<Status>().AddBuff(ice);
            coll.gameObject.GetComponent<Status>().Damage(1);
        }
        Debug.Log("ICEHit!!");
    }
}
