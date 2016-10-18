using UnityEngine;
using System.Collections;

public class testHoge : MonoBehaviour {
	

	// Use this for initialization
	void Start () {
		var test =new testCSV();
		test.Load ();
		foreach (var testcsv in test.All) {
			Debug.Log (testcsv.Hp);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
