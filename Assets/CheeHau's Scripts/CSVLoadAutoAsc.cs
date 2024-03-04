using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.IO;
using System.Runtime.InteropServices;

public class CSVLoadAutoAsc : MonoBehaviour
{

    //Import the dll file put in Assets\Plugins
    //Used to make the openning dialog windows
    [DllImport("System.Windows.Forms.dll")]
    private static extern void OpenFileDialog();

    string fileToLoad = "";
    //public string fileToLoadSorted;

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
    void Start()
    {

        //Open and read the file
        //OpenFile();
        fileToLoad = "@/../_Data/Input/Product_range.csv";
        string[] liness = System.IO.File.ReadAllLines(fileToLoad);

        var data = liness.Skip(1); //skip row 

        var sorted = data.Select(line => new
        {
            SortKey = float.Parse(line.Split(',')[1]) * float.Parse(line.Split(',')[2]), //sort by float in column 1 multiply 2
            Line = line
        })
                    .OrderBy(x => x.SortKey)
                    //.OrderByDescending(x => x.SortKey)
                    .Select(x => x.Line);

        var query = from line in sorted
                    let x = line.Split(',')
                    where float.Parse(x[2]) > 0
                    select line;

        //foreach

        System.IO.File.WriteAllLines("@/../_Data/Input/Product_range_sorted.csv", liness.Take(1).Concat(query).ToArray()); //add line 1, continue the sorted list
        //fileToLoadSorted = System.IO.Path.GetDirectoryName(fileToLoad) + "\\" + System.IO.Path.GetFileNameWithoutExtension(fileToLoad) + "_sorted.csv";
        //System.IO.File.WriteAllLines(fileToLoadSorted, liness.Take(1).Concat(query).ToArray()); //add line 1, continue the sorted list

        

    }

    // Update is called once per frame
    void Update()
    {

    }
}
