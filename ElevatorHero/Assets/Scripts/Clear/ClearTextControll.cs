using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ClearTextControll : MonoBehaviour {

	// Use this for initialization
	void Start () {
		gameObject.GetComponent<RectTransform> ().sizeDelta = new Vector2 (Screen.width,Screen.height);

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
