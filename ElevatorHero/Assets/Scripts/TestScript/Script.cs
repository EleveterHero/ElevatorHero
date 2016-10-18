using UnityEngine;

public class Script : MonoBehaviour {

	void OnGUI()
	{
		if(GUI.Button(new Rect(10,100,100,50),"BGM1"))
		{
			AudioManager.Instance.PlayBGM("bgm1");
		}
		if(GUI.Button(new Rect(110,100,100,50),"BGM2"))
		{
			AudioManager.Instance.PlayBGM("bgm2");
		}
		if(GUI.Button(new Rect(210,100,100,50),"BGMSTOP"))
		{
			AudioManager.Instance.StopBGM();
		}
		if(GUI.Button(new Rect(10,200,100,50),"se1"))
		{
			AudioManager.Instance.PlaySE("se1");
		}
		if(GUI.Button(new Rect(110,200,100,50),"se2"))
		{
			AudioManager.Instance.PlaySE("se2");
		}
		if(GUI.Button(new Rect(210,200,100,50),"se3"))
		{
			AudioManager.Instance.PlaySE("se3");
		}
		if(GUI.Button(new Rect(310,200,100,50),"SESTOP"))
		{
			AudioManager.Instance.StopSE();
		}

	}
}
