using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatePlane : MonoBehaviour {

    public GameObject flr;
    public GameObject box;
    public GameObject cyl;
    GameObject floor, boxes, cylinder;
    int bn = 1, cn = 1;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
        if (Input.GetKeyDown("f"))
        {
            floor = Instantiate(flr, new Vector3(0,0,0), Quaternion.identity) as GameObject;
            floor.name = floor.name.Replace("(Clone)", "");
            floor.name = "floor";
        }
        if (Input.GetKeyDown("b"))
        {
            boxes = Instantiate(box, new Vector3(0, 0.05f, 0), Quaternion.identity) as GameObject;
            boxes.name = boxes.name.Replace("(Clone)", "");
            boxes.name = "box" + bn;
            bn = bn + 1;
        }
        if (Input.GetKeyDown("c"))
        {
            cyl = Instantiate(cyl, new Vector3(0, 0.05f, 0), Quaternion.identity) as GameObject;
            cyl.name = cyl.name.Replace("(Clone)", "");
            cyl.name = "cyl" + cn;
            cn = cn + 1;
        }
    }
}
