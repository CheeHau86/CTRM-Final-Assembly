using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Workstation
{
    public List<Product> Products = new List<Product>();
    public float TotalCycleTime { get { return Products.Sum(p => p.CycleTime); } }

}

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

public class productTCT2 : MonoBehaviour {

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
        };
        List<Workstation> workstations = new List<Workstation>();
        for (int i = 0; i < 8; i++)
        {
            workstations.Add(new Workstation());
        }

        // Calculate the total production cycle time
        float totalCycleTime = products.Sum(p => p.CycleTime);

        // Calculate the target cycle time range for each workstation
        float minTargetCycleTime = 0.97f * (totalCycleTime / 8);
        float maxTargetCycleTime = 1.02f * (totalCycleTime / 8);

        // Iterate until all workstations have cycle times within the desired range
        bool isBalanced = false;
        int maxIterations = 100000;
        int iterationCount = 0;

        while (!isBalanced && iterationCount < maxIterations)
        {
            // Shuffle the products randomly
            products = products.OrderBy(_ => UnityEngine.Random.value).ToList();

            // Reset workstations
            foreach (var workstation in workstations)
            {
                workstation.Products.Clear();
            }

            // Assign products to workstations
            foreach (var product in products)
            {
                // Find the workstation with the least total cycle time
                Workstation minWorkstation = workstations.OrderBy(w => w.TotalCycleTime).First();

                // Add the product to the workstation
                minWorkstation.Products.Add(product);
            }

            // Check if all workstations have cycle time within the desired range
            isBalanced = workstations.All(w => w.TotalCycleTime >= minTargetCycleTime && w.TotalCycleTime <= maxTargetCycleTime);

            iterationCount++;
        }

        if (isBalanced)
        {
            // Display the final balanced arrangement
            DisplayWorkstations(workstations);
        }
        else
        {
            Debug.Log("Failed to balance workstations after " + maxIterations + " iterations.");
        }
    }

    // Function to display workstations
    void DisplayWorkstations(List<Workstation> workstations)
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
