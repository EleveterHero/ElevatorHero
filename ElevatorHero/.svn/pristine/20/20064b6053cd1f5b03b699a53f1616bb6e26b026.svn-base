using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class risltTime : MonoBehaviour {
	private float rltime;
	// Use this for initialization
	void Start () {
		rltime = 0;
	}
	
	// Update is called once per frame
	void Update () {
		rltime += Time.deltaTime;
		if (rltime > 3) {
            SceneManager.LoadScene("main");
		}
	}
}
