using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class scoreTest : MonoBehaviour {

	public int score;
	void Start () {
		//スコアを文字列に変換
		GetComponent<Text>().text=((int)score).ToString();
	}
	

	void Update () {
		//
		if (Input.GetKeyDown (KeyCode.A)) {
			//スコアを１加算する
			ScoreManager.Instance.AddScore (1);
		}
		if (Input.GetKeyDown (KeyCode.B)) {
			//スコアを２加算する
			ScoreManager.Instance.AddScore (2);
		}


		//スコアをマネージャーから取り出す
		score = ScoreManager.Instance.Score;

		GetComponent<Text>().text=((int)score).ToString();
	}
}
