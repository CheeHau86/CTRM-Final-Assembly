using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.IO;
using System;
using System.Runtime.InteropServices;

public class CSVLineBalancing : MonoBehaviour
{

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
        Save.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*" ;
        Save.ShowDialog();
        fileToSave = Save.FileName;
    }

    public int countsend = 0;
    public int NoOfTable = 0, NoOfCycle = 0;
    public float TotalTime;
    public float DifferentTime;

    // Use this for initialization
    void Start()
    {

        GameObject thePlayer = GameObject.Find("OptimizationScript");
        ArrangeTable ArrangeTableScript = thePlayer.GetComponent<ArrangeTable>();
        //ArrangeTableScript.SetNo;
        //if (ArrangeTableScript.SetNo > 8) { ArrangeTableScript.SetNo = 8;  }
        //Debug.Log("Showing Set No = " + ArrangeTableScript.SetNo);
        /*
        string[] linessw = System.IO.File.ReadAllLines(@"Product_range_sorted.csv");

        var dataw = linessw.Skip(1); //skip row 
                                     //System.IO.File.WriteAllLines(@"LineBalancing.csv", dataw.ToArray());

        //dataw contains all text in productrangesortedCSV file, need to split into array "says, value[0], value[1]
        //dataw[1] longest time product, time, prior
        List<string> datawElements = dataw.ToList();
        //datawElements = dataw.Split(',').ToList();
        Debug.Log("Showdataw element = " + datawElements[0] + " " + datawElements[1] + " " + datawElements[2] + " " + datawElements[3]);
        */

        var listA = new List<string>();
        var listB = new List<string>();
        using (var reader = new StreamReader(Application.dataPath + "/Product_range_sorted.csv"))
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

        var prod = dataproduct.ToArray();
        var count = prod.Count();
        var tim = datatime.ToArray();

        countsend = count;
        float[] timMin = new float[count];
        string[] timMinString = new string[count];

        string[] prodtimResult = new string[count];
        for (int i = 0; i < count; i++)
        {
            prodtimResult[i] = prod[i] + ", " + tim[i] + ", ";
        }

        string[] prodtim = new string[count];
        for (int i = 0; i < count; i++)
        {
            timMin[i] = float.Parse(tim[i]) * 60;
            timMinString[i] = timMin[i].ToString();
            prodtim[i] = prod[i] + ", " + timMinString[i] + ", ";
            //prodtim[i] = prod[i] + ", " + tim[i] + ", ";
        }

        int mmax = ArrangeTableScript.SetNo, countcc = 0;
        float nmaxf = (float)count / mmax;
        //Debug.Log("nmaxf = " + nmaxf);
        int nmax = (int)Math.Ceiling(nmaxf);

        NoOfTable = mmax;
        NoOfCycle = nmax;

        string[,] arrayLineBala = new string[mmax, 12];
        string[,] arrayLineBalaTime = new string[mmax, 12];
        string[,] showResult = new string[mmax, 12];
        SaveFile();
        System.IO.File.WriteAllText(fileToSave, " ");
        //string fileResult = System.IO.Path.GetFileNameWithoutExtension(fileToSave) + "_Result.csv";
        //string fileResult = System.IO.Path.ChangeExtension(fileToSave, "_Result.csv");
        string fileResult = System.IO.Path.GetDirectoryName(fileToSave) + "\\" + System.IO.Path.GetFileNameWithoutExtension(fileToSave) + "_Result.csv";
        System.IO.File.WriteAllText(fileResult, " ");

        int[] totalTime1Key = new int[mmax];
        int[] totalTime2Key = new int[mmax];
        int[] totalTime3Key = new int[mmax];
        int[] totalTime4Key = new int[mmax];
        int[] totalTime5Key = new int[mmax];
        int[] totalTime6Key = new int[mmax];
        int[] totalTime7Key = new int[mmax];
        int[] totalTime8Key = new int[mmax];
        int[] totalTime9Key = new int[mmax];
        int[] totalTime10Key = new int[mmax];
        int[] totalTime11Key = new int[mmax];
        float[] totalTime1 = new float[mmax];
        float[] totalTime2 = new float[mmax];
        float[] totalTime3 = new float[mmax];
        float[] totalTime4 = new float[mmax];
        float[] totalTime5 = new float[mmax];
        float[] totalTime6 = new float[mmax];
        float[] totalTime7 = new float[mmax];
        float[] totalTime8 = new float[mmax];
        float[] totalTime9 = new float[mmax];
        float[] totalTime10 = new float[mmax];
        float[] totalTime11 = new float[mmax];

        for (int a = 0; a < mmax; a++)
        {
            //1st column, top down descending
            showResult[a, 0] = prodtimResult[a];
            arrayLineBala[a, 0] = prodtim[a];
            arrayLineBalaTime[a, 0] = tim[a];

            //2nd column onwards, check sum previous column/columns, min to max ascending -> fill
            
        }
/*
    for(int simplified = 1; simplified < 3; simplified++)
        {
            string tTimeKey = "totalTime" + simplified + "Key";
            string tTime = "totalTime" + simplified;

            int[] tTimeKey = new int[mmax];
            float[] tTime = new float[mmax];

            for (int a = 0; a < mmax; a++)
            {
                for (int simplifiedshadow = 1; simplifiedshadow < 3; simplifiedshadow++)
                {
                    tTime[a] = tTime[a] + float.Parse(arrayLineBalaTime[a, simplifiedshadow]);
                }
                tTimeKey[a] = a;
            }

            Array.Sort(tTime, tTimeKey);

            for (int a = 0; a < mmax; a++)
            {
                int b = tTimeKey[a];
                if (simplified * mmax + a + 1 <= count)
                {
                    arrayLineBala[b, simplified] = prodtim[simplified * mmax + a];
                    arrayLineBalaTime[b, simplified] = tim[simplified * mmax + a];
                }
            }
        }
*/
        for (int a = 0; a < mmax; a++)
        {
            totalTime1[a] = float.Parse(arrayLineBalaTime[a, 0]);
            totalTime1Key[a] = a;
        }

        
        Array.Sort(totalTime1, totalTime1Key);

        for (int a = 0; a < mmax; a++)
        {
            int b = totalTime1Key[a];
            if (1 * mmax + a + 1 <= count)
            {
                showResult[b, 1] = prodtimResult[1 * mmax + a];
                arrayLineBala[b, 1] = prodtim[1 * mmax + a];
                arrayLineBalaTime[b, 1] = tim[1 * mmax + a];
            }
            if (1 * mmax + a + 1 > count)
            {
                showResult[b, 1] = "-,-,";
                arrayLineBala[b, 1] = "0,0,";
                arrayLineBalaTime[b, 1] = "0";
                //Debug.Log("min2max: " + totalTime1[a] + " " + "index: " + prodtim[1 * mmax + a + 1] + "\n");
            }
            for (int aa = nmax; aa < 12; aa++)
            {
                arrayLineBala[a, aa] = "0,0,";
                arrayLineBalaTime[a, aa] = "0";
            }
        }


        if (nmax > 2)
        {

            for (int a = 0; a < mmax; a++)
            {
                totalTime2[a] = float.Parse(arrayLineBalaTime[a, 0]) + float.Parse(arrayLineBalaTime[a, 1]);
                totalTime2Key[a] = a;
            }


            Array.Sort(totalTime2, totalTime2Key);

            for (int a = 0; a < mmax; a++)
            {
                int b = totalTime2Key[a];
                if (2 * mmax + a + 1 <= count)
                {
                    showResult[b, 2] = prodtimResult[2 * mmax + a];
                    arrayLineBala[b, 2] = prodtim[2 * mmax + a];
                    arrayLineBalaTime[b, 2] = tim[2 * mmax + a];
                    //Debug.Log("min2max: " + totalTime2[a] + " " + "index: " + prodtim[2 * mmax + a + 1] + "\n");
                }
                if (2 * mmax + a + 1 > count)
                {
                    showResult[b, 2] = "-,-,";
                    arrayLineBala[b, 2] = "0,0,";
                    arrayLineBalaTime[b, 2] = "0";
                    //Debug.Log("min2max: " + totalTime2[a] + " " + "index: " + prodtim[2 * mmax + a + 1] + "\n");
                }
                for (int aa = nmax; aa < 12; aa++)
                {
                    arrayLineBala[a, aa] = "0,0,";
                    arrayLineBalaTime[a, aa] = "0";
                }
            }
        }

        if (nmax > 3)
        {

            for (int a = 0; a < mmax; a++)
            {
                totalTime3[a] = float.Parse(arrayLineBalaTime[a, 0]) + float.Parse(arrayLineBalaTime[a, 1]) + float.Parse(arrayLineBalaTime[a, 2]);
                //totalTime3[a] = totalTime2[a] + float.Parse(arrayLineBalaTime[a, 2]);
                //Debug.Log(totalTime3[a] + "\n");
                totalTime3Key[a] = a;
            }


            Array.Sort(totalTime3, totalTime3Key);

            for (int a = 0; a < mmax; a++)
            {
                int b = totalTime3Key[a];
                if (3 * mmax + a + 1 <= count)
                {
                    showResult[b, 3] = prodtimResult[3 * mmax + a];
                    arrayLineBala[b, 3] = prodtim[3 * mmax + a];
                    arrayLineBalaTime[b, 3] = tim[3 * mmax + a];
                    //Debug.Log("min2max: " + totalTime3[a] + " " + "index: " + prodtim[3 * mmax + a + 1] + "\n");
                }
                if (3 * mmax + a + 1 > count)
                {
                    showResult[b, 3] = "-,-,";
                    arrayLineBala[b, 3] = "0,0,";
                    arrayLineBalaTime[b, 3] = "0";
                    //Debug.Log("min2max: " + totalTime3[a] + " " + "index: " + prodtim[3 * mmax + a + 1] + "\n");
                }
                for (int aa = nmax; aa < 12; aa++)
                {
                    arrayLineBala[a, aa] = "0,0,";
                    arrayLineBalaTime[a, aa] = "0";
                }
            }
        }

        if (nmax > 4)
        {
            for (int a = 0; a < mmax; a++)
            {

                totalTime4[a] = float.Parse(arrayLineBalaTime[a, 0]) + float.Parse(arrayLineBalaTime[a, 1]) + float.Parse(arrayLineBalaTime[a, 2]) + float.Parse(arrayLineBalaTime[a, 3]);
                totalTime4Key[a] = a;
            }

            
            Array.Sort(totalTime4, totalTime4Key);

            for (int a = 0; a < mmax; a++)
            {
                int b = totalTime4Key[a];
                if (4 * mmax + a + 1 <= count)
                {
                    showResult[b, 4] = prodtimResult[4 * mmax + a];
                    arrayLineBala[b, 4] = prodtim[4 * mmax + a];
                    arrayLineBalaTime[b, 4] = tim[4 * mmax + a];
                    //Debug.Log("min2max: " + totalTime4[a] + " " + "index: " + prodtim[4 * mmax + a + 1] + "\n");
                }
                if (4 * mmax + a + 1 > count)
                {
                    showResult[b, 4] = "-,-,";
                    arrayLineBala[b, 4] = "0,0,";
                    arrayLineBalaTime[b, 4] = "0";
                    //Debug.Log("min2max: " + totalTime4[a] + " " + "index: " + prodtim[4 * mmax + a + 1] + "\n");
                }
                for (int aa = nmax; aa < 12; aa++)
                {
                    arrayLineBala[a, aa] = "0,0,";
                    arrayLineBalaTime[a, aa] = "0";
                }
            }
        }

        if (nmax > 5)
        {
        for (int a = 0; a < mmax; a++)
        {

            totalTime5[a] = float.Parse(arrayLineBalaTime[a, 0]) + float.Parse(arrayLineBalaTime[a, 1]) + float.Parse(arrayLineBalaTime[a, 2]) + float.Parse(arrayLineBalaTime[a, 3]) + float.Parse(arrayLineBalaTime[a, 4]);
            totalTime5Key[a] = a;
        }

            
            Array.Sort(totalTime5, totalTime5Key);

        for (int a = 0; a < mmax; a++)
        {
            int b = totalTime5Key[a];
            if (5 * mmax + a + 1 <= count)
            {
                showResult[b, 5] = prodtimResult[5 * mmax + a];
                arrayLineBala[b, 5] = prodtim[5 * mmax + a];
                arrayLineBalaTime[b, 5] = tim[5 * mmax + a];
                //Debug.Log("min2max: " + totalTime5[a] + " " + "index: " + prodtim[5 * mmax + a + 1] + "\n");
            }
            if (5 * mmax + a + 1 > count)
            {
                    showResult[b, 5] = "-,-,";
                    arrayLineBala[b, 5] = "0,0,";
                arrayLineBalaTime[b, 5] = "0";
                //Debug.Log("min2max: " + totalTime5[a] + " " + "index: " + prodtim[5 * mmax + a + 1] + "\n");
            }
                for (int aa = nmax; aa < 12; aa++)
                {
                    arrayLineBala[a, aa] = "0,0,";
                    arrayLineBalaTime[a,aa] = "0";
                }
            }
        }

        if (nmax > 6)
        {
        for (int a = 0; a < mmax; a++)
        {

            totalTime6[a] = float.Parse(arrayLineBalaTime[a, 0]) + float.Parse(arrayLineBalaTime[a, 1]) + float.Parse(arrayLineBalaTime[a, 2]) + float.Parse(arrayLineBalaTime[a, 3]) + float.Parse(arrayLineBalaTime[a, 4]) + float.Parse(arrayLineBalaTime[a, 5]);
            totalTime6Key[a] = a;
        }

            
            Array.Sort(totalTime6, totalTime6Key);

        for (int a = 0; a < mmax; a++)
        {
            int b = totalTime6Key[a];
            if (6 * mmax + a + 1 <= count)
            {
                showResult[b, 6] = prodtimResult[6 * mmax + a];
                arrayLineBala[b, 6] = prodtim[6 * mmax + a];
                arrayLineBalaTime[b, 6] = tim[6 * mmax + a];
                //Debug.Log("min2max: " + totalTime6[a] + " " + "index: " + prodtim[6 * mmax + a + 1] + "\n");
            }
            if (6 * mmax + a + 1 > count)
            {
                    showResult[b, 6] = "-,-,";
                    arrayLineBala[b, 6] = "0,0,";
                arrayLineBalaTime[b, 6] = "0";
                //Debug.Log("min2max: " + totalTime6[a] + " " + "index: " + prodtim[6 * mmax + a + 1] + "\n");
            }
                for (int aa = nmax; aa < 12; aa++)
                {
                    arrayLineBala[a, aa] = "0,0,";
                    arrayLineBalaTime[a, aa] = "0";
                }
            }
        }

        if (nmax > 7)
        {
        for (int a = 0; a < mmax; a++)
        {

            totalTime7[a] = float.Parse(arrayLineBalaTime[a, 0]) + float.Parse(arrayLineBalaTime[a, 1]) + float.Parse(arrayLineBalaTime[a, 2]) + float.Parse(arrayLineBalaTime[a, 3]) + float.Parse(arrayLineBalaTime[a, 4]) + float.Parse(arrayLineBalaTime[a, 5]) + float.Parse(arrayLineBalaTime[a, 6]);
            totalTime7Key[a] = a;
        }

        Array.Sort(totalTime7, totalTime7Key);

        for (int a = 0; a < mmax; a++)
        {
            int b = totalTime7Key[a];
            if (7 * mmax + a + 1 <= count)
            {
                showResult[b, 7] = prodtimResult[7 * mmax + a];
                arrayLineBala[b, 7] = prodtim[7 * mmax + a];
                arrayLineBalaTime[b, 7] = tim[7 * mmax + a];
                //Debug.Log("min2max: " + totalTime7[a] + " " + "index: " + prodtim[7 * mmax + a + 1] + "\n");
            }
            if (7 * mmax + a + 1 > count)
            {
                    showResult[b, 7] = "-,-,";
                    arrayLineBala[b, 7] = "0,0,";
                arrayLineBalaTime[b, 7] = "0";
                //Debug.Log("min2max: " + totalTime7[a] + " " + "index: " + prodtim[7 * mmax + a + 1] + "\n");
            }
                for (int aa = nmax; aa < 12; aa++)
                {
                    arrayLineBala[a, aa] = "0,0,";
                    arrayLineBalaTime[a, aa] = "0";
                }
            }
        }

        if (nmax > 8)
        {
        for (int a = 0; a < mmax; a++)
        {

            totalTime8[a] = float.Parse(arrayLineBalaTime[a, 0]) + float.Parse(arrayLineBalaTime[a, 1]) + float.Parse(arrayLineBalaTime[a, 2]) + float.Parse(arrayLineBalaTime[a, 3]) + float.Parse(arrayLineBalaTime[a, 4]) + float.Parse(arrayLineBalaTime[a, 5]) + float.Parse(arrayLineBalaTime[a, 6]) + float.Parse(arrayLineBalaTime[a, 7]);
            totalTime8Key[a] = a;
        }

        Array.Sort(totalTime8, totalTime8Key);

        for (int a = 0; a < mmax; a++)
        {
            int b = totalTime8Key[a];
            if (8 * mmax + a + 1 <= count)
            {
                showResult[b, 8] = prodtimResult[8 * mmax + a];
                arrayLineBala[b, 8] = prodtim[8 * mmax + a];
                arrayLineBalaTime[b, 8] = tim[8 * mmax + a];
                //Debug.Log("min2max: " + totalTime8[a] + " " + "index: " + prodtim[8 * mmax + a + 1] + "\n");
            }
            if (8 * mmax + a + 1 > count)
            {
                    showResult[b, 8] = "-,-,";
                    arrayLineBala[b, 8] = "0,0,";
                arrayLineBalaTime[b, 8] = "0";
                //Debug.Log("min2max: " + totalTime8[a] + " " + "index: " + prodtim[8 * mmax + a + 1] + "\n");
            }
                for (int aa = nmax; aa < 12; aa++)
                {
                    arrayLineBala[a, aa] = "0,0,";
                    arrayLineBalaTime[a, aa] = "0";
                }
            }
        }

        if (nmax > 9)
        {
        for (int a = 0; a < mmax; a++)
        {

            totalTime9[a] = float.Parse(arrayLineBalaTime[a, 0]) + float.Parse(arrayLineBalaTime[a, 1]) + float.Parse(arrayLineBalaTime[a, 2]) + float.Parse(arrayLineBalaTime[a, 3]) + float.Parse(arrayLineBalaTime[a, 4]) + float.Parse(arrayLineBalaTime[a, 5]) + float.Parse(arrayLineBalaTime[a, 6]) + float.Parse(arrayLineBalaTime[a, 7]) + float.Parse(arrayLineBalaTime[a, 8]);
            totalTime9Key[a] = a;
        }

        Array.Sort(totalTime9, totalTime9Key);

        for (int a = 0; a < mmax; a++)
        {
            int b = totalTime9Key[a];
            if (9 * mmax + a + 1 <= count)
            {
                showResult[b, 9] = prodtimResult[9 * mmax + a];
                arrayLineBala[b, 9] = prodtim[9 * mmax + a];
                arrayLineBalaTime[b, 9] = tim[9 * mmax + a];
                //Debug.Log("min2max: " + totalTime9[a] + " " + "index: " + prodtim[9 * mmax + a + 1] + "\n");
            }
            if (9 * mmax + a + 1 > count)
            {
                showResult[b, 9] = "-,-,";
                arrayLineBala[b, 9] = "0,0,";
                arrayLineBalaTime[b, 9] = "0";
                //Debug.Log("min2max: " + totalTime9[a] + " " + "index: " + prodtim[9 * mmax + a + 1] + "\n");
            }
                for (int aa = nmax; aa < 12; aa++)
                {
                    arrayLineBala[a, aa] = "0,0,";
                    arrayLineBalaTime[a, aa] = "0";
                }
            }
        }

        if (nmax > 10)
        {
        for (int a = 0; a < mmax; a++)
        {

            totalTime10[a] = float.Parse(arrayLineBalaTime[a, 0]) + float.Parse(arrayLineBalaTime[a, 1]) + float.Parse(arrayLineBalaTime[a, 2]) + float.Parse(arrayLineBalaTime[a, 3]) + float.Parse(arrayLineBalaTime[a, 4]) + float.Parse(arrayLineBalaTime[a, 5]) + float.Parse(arrayLineBalaTime[a, 6]) + float.Parse(arrayLineBalaTime[a, 7]) + float.Parse(arrayLineBalaTime[a, 8]) + float.Parse(arrayLineBalaTime[a, 9]);
            totalTime10Key[a] = a;
        }

        Array.Sort(totalTime10, totalTime10Key);

        for (int a = 0; a < mmax; a++)
        {
            int b = totalTime10Key[a];
            if (10 * mmax + a + 1 <= count)
            {
                showResult[b, 10] = prodtimResult[10 * mmax + a];
                arrayLineBala[b, 10] = prodtim[10 * mmax + a];
                arrayLineBalaTime[b, 10] = tim[10 * mmax + a];
                //Debug.Log("min2max: " + totalTime10[a] + " " + "index: " + prodtim[10 * mmax + a + 1] + "\n");
            }
            if (10 * mmax + a + 1 > count)
            {
                showResult[b, 10] = "-,-,";
                arrayLineBala[b, 10] = "0,0,";
                arrayLineBalaTime[b, 10] = "0";
                //Debug.Log("min2max: " + totalTime10[a] + " " + "index: " + prodtim[10 * mmax + a + 1] + "\n");
            }
                for (int aa = nmax; aa < 12; aa++)
                {
                    arrayLineBala[a, aa] = "0,0,";
                    arrayLineBalaTime[a, aa] = "0";
                }
            }
        }
        if (nmax > 11)
        {
        for (int a = 0; a < mmax; a++)
        {

            totalTime11[a] = float.Parse(arrayLineBalaTime[a, 0]) + float.Parse(arrayLineBalaTime[a, 1]) + float.Parse(arrayLineBalaTime[a, 2]) + float.Parse(arrayLineBalaTime[a, 3]) + float.Parse(arrayLineBalaTime[a, 4]) + float.Parse(arrayLineBalaTime[a, 5]) + float.Parse(arrayLineBalaTime[a, 6]) + float.Parse(arrayLineBalaTime[a, 7]) + float.Parse(arrayLineBalaTime[a, 8]) + float.Parse(arrayLineBalaTime[a, 9]) + float.Parse(arrayLineBalaTime[a, 10]);
            totalTime11Key[a] = a;
        }

        Array.Sort(totalTime11, totalTime11Key);

        for (int a = 0; a < mmax; a++)
        {
            int b = totalTime11Key[a];
            if (11 * mmax + a + 1 <= count)
            {
                showResult[b, 11] = prodtimResult[11 * mmax + a];
                arrayLineBala[b, 11] = prodtim[11 * mmax + a];
                arrayLineBalaTime[b, 11] = tim[11 * mmax + a];
                //Debug.Log("min2max: " + totalTime11[a] + " " + "index: " + prodtim[11 * mmax + a + 1] + "\n");
            }
            if (11 * mmax + a + 1 > count)
            {
                    showResult[b, 11] = "-,-,";
                    arrayLineBala[b, 11] = "0,0,";
                arrayLineBalaTime[b, 11] = "0";
                //Debug.Log("min2max: " + totalTime11[a] + " " + "index: " + prodtim[11 * mmax + a + 1] + "\n");
            }
            }
        }

        for (int a = 0; a < mmax; a++)
        {
            for (int b = 0; b < 12; b++)
            {
                System.IO.File.AppendAllText(fileToSave, arrayLineBala[a, b]);
                //System.IO.File.AppendAllText(@"LineBalancing.csv", a + ", " + b+ ", "); //show matrix number for verify

                if (b == 11)
                {
                    System.IO.File.AppendAllText(fileToSave, "\n");
                }
            }
        }

        float[] TotalTimeTime = new float[ArrangeTableScript.SetNo];
        
        for (int a = 0; a < mmax; a++)
        {
            float timetime = 0;
            for (int b = 0; b < 12; b++)
            {
                timetime = timetime + float.Parse(arrayLineBalaTime[a, b]);
                TotalTimeTime[a] = timetime;
                
            }
            //Debug.Log("checkc " + TotalTimeTime[a]);
        }

        TotalTime = TotalTimeTime.Max();
        DifferentTime = TotalTimeTime.Max() - TotalTimeTime.Min();

        string someInfo = "No. Of Workstation: ," + mmax + "\n" + " No. Of Cycle: ," + nmax + "\n" + "Total Process Time: ," + TotalTime + "\n" + "Time difference (max - min): ," + DifferentTime + "\n" + "\n" + "Workstation no: ,";

        for (int b = 0; b < nmax; b++)
        {
            int bi = b + 1;
            someInfo = someInfo + "Cycle " + bi + " Product," + "Cycle " + bi + " Time,";
        }

        string lineOne = someInfo + "\n";

        System.IO.File.AppendAllText(fileResult, lineOne);

        for (int a = 0; a < mmax; a++)
        {
            for (int b = 0; b < nmax + 1 ; b++)
            {
                if (b == 0)
                {
                    int ai = a + 1;
                    showResult[a, 0] = "Workstion " + ai + "," + showResult[a, 0];
                    System.IO.File.AppendAllText(fileResult, showResult[a, b]);
                }
                else if (b == nmax)
                {
                    System.IO.File.AppendAllText(fileResult, "\n");
                }
                else
                {
                    System.IO.File.AppendAllText(fileResult, showResult[a, b]);
                    Debug.Log("a is " + b);
                }
            }
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}


