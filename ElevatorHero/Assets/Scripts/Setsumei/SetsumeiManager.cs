﻿using UnityEngine;
using System.Collections;

public class SetsumeiManager : MonoBehaviour {


	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonUp(0))
        {
            GetComponent<SceneSwitcher>().autofade = false;
            GetComponent<SceneSwitcher>().LoadLevel("battle",0.5f);
            return;
        }
	}
}
