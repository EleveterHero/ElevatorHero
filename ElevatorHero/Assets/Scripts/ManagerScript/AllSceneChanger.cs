using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AllSceneChanger : SingletonMonoBehaviour<AllSceneChanger> {

	public GameObject t_Time;
	//複製防止
	private static bool created=false;

	void Awake()
	{
		//二回目以降作成されない
		if (!created) {
			DontDestroyOnLoad (this);
			created = true;
		} else {
			Destroy (this.gameObject);
		}
	}

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {


		if (SceneChange.nextScene != null) {
			return;
		}

		switch (SceneManager.GetActiveScene().name) {
		case "Title":
			TitleSceneChange ();
			break;
		case "Reserve":
			ReserveSceneChange ();
			break;
		case "Main":
			MainSceneChange ();
			break;
		case "Rank":
			ResultSceneChange ();
			break;
		default:
			break;
		}
	}

	private void TitleSceneChange()
	{

		
	}

	private void ReserveSceneChange()
	{
		//if (Input.GetKeyDown (KeyCode.Return)) {
		//	SceneChange.nextScene="Main";
		//}
	}
    
	private void MainSceneChange()
	{
	
	}

	private void ResultSceneChange()
	{
		
	}
}
