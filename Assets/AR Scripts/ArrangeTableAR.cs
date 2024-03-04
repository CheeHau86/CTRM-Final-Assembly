using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.SceneManagement;

public class ArrangeTableAR : MonoBehaviour {
    
    public GameObject WorkstationAR;
    GameObject Model_table;
    GameObject Model_No1;
    float xx, zz;
    int table = 1;
    //public int NoOfTable;
    public int SetNo = 8;
    //public float xmin=-1, xmax=1;

    // Use this for initialization
    void Start()
    {
        
        loadOpt();
        //checkOpt();

    }

    // Update is called once per frame
    void Update()
    {
        /*
        SetNo = GameObject.FindGameObjectsWithTag("table").Length;
        GameObject[] ModelChangeName = GameObject.FindGameObjectsWithTag("table");
        for (int a = 0; a < SetNo; a++)
        {
            int b = a + 1;
            ModelChangeName[a].name = "Workstation " + b;
        }
        */
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

        for (zz = -3; zz <= 3; zz = zz + 0.01f)
        {
            for (xx = -6; xx <= 6; xx = xx + 0.01f)
            {
            
            if (!Physics.CheckBox(new Vector3(xx, 0.5f, zz), new Vector3(0.3f, 1.0f, 0.42f), Quaternion.identity) && table <= SetNo)
            {
                    Model_table = Instantiate(WorkstationAR, new Vector3(xx, 0.0f, zz), Quaternion.identity) as GameObject;

                    Model_table.name = Model_table.name.Replace("(Clone)", "");
                    Model_table.name = "Workstation " + table;

                    //Model_table.transform.parent = Model_No1.transform;

                    table = table + 1;
                Debug.Log("donePrint!");
                }
            }
        }
        
        //NoOfTable = table - 1;

}

}
