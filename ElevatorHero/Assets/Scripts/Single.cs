﻿using UnityEngine;
using System.Collections;

public class Single : MonoBehaviour {
    void Awake()
    {
        GameObject samename_object = null;
        samename_object = GameObject.Find(gameObject.name);
        if((samename_object != null) && (samename_object != this))
        {
            DestroyObject(gameObject);
            return;
       } 
    }
}
