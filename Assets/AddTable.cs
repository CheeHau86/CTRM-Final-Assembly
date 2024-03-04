using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddTable : MonoBehaviour {

    public GameObject Table;
    GameObject Model_table;
    GameObject Model_No1;
    float xx, zz;

    // Use this for initialization
    void Start ()
    {
        zz = 2.1f;
        xx = 10.6f;
    }
	
	// Update is called once per frame
	void Update ()
    {
        
        if (Input.GetKeyDown("q"))
        {

            AddWorkstation();
            
        }
    }

    public void AddWorkstation()
    {
        GameObject thePlayer = GameObject.Find("OptimizationScript");
        ArrangeTable ArrangeTableScript = thePlayer.GetComponent<ArrangeTable>();
        //ArrangeTableScript.SetNo;

        //if (!Physics.CheckCapsule(new Vector3(xx, 1.5f, zz - 1.1f), new Vector3(xx, 1.5f, zz + 1.1f), 1.1f))
        if (!Physics.CheckBox(new Vector3(xx, 0.76f, zz), new Vector3(1.4f, 0.5f, 2.0f), Quaternion.identity)) //boxsize was 1.1f, 0.5f, 1.75f
        {

            Model_table = Instantiate(Table, new Vector3(xx, 0.21f, zz), Quaternion.identity) as GameObject;

            Model_table.name = Model_table.name.Replace("(Clone)", "");
            Model_table.name = "Workstation " + ArrangeTableScript.SetNo;
            ArrangeTableScript.SetNo = ArrangeTableScript.SetNo + 1;

            GameObject[] TableTag = GameObject.FindGameObjectsWithTag("table");
            GameObject LastTable = TableTag[ArrangeTableScript.SetNo - 1];
            xx = LastTable.transform.position.x - 3.0f;
            //Debug.Log("xx " + xx + "zz " + zz);
        }

        else
        {
            Model_table = Instantiate(Table, new Vector3(xx, 0.21f, zz), Quaternion.identity) as GameObject;

            Model_table.name = Model_table.name.Replace("(Clone)", "");
            Model_table.name = "Workstation " + ArrangeTableScript.SetNo;
            ArrangeTableScript.SetNo = ArrangeTableScript.SetNo + 1;

            GameObject[] TableTag = GameObject.FindGameObjectsWithTag("table");
            GameObject LastTable = TableTag[ArrangeTableScript.SetNo - 1];
            xx = LastTable.transform.position.x - 6.0f;
            //Debug.Log("xx " + xx + "zz " + zz);

        }
    }

}
