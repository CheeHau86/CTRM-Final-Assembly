using UnityEngine;
using System.Collections;

public class CubeSafety : MonoBehaviour {

    public int x = 1;
    int n = 0;

    public GameObject CubeRed;
    GameObject MC;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
        if (Input.GetKeyDown ("q")){

            if (x < 6)
            {
                MC = Instantiate(CubeRed, new Vector3(n, 5.5f, 0.0f), Quaternion.identity) as GameObject;
                MC.name = MC.name.Replace("(Clone)", "");
                MC.name = "MC" + x;
                n = n + 10;
                x++;
            }
            else { }
            //GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            //cube.transform.position = new Vector3(2*n, 2.5F, 0);
            //cube.transform.localScale = new Vector3(5, 5, 5);
        }
        
    }
}
