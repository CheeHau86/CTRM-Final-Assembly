using System.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class productTCTScript : MonoBehaviour {
    public float totalPCycleTime;
    public int noTable = 8; 
    // Define the product class
    public class Product
    {
        public string Name;
        public float CycleTime;

        public Product(string name, float cycleTime)
        {
            Name = name;
            CycleTime = cycleTime;
        }
    }

    // Define the workstation class
    public class Workstation
    {
        public List<Product> Products = new List<Product>();
        public float TotalCycleTime { get { return Products.Sum(p => p.CycleTime); } }

    }

    void Start()
    {
        // Sample products with cycle times
        List<Product> products = new List<Product>()
        {
            new Product ( "Product1", 18.08f ),
            new Product ( "Product2",  18.08f ),
            new Product ( "Product3",  17.6f ),
            new Product ( "Product4",  17.6f ),
            new Product ( "Product5",  8.38f ),
            new Product ( "Product6",  8.38f ),
            new Product ( "Product7",  7.81f ),
            new Product ( "Product8",  7.81f ),
            new Product ( "Product9",  17.28f ),
            new Product ( "Product10",  17.28f ),
            new Product ( "Product11",  19.05f ),
            new Product ( "Product12",  19.05f ),
            new Product ( "Product13",  7.01f ),
            new Product ( "Product14",  7.01f ),
            new Product ( "Product15",  9.19f ),
            new Product ( "Product16",  9.19f ),
            new Product ( "Product17",  9.36f ),
            new Product ( "Product18",  9.36f ),
            new Product ( "Product19",  12.23f ),
            new Product ( "Product20",  12.23f ),
            new Product ( "Product21",  12.43f ),
            new Product ( "Product22",  12.43f ),
            new Product ( "Product23",  12.43f ),
            new Product ( "Product24",  12.43f ),
            new Product ( "Product25",  12.43f ),
            new Product ( "Product26",  12.43f ),
            new Product ( "Product27",  12.43f ),
            new Product ( "Product28",  12.43f ),
            new Product ( "Product29",  12.43f ),
            new Product ( "Product30",  12.43f ),
            new Product ( "Product31",  12.43f ),
            new Product ( "Product32",  12.43f ),
            new Product ( "Product33",  8.72f ),
            new Product ( "Product34",  8.72f ),
            new Product ( "Product35",  8.72f ),
            new Product ( "Product36",  8.72f ),
            // Add more products as needed
        };

        // Arrange products into workstations
        List<Workstation> workstations = BalanceProductionLine(products, noTable);

        // Loop to balance workstations
        int iteration = 1;
        while (!IsWorkstationsBalanced(workstations) && iteration < 100000)
        {
            // Rebalance workstations
            workstations = BalanceProductionLine(products, noTable);
            iteration++;
        }

        if (iteration < 100000) { 
            // Display the final balanced arrangement
            Debug.Log("Iteration:" + iteration);
            Debug.Log("Final balanced arrangement:");
            DisplayWorkstations(workstations);
        }
    }


    // Function to arrange products into workstations with line balancing algorithm
    public List<Workstation> BalanceProductionLine(List<Product> products, int workstationCount)
    {
        // Calculate the total cycle time of all products
        totalPCycleTime = products.Sum(p => p.CycleTime);

        // Calculate the target cycle time for each workstation
        float targetCycleTimePerWorkstation = totalPCycleTime / workstationCount;

        // Initialize workstations
        List<Workstation> workstations = new List<Workstation>();
        for (int i = 0; i < workstationCount; i++)
        {
            workstations.Add(new Workstation());
        }

        // Shuffle the list of products
        products = Shuffle(products);

        // Distribute products to workstations
        foreach (Product product in products)
        {
            // Find the workstation with the least total cycle time
            Workstation minWorkstation = workstations.OrderBy(w => w.TotalCycleTime).First();

            // Add the product to the workstation
            minWorkstation.Products.Add(product);
        }

        return workstations;
    }

    // Function to randomly shuffle a list
    public List<T> Shuffle<T>(List<T> list)
    {
        System.Random rng = new System.Random();
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
        return list;
    }

    // Function to check if workstations are balanced
    private bool IsWorkstationsBalanced(List<Workstation> workstations)
    {
        float minCycleTime = workstations.Min(w => w.TotalCycleTime);
        float maxCycleTime = workstations.Max(w => w.TotalCycleTime);

        // Define a threshold for balance
        float threshold = 2.0f; //0.05f*(totalPCycleTime/noTable);

        // Check if the difference between max and min cycle times is within the threshold
        return maxCycleTime - minCycleTime <= threshold;
    }

    // Function to display workstations
    private void DisplayWorkstations(List<Workstation> workstations)
    {
        for (int i = 0; i < workstations.Count; i++)
        {
            Debug.Log("Workstation " + (i + 1) + ":");
            foreach (Product product in workstations[i].Products)
            {
                Debug.Log(product.Name + " - Cycle Time: " + product.CycleTime);
            }
            Debug.Log("Total Cycle Time: " + workstations[i].TotalCycleTime);
            Debug.Log("");
        }
    }
}
