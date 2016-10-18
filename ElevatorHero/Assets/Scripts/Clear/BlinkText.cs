using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class BlinkText : MonoBehaviour {

	public GameObject text;

	[SerializeField]
	private float blinkTimeStart;
	[SerializeField]
	private float blinkTimeEnd;

	private bool isChangeBlink;
	// Use this for initialization
	void Start () {
		isChangeBlink = false;
	}
	
	// Update is called once per frame
	void Update () {

		if (isChangeBlink) {
			BlinkEnd (3);
		} else {
			BlinkStart (2);
		}
	}

	void BlinkStart(int time)
	{
		if (blinkTimeStart < 0.0f) {
			text.SetActive (true);
			blinkTimeEnd = time;
		}
		blinkTimeStart -= Time.deltaTime;
	}

	void BlinkEnd(int time)
	{
		if (blinkTimeEnd < 0.0f) {
			text.SetActive(false);
			blinkTimeStart = time;
		}
		blinkTimeEnd -= Time.deltaTime;
	}
}
