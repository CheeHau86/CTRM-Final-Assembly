using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.SceneManagement;

public class ArrangeTable : MonoBehaviour {
    
    public GameObject Table;
    GameObject Model_table;
    GameObject Model_No1;
    float xx, zz;
    int table = 1;
    //public int NoOfTable;
    public int SetNo = 8;

    // Use this for initialization
    void Start()
    {
        
        loadOpt();
        //checkOpt();

    }

    // Update is called once per frame
    void Update()
    {

        SetNo = GameObject.FindGameObjectsWithTag("table").Length;
        GameObject[] ModelChangeName = GameObject.FindGameObjectsWithTag("table");
        for (int a = 0; a < SetNo; a++)
        {
            int b = a + 1;
            ModelChangeName[a].name = "Workstation " + b;
        }

        if (Input.GetKey("1"))
        {
            ResetApp();
        }

        if (Input.GetKey("escape"))
        {
            QuitApp();
        }

        if (Input.GetKey("a"))
        {
            StartOptProgram();
        }
    }

    public void ResetApp()
    {
        //Application.LoadLevel(Application.loadedLevel);
		//SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		System.Diagnostics.Process.Start(Application.dataPath + "/../ShopfloorOptimization.exe"); 
		Application.Quit();
    }

    public void QuitApp()
    {
        Application.Quit();
    }

    public void StartOptProgram()
    {
        GameObject CSVparent = GameObject.Find("AllCSVScript");
        GameObject CSVgameobj = CSVparent.transform.FindChild("CSV").gameObject;
        CSVgameobj.SetActive(true);
    }

    void loadOpt()
    {

        //for (zz = 0.2f; zz >= -4; zz = zz - 0.2f)
        //{
        zz = -2.0f;
            for (xx = 14; xx >= -13; xx = xx - 0.2f)
            {
                //if (!Physics.CheckCapsule(new Vector3(xx, 1.5f, zz - 1.1f), new Vector3(xx, 1.5f, zz + 1.1f), 1.1f))
                if (!Physics.CheckBox(new Vector3(xx, 0.76f, zz), new Vector3(1.4f, 0.5f, 2.1f), Quaternion.identity) && table <= SetNo) //boxsize was 1.1f, 0.5f, 1.75f
            {
                    Model_table = Instantiate(Table, new Vector3(xx, 0.21f, zz), Quaternion.identity) as GameObject;

                    Model_table.name = Model_table.name.Replace("(Clone)", "");
                    Model_table.name = "Workstation " + table;

                    //Model_table.transform.parent = Model_No1.transform;

                    table = table + 1;
                }
            }
        //}
        
        //NoOfTable = table - 1;

}

}
