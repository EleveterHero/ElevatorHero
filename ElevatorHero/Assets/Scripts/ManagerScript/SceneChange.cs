using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour {


	//次のシーンの名前
	public static string nextScene;
	// Use this for initialization

	//遷移したかどうかを保存する変数
	bool Moved = false;

	void Start () {
		nextScene = null;
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log (nextScene);
		if ((nextScene != null) && (Moved == false)) {
			Debug.Log ("nextScene name:::" + nextScene);
			//シーンの遷移
			FadeManager.Instance.LoadLevel (nextScene, 2.0f);
			Moved = true;
		}

		if(nextScene == SceneManager.GetActiveScene().name){
			//次のシーンをnull
			nextScene = null;
            Debug.Log(" null or NotNull:::" + nextScene);
			Moved = false;
        }
	}
}
