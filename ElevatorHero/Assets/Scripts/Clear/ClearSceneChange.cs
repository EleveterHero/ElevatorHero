using UnityEngine;
using System.Collections;

public class ClearSceneChange : MonoBehaviour {

	private static float time=5.0f;

	[SerializeField]
	private bool debugMode = true;

    bool changed = false;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (debugMode) {
			DebugModes ();
		}	


		if (time < 0.0f) 
		{
            if (!changed)
            {
                FadeManager.Instance.LoadLevel("title", 2.0f);
                changed = true;
            }
		}
		time -= Time.deltaTime;
	}


	void DebugModes()
	{
		Debug.Log (time);

	}
}
