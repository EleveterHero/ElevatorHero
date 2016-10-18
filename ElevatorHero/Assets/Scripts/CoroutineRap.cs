using UnityEngine;
using System.Collections;
using System;


public class CoroutineRap : MonoBehaviour {

    static public IEnumerator WaitAction(Action action, float sec)
    {
        yield return new WaitForSeconds(sec);
        action();
    }


   
}
