using UnityEngine;
using System.Collections;

public class Ice : MonoBehaviour {

    

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.tag == "Player")
        {        
            coll.GetComponent<Status>().AddBuff(new IceBuff());

            Destroy(gameObject);
        }
        Debug.Log("ICEHit!!");
    }
}
