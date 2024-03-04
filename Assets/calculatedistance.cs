using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class calculatedistance : MonoBehaviour {

    public float distC1 = 0, distC2 = 0, distC3 = 0, distC4 = 0, distC5 = 0, distC6, Totaldist;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        GameObject MCG = GameObject.Find("Machines' CG");
        GameObject MC1 = GameObject.Find("MC1");
        GameObject MC2 = GameObject.Find("MC2");
        GameObject MC3 = GameObject.Find("MC3");
        GameObject MC4 = GameObject.Find("MC4");
        GameObject MC5 = GameObject.Find("MC5");
        distC1 = Vector3.Distance(MCG.transform.position, MC1.transform.position);
        distC2 = Vector3.Distance(MCG.transform.position, MC2.transform.position);
        distC3 = Vector3.Distance(MCG.transform.position, MC3.transform.position);
        distC4 = Vector3.Distance(MCG.transform.position, MC4.transform.position);
        distC5 = Vector3.Distance(MCG.transform.position, MC5.transform.position);
        Totaldist = distC1 + distC2 + distC3 + distC4 + distC5;
    }
}
