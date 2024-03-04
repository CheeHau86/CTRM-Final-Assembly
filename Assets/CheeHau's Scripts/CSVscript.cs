using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.IO;
using System.Runtime.InteropServices;

public class CSVscript : MonoBehaviour {

    //Import the dll file put in Assets\Plugins
    //Used to make the openning dialog windows
    [DllImport("System.Windows.Forms.dll")]
    private static extern void OpenFileDialog();

    string fileToLoad = "";
    public string fileToLoadSorted;

    //Open File Function
    private void OpenFile()
    {
        System.Windows.Forms.OpenFileDialog Open = new System.Windows.Forms.OpenFileDialog();
        Open.InitialDirectory = Application.dataPath + "/../_Data/Input";
        Open.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
        Open.ShowDialog();
        fileToLoad = Open.FileName;
    }

    //private List<dataFile> queryList = new List<dataFile>();

    public class dataFile
    {

        public int proX, proY, prefer;
        public float time;

        public dataFile(int proX, int proY, float time, int prefer)
        {
            
        }
    }

    // Use this for initialization
    void Start() {

        //Open and read the file
        OpenFile();
        string[] liness = System.IO.File.ReadAllLines(fileToLoad);

        var data = liness.Skip(1); //skip row 

        var sorted = data.Select(line => new
        {
            SortKey = float.Parse(line.Split(',')[1]) * float.Parse(line.Split(',')[2]), //sort by float in column 1 multiply 2
            Line = line
        })
                    .OrderByDescending(x => x.SortKey)
                    .Select(x => x.Line);

        var query = from line in sorted
                    let x = line.Split(',')
                    where float.Parse(x[2]) > 0
                    select line;

        //foreach

        System.IO.File.WriteAllLines(Application.dataPath + "/Product_range_sorted.csv", liness.Take(1).Concat(query).ToArray()); //add line 1, continue the sorted list
        //fileToLoadSorted = System.IO.Path.GetDirectoryName(fileToLoad) + "\\" + System.IO.Path.GetFileNameWithoutExtension(fileToLoad) + "_sorted.csv";
        //System.IO.File.WriteAllLines(fileToLoadSorted, liness.Take(1).Concat(query).ToArray()); //add line 1, continue the sorted list

        /*//IEnumerable
        // Create the IEnumerable data source  
        string[] lines = System.IO.File.ReadAllLines(@"Product_range.csv");
        
        // Create the query. Put field 2 first, then  
        // reverse and combine fields 0 and 1 and 3 from the old field  
        IEnumerable<string> query =

            from line in lines
            let x = line.Split(',')
            orderby x[2] descending // descending in string, not float
            select line;

        //select x[2] + ", " + (x[0] + ", " + x[1] + ", " + x[3]);

        // Execute the query and write out the new file. Note that WriteAllLines  
        // takes a string[], so ToArray is called on the query.  
        System.IO.File.WriteAllLines(@"Product_range_sorted.csv", query.ToArray());
        */

        /*//list
        StreamReader reader = new StreamReader(@"Product_range.csv");
        string s = reader.ReadLine();
        char[] delimiter = { ',' };

        string[] fields = s.Split(delimiter);
        int proX = int.Parse(fields[0]);
        int proY = int.Parse(fields[1]);
        float time = float.Parse(fields[2]);
        int prefer = int.Parse(fields[3]);

        dataFile da = new dataFile(proX, proY, time, prefer);
        queryList.Add(da);

        System.IO.File.WriteAllLines(@"Product_range_sortedlist.csv", queryList.ToArray<string>);
        */

        //Console.WriteLine("Spreadsheet2.csv written to disk. Press any key to exit");
        //Console.ReadKey();

    }

    // Update is called once per frame
    void Update () {
		
	}
}
