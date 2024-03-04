using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.IO;
using System;
using System.Runtime.InteropServices;

public class CSVLineBalancingAutoTCT : MonoBehaviour
{

    // Define the product class
    public class Product
    {
        public string Name;
        public float CycleTime;
    }

    // Define the workstation class
    public class Workstation
    {
        public List<Product> Products = new List<Product>();
        public float CycleTimeCapacity = 0;

        public float TotalCycleTime()
        {
            float total = 0;
            foreach (Product product in Products)
            {
                total += product.CycleTime;
            }
            return total;
        }
    }

    //Import the dll file put in Assets\Plugins
    //Used to make the openning dialog windows
    [DllImport("System.Windows.Forms.dll")]
    private static extern void SaveFileDialog();
    public string fileToSave = "";

    //Save File Function
    private void SaveFile()
    {
        System.Windows.Forms.SaveFileDialog Save = new System.Windows.Forms.SaveFileDialog();
        Save.InitialDirectory = Application.dataPath + "/../_Data/Results";
        Save.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
        Save.ShowDialog();
        fileToSave = Save.FileName;
    }

    public int countsend = 0;
    public int NoOfTable = 0, NoOfCycle = 0;
    public float TotalTime;
    public float DifferentTime;
    float maxTime, minTime;

    // Use this for initialization
    void Start()
    {
        GameObject thePlayer = GameObject.Find("Check collision");
        ArrangeTableAR ArrangeTableScript = thePlayer.GetComponent<ArrangeTableAR>();
        int mmax = ArrangeTableScript.SetNo;
        NoOfTable = mmax;

        var listA = new List<string>();
        var listB = new List<string>();
        using (var reader = new StreamReader("@/../_Data/Input/Product_range.csv"))
        {
            while (!reader.EndOfStream)
            {
                var values = reader.ReadLine().Split(',');
                listA.Add(values[0]);
                listB.Add(values[1]);

            }
        }

        var dataproduct = listA.Skip(1);
        var datatime = listB.Skip(1);

        //System.IO.File.WriteAllLines(@"LineBalancingcol1.csv", dataproduct.ToArray());
        //System.IO.File.WriteAllLines(@"LineBalancingcol2.csv", datatime.ToArray());
        // Sample products with cycle times

        // Sample products with cycle times
        /*
        List<Product> products = new List<Product>()
        {
            new Product { Name = "PartA1", CycleTime = 18.08f },
            new Product { Name = "PartA2", CycleTime = 18.08f },
            new Product { Name = "PartA3", CycleTime = 17.6f },
            new Product { Name = "PartA4", CycleTime = 17.6f },
            new Product { Name = "PartA5", CycleTime = 8.38f },
            new Product { Name = "PartA6", CycleTime = 8.38f },
            new Product { Name = "PartA7", CycleTime = 7.81f },
            new Product { Name = "PartA8", CycleTime = 7.81f },
            new Product { Name = "PartA9", CycleTime = 17.28f },
            new Product { Name = "PartA10", CycleTime = 17.28f },
            new Product { Name = "PartA11", CycleTime = 19.05f },
            new Product { Name = "PartA12", CycleTime = 19.05f },
            new Product { Name = "PartA13", CycleTime = 7.01f },
            new Product { Name = "PartA14", CycleTime = 7.01f },
            new Product { Name = "PartA15", CycleTime = 9.19f },
            new Product { Name = "PartA16", CycleTime = 9.19f },
            new Product { Name = "PartA17", CycleTime = 9.36f },
            new Product { Name = "PartA18", CycleTime = 9.36f },
            new Product { Name = "PartA19", CycleTime = 12.23f },
            new Product { Name = "PartA20", CycleTime = 12.23f },
            new Product { Name = "PartB1", CycleTime = 12.43f },
            new Product { Name = "PartB2", CycleTime = 12.43f },
            new Product { Name = "PartB3", CycleTime = 12.43f },
            new Product { Name = "PartB4", CycleTime = 12.43f },
            new Product { Name = "PartB5", CycleTime = 12.43f },
            new Product { Name = "PartB6", CycleTime = 12.43f },
            new Product { Name = "PartB7", CycleTime = 12.43f },
            new Product { Name = "PartB8", CycleTime = 12.43f },
            new Product { Name = "PartB9", CycleTime = 12.43f },
            new Product { Name = "PartB10", CycleTime = 12.43f },
            new Product { Name = "PartB1", CycleTime = 12.43f },
            new Product { Name = "PartB12", CycleTime = 12.43f },
            new Product { Name = "PartB13", CycleTime = 8.72f },
            new Product { Name = "PartB14", CycleTime = 8.72f },
            new Product { Name = "PartB15", CycleTime = 8.72f },
            new Product { Name = "PartB16", CycleTime = 8.72f },
            // Add more products as needed
        };
        */
        List<Product> products = new List<Product>();
        for (int i=1; i<listA.Count; i++)
        {
            products.Add(new Product() { Name = listA[i], CycleTime = float.Parse(listB[i]) * 60 });
        }

        // Arrange products into workstations
        List<Workstation> workstations = BalanceProductionLine(products, NoOfTable);


        fileToSave = "@/../_Data/Results/Compute/Sim_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".csv";
        System.IO.File.WriteAllText(fileToSave, " ");

        // Display the arrangement
        for (int i = 0; i < workstations.Count; i++)
        {
            //Debug.Log("Workstation " + (i + 1) + ":");
            foreach (Product product in workstations[i].Products)
            {
                //Debug.Log(product.Name + " - Cycle Time: " + product.CycleTime);
                string texti = product.Name +", "+ product.CycleTime + ", " ;
                System.IO.File.AppendAllText(fileToSave, texti);
            }
            System.IO.File.AppendAllText(fileToSave, "\n");
            if(i == 0)
            {
                minTime = workstations[i].TotalCycleTime();
                maxTime = workstations[i].TotalCycleTime();
            }
            else
            {
                if (workstations[i].TotalCycleTime() < minTime)
                {
                    minTime = workstations[i].TotalCycleTime();
                }
                if (workstations[i].TotalCycleTime() > minTime)
                {
                    maxTime = workstations[i].TotalCycleTime();
                }
            }
            //Debug.Log("Total Cycle Time: " + workstations[i].TotalCycleTime());
            //Debug.Log("");
        }

        DifferentTime = (maxTime - minTime)/60;
    }

    // Function to arrange products into workstations with line balancing algorithm
    public List<Workstation> BalanceProductionLine(List<Product> products, int workstationCount)
    {
        List<Workstation> workstations = new List<Workstation>();
        for (int i = 0; i < workstationCount; i++)
        {
            workstations.Add(new Workstation());
        }

        foreach (Product product in products)
        {
            Workstation minWorkstation = null;
            float minCycleTime = float.MaxValue;
            foreach (Workstation workstation in workstations)
            {
                if (workstation.CycleTimeCapacity + product.CycleTime < minCycleTime)
                {
                    minWorkstation = workstation;
                    minCycleTime = workstation.CycleTimeCapacity + product.CycleTime;
                }
            }

            minWorkstation.Products.Add(product);
            minWorkstation.CycleTimeCapacity += product.CycleTime;
        }

        return workstations;
    }

    // Update is called once per frame
    void Update()
    {

    }
}


