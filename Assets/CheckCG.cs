using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckCG : MonoBehaviour {

    public GameObject flr;
    public GameObject box;
    public GameObject cyl;
    GameObject floor, boxes, cylinder;
    int bn = 1, cn = 1;

    //public CubeSafety _CubeSafety;
    float dist12 = 0, dist23 = 0, dist34 = 0, dist45 = 0, dist56 = 0;
    float CGX = 0, CGZ = 0;
    public int MC1w = 1, MC2w = 1, MC3w = 1, MC4w = 1, MC5w = 1, MC6w = 1;
    public float TotalDist;
    GameObject MCCG;

    // Use this for initialization
    void Start () {

        MCCG = Instantiate(cyl, new Vector3(CGX, 0.05f, CGZ), Quaternion.identity) as GameObject;
        MCCG.name = MCCG.name.Replace("(Clone)", "");
        MCCG.name = "Machines' CG";
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown("f"))
        {
            floor = Instantiate(flr, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
            floor.name = floor.name.Replace("(Clone)", "");
            floor.name = "floor";
        }
        if (Input.GetKeyDown("b"))
        {
            boxes = Instantiate(box, new Vector3(0, 0.25f, 0), Quaternion.identity) as GameObject;
            boxes.name = boxes.name.Replace("(Clone)", "");
            boxes.name = "MC" + bn;
            bn = bn + 1;
        }

        if (bn >= 2)
        {
            GameObject MC1 = GameObject.Find("MC1");
            CGX = (MC1.transform.position.x) / 1;
            CGZ = (MC1.transform.position.z) / 1;
        }
        if (bn >= 3)
        {
            GameObject MC1 = GameObject.Find("MC1");
            GameObject MC2 = GameObject.Find("MC2");
            dist12 = Vector3.Distance(MC1.transform.position, MC2.transform.position);
            //Debug.Log("Distance MC1 to MC2 is " + dist12);
            CGX = (MC1.transform.position.x*MC1w + MC2.transform.position.x*MC2w) / (MC1w+MC2w);
            CGZ = (MC1.transform.position.z*MC1w + MC2.transform.position.z*MC2w) / (MC1w+MC2w);
            MCCG.transform.position = new Vector3(CGX, 0.05f, CGZ);
        }
        if (bn >= 4)
        {
            GameObject MC1 = GameObject.Find("MC1");
            GameObject MC2 = GameObject.Find("MC2");
            GameObject MC3 = GameObject.Find("MC3");
            dist23 = Vector3.Distance(MC2.transform.position, MC3.transform.position);
            //Debug.Log("Distance MC2 to MC3 is " + dist23);
            CGX = (MC1.transform.position.x * MC1w + MC2.transform.position.x * MC2w + MC3.transform.position.x * MC3w) / (MC1w + MC2w + MC3w);
            CGZ = (MC1.transform.position.z * MC1w + MC2.transform.position.z * MC2w + MC3.transform.position.z * MC3w) / (MC1w + MC2w + MC3w);
            MCCG.transform.position = new Vector3(CGX, 0.05f, CGZ);
        }
        if (bn >= 5)
        {
            GameObject MC1 = GameObject.Find("MC1");
            GameObject MC2 = GameObject.Find("MC2");
            GameObject MC3 = GameObject.Find("MC3");
            GameObject MC4 = GameObject.Find("MC4");
            dist34 = Vector3.Distance(MC3.transform.position, MC4.transform.position);
            //Debug.Log("Distance MC3 to MC4 is " + dist34);
            CGX = (MC1.transform.position.x * MC1w + MC2.transform.position.x * MC2w + MC3.transform.position.x * MC3w + MC4.transform.position.x * MC4w) / (MC1w + MC2w + MC3w + MC4w);
            CGZ = (MC1.transform.position.z * MC1w + MC2.transform.position.z * MC2w + MC3.transform.position.z * MC3w + MC4.transform.position.z * MC4w) / (MC1w + MC2w + MC3w + MC4w);
            MCCG.transform.position = new Vector3(CGX, 0.05f, CGZ);
        }
        if (bn >= 6)
        {
            GameObject MC1 = GameObject.Find("MC1");
            GameObject MC2 = GameObject.Find("MC2");
            GameObject MC3 = GameObject.Find("MC3");
            GameObject MC4 = GameObject.Find("MC4");
            GameObject MC5 = GameObject.Find("MC5");
            dist45 = Vector3.Distance(MC4.transform.position, MC5.transform.position);
            //Debug.Log("Distance MC4 to MC5 is " + dist45);
            CGX = (MC1.transform.position.x * MC1w + MC2.transform.position.x * MC2w + MC3.transform.position.x * MC3w + MC4.transform.position.x * MC4w + MC5.transform.position.x * MC5w) / (MC1w + MC2w + MC3w + MC4w + MC5w);
            CGZ = (MC1.transform.position.z * MC1w + MC2.transform.position.z * MC2w + MC3.transform.position.z * MC3w + MC4.transform.position.z * MC4w + MC5.transform.position.z * MC5w) / (MC1w + MC2w + MC3w + MC4w + MC5w);
            MCCG.transform.position = new Vector3(CGX, 0.05f, CGZ);
        }
        if (bn >= 7)
        {
            GameObject MC1 = GameObject.Find("MC1");
            GameObject MC2 = GameObject.Find("MC2");
            GameObject MC3 = GameObject.Find("MC3");
            GameObject MC4 = GameObject.Find("MC4");
            GameObject MC5 = GameObject.Find("MC5");
            GameObject MC6 = GameObject.Find("MC6");
            dist56 = Vector3.Distance(MC5.transform.position, MC6.transform.position);
            //Debug.Log("Distance MC4 to MC5 is " + dist45);
            CGX = (MC1.transform.position.x * MC1w + MC2.transform.position.x * MC2w + MC3.transform.position.x * MC3w + MC4.transform.position.x * MC4w + MC5.transform.position.x * MC5w + MC6.transform.position.x * MC6w) / (MC1w + MC2w + MC3w + MC4w + MC5w + MC6w);
            CGZ = (MC1.transform.position.z * MC1w + MC2.transform.position.z * MC2w + MC3.transform.position.z * MC3w + MC4.transform.position.z * MC4w + MC5.transform.position.z * MC5w + MC6.transform.position.z * MC6w) / (MC1w + MC2w + MC3w + MC4w + MC5w + MC6w);
            MCCG.transform.position = new Vector3(CGX, 0.05f, CGZ);
        }
        
        TotalDist = dist12 + dist23 + dist34 + dist45 + dist56;
        Debug.Log("Total distance is " + TotalDist);


        Debug.Log("CG is " + CGX + ", " + CGZ);

    }
}
