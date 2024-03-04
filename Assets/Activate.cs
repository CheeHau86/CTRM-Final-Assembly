using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Activate : MonoBehaviour {

private Image imgtable1;

	// Use this for initialization
	void Start () {
		gameObject.SetActive (true);

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.X)) {

			gameObject.SetActive (true);
			print ("x");
		} else {
			gameObject.SetActive (false);
		}	
		//}
	}
}
