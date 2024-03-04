using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActivateCanvas : MonoBehaviour {

    private Canvas canvas;
    private Image image;

    // Use this for initialization
    void Start () {

        GameObject thePlayer = GameObject.Find("Check collision");
        ArrangeTableAR ArrangeTableScript = thePlayer.GetComponent<ArrangeTableAR>();

        for (int i = 1; i < ArrangeTableScript.SetNo + 1; i++)
        {
            string ModelName = "Workstation " + i.ToString();

            GameObject WorkstationP = GameObject.Find(ModelName);
            GameObject cvasP = WorkstationP.transform.FindChild("Canvas").gameObject;
            cvasP.SetActive(true);
            GameObject WorkstationC = WorkstationP.transform.FindChild("WorkingTableSmooth").gameObject;
            GameObject cvasC = WorkstationC.transform.FindChild("Canvas").gameObject;
            cvasC.SetActive(true);
        }

    }

    // Update is called once per frame
    void Update () {
		
	}
}
