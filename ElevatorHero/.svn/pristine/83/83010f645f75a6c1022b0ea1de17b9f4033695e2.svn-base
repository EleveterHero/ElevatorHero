using UnityEngine;
using System.Collections;

public class TextObjectSet : MonoBehaviour {
    private static bool setTex = false;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
       // Debug.Log(this.GetComponent<AllSceneChanger>().t_Time);
		if (!setTex) {
			this.GetComponent<AllSceneChanger> ().t_Time = GameObject.Find ("/MainObject/Canvas/Text");
			if (this.GetComponent<AllSceneChanger> ().t_Time != null) {
				setTex = true;
			}
		} else {
			if (SceneChange.nextScene == "Title") {
				setTex = true;
			}
		}
    }
}
