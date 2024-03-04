using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleScript : MonoBehaviour {
    
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
       
        if (Input.GetAxis("ViveLeftControllerTrackPad") != 0.0f) 
        {
            GameObject CamRig = GameObject.Find("[CameraRig]");
            GameObject ContR = CamRig.transform.FindChild("Controller (right)").gameObject;
            GameObject UI1 = ContR.transform.FindChild("UI (1)").gameObject;
            GameObject Canvasss = UI1.transform.FindChild("Canvas").gameObject;
            Canvasss.SetActive(false);
        }
        if (Input.GetAxis("ViveLeftControllerTrackPad") == 0.0f)
        {
            GameObject CamRig = GameObject.Find("[CameraRig]");
            GameObject ContR = CamRig.transform.FindChild("Controller (right)").gameObject;
            GameObject UI1 = ContR.transform.FindChild("UI (1)").gameObject;
            GameObject Canvasss = UI1.transform.FindChild("Canvas").gameObject;
            Canvasss.SetActive(true);
        }
	}
}
