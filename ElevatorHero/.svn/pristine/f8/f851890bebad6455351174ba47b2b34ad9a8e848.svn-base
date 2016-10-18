using UnityEngine;
using System.Collections;

public class Title_BGM : MonoBehaviour {

	// Use this for initialization
	void Start () {
        //何か再生されていたら止める
        AudioManager.Instance.StopBGM();
		AudioManager.Instance.GetComponent<AudioSource> ().loop = true;
        //titleBGMを流す
        AudioManager.Instance.PlayBGM("title");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
