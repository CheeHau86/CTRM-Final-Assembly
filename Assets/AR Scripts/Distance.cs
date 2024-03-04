using UnityEngine;
using System.Collections;

public class Distance : MonoBehaviour {

    public CubeSafety _CubeSafety;
    float dist12 = 0, dist23 = 0, dist34 = 0, dist45 = 0;
    float CGX=0, CGZ=0;

    public GameObject CapsuleYellow;
    GameObject MCCG;

    // Use this for initialization
    void Start () {

        MCCG = Instantiate(CapsuleYellow, new Vector3(CGX, 5.0f, CGZ), Quaternion.identity) as GameObject;

    }
	
	// Update is called once per frame
	void Update () {

        if (_CubeSafety.x >= 2)
        {
            GameObject MC1 = GameObject.Find("MC1");
            CGX = (MC1.transform.position.x) / 1;
            CGZ = (MC1.transform.position.z) / 1;
        }
        if (_CubeSafety.x >= 3)
        {
            GameObject MC1 = GameObject.Find("MC1");
            GameObject MC2 = GameObject.Find("MC2");
            dist12 = Vector3.Distance(MC1.transform.position, MC2.transform.position);
            //Debug.Log("Distance MC1 to MC2 is " + dist12);
            CGX = (MC1.transform.position.x + MC2.transform.position.x) / 2;
            CGZ = (MC1.transform.position.z + MC2.transform.position.z) / 2;
            MCCG.transform.position = new Vector3(CGX, 5.0f, CGZ);
        }
        if (_CubeSafety.x >= 4)
        {
            GameObject MC1 = GameObject.Find("MC1");
            GameObject MC2 = GameObject.Find("MC2");
            GameObject MC3 = GameObject.Find("MC3");
            dist23 = Vector3.Distance(MC2.transform.position, MC3.transform.position);
            //Debug.Log("Distance MC2 to MC3 is " + dist23);
            CGX = (MC1.transform.position.x + MC2.transform.position.x + MC3.transform.position.x) / 3;
            CGZ = (MC1.transform.position.z + MC2.transform.position.z + MC3.transform.position.z) / 3;
            MCCG.transform.position = new Vector3(CGX, 5.0f, CGZ);
        }
        if (_CubeSafety.x >= 5)
        {
            GameObject MC1 = GameObject.Find("MC1");
            GameObject MC2 = GameObject.Find("MC2");
            GameObject MC3 = GameObject.Find("MC3");
            GameObject MC4 = GameObject.Find("MC4");
            dist34 = Vector3.Distance(MC3.transform.position, MC4.transform.position);
            //Debug.Log("Distance MC3 to MC4 is " + dist34);
            CGX = (MC1.transform.position.x + MC2.transform.position.x + MC3.transform.position.x + MC4.transform.position.x) / 4;
            CGZ = (MC1.transform.position.z + MC2.transform.position.z + MC3.transform.position.z + MC4.transform.position.z) / 4;
            MCCG.transform.position = new Vector3(CGX, 5.0f, CGZ);
        }
        if (_CubeSafety.x >= 6)
        {
            GameObject MC1 = GameObject.Find("MC1");
            GameObject MC2 = GameObject.Find("MC2");
            GameObject MC3 = GameObject.Find("MC3");
            GameObject MC4 = GameObject.Find("MC4");
            GameObject MC5 = GameObject.Find("MC5");
            dist45 = Vector3.Distance(MC4.transform.position, MC5.transform.position);
            //Debug.Log("Distance MC4 to MC5 is " + dist45);
            CGX = (MC1.transform.position.x + MC2.transform.position.x + MC3.transform.position.x + MC4.transform.position.x + MC5.transform.position.x) / 5;
            CGZ = (MC1.transform.position.z + MC2.transform.position.z + MC3.transform.position.z + MC4.transform.position.z + MC5.transform.position.z) / 5;
            MCCG.transform.position = new Vector3(CGX, 5.0f, CGZ);
        }
        float TotalDist = dist12 + dist23 + dist34 + dist45;
        Debug.Log("Total distance is " + TotalDist);

        
        Debug.Log("CG is " + CGX + ", " + CGZ);


    }
}
