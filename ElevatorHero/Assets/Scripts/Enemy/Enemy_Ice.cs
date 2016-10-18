using UnityEngine;
using System.Collections;

public class Enemy_Ice : Enemy_Base {

    

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        
	if(anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
        {
            Debug.Log("down");
            AllDestroy();
        }
	}

    void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.tag == "Player")
        {
            coll.gameObject.GetComponent<Status>().Damage(1);
        }
        Debug.Log("Hit!!");
    }
}
