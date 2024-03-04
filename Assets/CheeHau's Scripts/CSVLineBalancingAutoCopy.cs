using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.IO;
using System;
using System.Runtime.InteropServices;

public class CSVLineBalancingAutoCopy : MonoBehaviour
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
        Save.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
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
        using (var reader = new StreamReader("@/../_Data/Input/Product_range_sorted.csv"))
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

        string[,] arrayLineBala = new string[mmax, 35];
        string[,] arrayLineBalaTime = new string[mmax, 35];
        string[,] showResult = new string[mmax, 35];
        //SaveFile();
        fileToSave = "@/../_Data/Results/Compute/Sim_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".csv";
        System.IO.File.WriteAllText(fileToSave, " ");
        //string fileResult = System.IO.Path.GetFileNameWithoutExtension(fileToSave) + "_Result.csv";
        //string fileResult = System.IO.Path.ChangeExtension(fileToSave, "_Result.csv");
        //string fileResult = System.IO.Path.GetDirectoryName(fileToSave) + "\\" + System.IO.Path.GetFileNameWithoutExtension(fileToSave) + "_Result.csv";
        string fileResult = "@/../_Data/Results/" + System.IO.Path.GetFileNameWithoutExtension(fileToSave) + "_Result.csv";
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
        int[] totalTime12Key = new int[mmax];
        int[] totalTime13Key = new int[mmax];
        int[] totalTime14Key = new int[mmax];
        int[] totalTime15Key = new int[mmax];
        int[] totalTime16Key = new int[mmax];
        int[] totalTime17Key = new int[mmax];
        int[] totalTime18Key = new int[mmax];
        int[] totalTime19Key = new int[mmax];
        int[] totalTime20Key = new int[mmax];
        int[] totalTime21Key = new int[mmax];
        int[] totalTime22Key = new int[mmax];
        int[] totalTime23Key = new int[mmax];
        int[] totalTime24Key = new int[mmax];
        int[] totalTime25Key = new int[mmax];
        int[] totalTime26Key = new int[mmax];
        int[] totalTime27Key = new int[mmax];
        int[] totalTime28Key = new int[mmax];
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
        float[] totalTime12 = new float[mmax];
        float[] totalTime13 = new float[mmax];
        float[] totalTime14 = new float[mmax];
        float[] totalTime15 = new float[mmax];
        float[] totalTime16 = new float[mmax];
        float[] totalTime17 = new float[mmax];
        float[] totalTime18 = new float[mmax];
        float[] totalTime19 = new float[mmax];
        float[] totalTime20 = new float[mmax];
        float[] totalTime21 = new float[mmax];
        float[] totalTime22 = new float[mmax];
        float[] totalTime23 = new float[mmax];
        float[] totalTime24 = new float[mmax];
        float[] totalTime25 = new float[mmax];
        float[] totalTime26 = new float[mmax];
        float[] totalTime27 = new float[mmax];
        float[] totalTime28 = new float[mmax];

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
                    arrayLineBalaTime[a, aa] = "0";
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
        if (nmax > 12)
        {
            for (int a = 0; a < mmax; a++)
            {

                totalTime12[a] = float.Parse(arrayLineBalaTime[a, 0]) + float.Parse(arrayLineBalaTime[a, 1]) + float.Parse(arrayLineBalaTime[a, 2]) + float.Parse(arrayLineBalaTime[a, 3]) + float.Parse(arrayLineBalaTime[a, 4]) + float.Parse(arrayLineBalaTime[a, 5]) + float.Parse(arrayLineBalaTime[a, 6]) + float.Parse(arrayLineBalaTime[a, 7]) + float.Parse(arrayLineBalaTime[a, 8]) + float.Parse(arrayLineBalaTime[a, 9]) + float.Parse(arrayLineBalaTime[a, 10]) + float.Parse(arrayLineBalaTime[a, 11]);
                totalTime12Key[a] = a;
            }

            Array.Sort(totalTime12, totalTime12Key);

            for (int a = 0; a < mmax; a++)
            {
                int b = totalTime12Key[a];
                if (12 * mmax + a + 1 <= count)
                {
                    showResult[b, 12] = prodtimResult[12 * mmax + a];
                    arrayLineBala[b, 12] = prodtim[12 * mmax + a];
                    arrayLineBalaTime[b, 12] = tim[12 * mmax + a];
                    //Debug.Log("min2max: " + totalTime12[a] + " " + "index: " + prodtim[12 * mmax + a + 1] + "\n");
                }
                if (12 * mmax + a + 1 > count)
                {
                    showResult[b, 12] = "-,-,";
                    arrayLineBala[b, 12] = "0,0,";
                    arrayLineBalaTime[b, 12] = "0";
                    //Debug.Log("min2max: " + totalTime12[a] + " " + "index: " + prodtim[12 * mmax + a + 1] + "\n");
                }
            }
        }
        if (nmax > 13)
        {
            for (int a = 0; a < mmax; a++)
            {

                totalTime13[a] = float.Parse(arrayLineBalaTime[a, 0]) + float.Parse(arrayLineBalaTime[a, 1]) + float.Parse(arrayLineBalaTime[a, 2]) + float.Parse(arrayLineBalaTime[a, 3]) + float.Parse(arrayLineBalaTime[a, 4]) + float.Parse(arrayLineBalaTime[a, 5]) + float.Parse(arrayLineBalaTime[a, 6]) + float.Parse(arrayLineBalaTime[a, 7]) + float.Parse(arrayLineBalaTime[a, 8]) + float.Parse(arrayLineBalaTime[a, 9]) + float.Parse(arrayLineBalaTime[a, 10]) + float.Parse(arrayLineBalaTime[a, 11]) + float.Parse(arrayLineBalaTime[a, 12]);
                totalTime13Key[a] = a;
            }

            Array.Sort(totalTime13, totalTime13Key);

            for (int a = 0; a < mmax; a++)
            {
                int b = totalTime13Key[a];
                if (13 * mmax + a + 1 <= count)
                {
                    showResult[b, 13] = prodtimResult[13 * mmax + a];
                    arrayLineBala[b, 13] = prodtim[13 * mmax + a];
                    arrayLineBalaTime[b, 13] = tim[13 * mmax + a];
                    //Debug.Log("min2max: " + totalTime13[a] + " " + "index: " + prodtim[13 * mmax + a + 1] + "\n");
                }
                if (13 * mmax + a + 1 > count)
                {
                    showResult[b, 13] = "-,-,";
                    arrayLineBala[b, 13] = "0,0,";
                    arrayLineBalaTime[b, 13] = "0";
                    //Debug.Log("min2max: " + totalTime13[a] + " " + "index: " + prodtim[13 * mmax + a + 1] + "\n");
                }
            }
        }
        if (nmax > 14)
        {
            for (int a = 0; a < mmax; a++)
            {

                totalTime14[a] = float.Parse(arrayLineBalaTime[a, 0]) + float.Parse(arrayLineBalaTime[a, 1]) + float.Parse(arrayLineBalaTime[a, 2]) + float.Parse(arrayLineBalaTime[a, 3]) + float.Parse(arrayLineBalaTime[a, 4]) + float.Parse(arrayLineBalaTime[a, 5]) + float.Parse(arrayLineBalaTime[a, 6]) + float.Parse(arrayLineBalaTime[a, 7]) + float.Parse(arrayLineBalaTime[a, 8]) + float.Parse(arrayLineBalaTime[a, 9]) + float.Parse(arrayLineBalaTime[a, 10]) + float.Parse(arrayLineBalaTime[a, 11]) + float.Parse(arrayLineBalaTime[a, 12]) + float.Parse(arrayLineBalaTime[a, 13]);
                totalTime14Key[a] = a;
            }

            Array.Sort(totalTime14, totalTime14Key);

            for (int a = 0; a < mmax; a++)
            {
                int b = totalTime14Key[a];
                if (14 * mmax + a + 1 <= count)
                {
                    showResult[b, 14] = prodtimResult[14 * mmax + a];
                    arrayLineBala[b, 14] = prodtim[14 * mmax + a];
                    arrayLineBalaTime[b, 14] = tim[14 * mmax + a];
                    //Debug.Log("min2max: " + totalTime14[a] + " " + "index: " + prodtim[14 * mmax + a + 1] + "\n");
                }
                if (14 * mmax + a + 1 > count)
                {
                    showResult[b, 14] = "-,-,";
                    arrayLineBala[b, 14] = "0,0,";
                    arrayLineBalaTime[b, 14] = "0";
                    //Debug.Log("min2max: " + totalTime14[a] + " " + "index: " + prodtim[14 * mmax + a + 1] + "\n");
                }
            }
        }
        if (nmax > 15)
        {
            for (int a = 0; a < mmax; a++)
            {

                totalTime15[a] = float.Parse(arrayLineBalaTime[a, 0]) + float.Parse(arrayLineBalaTime[a, 1]) + float.Parse(arrayLineBalaTime[a, 2]) + float.Parse(arrayLineBalaTime[a, 3]) + float.Parse(arrayLineBalaTime[a, 4]) + float.Parse(arrayLineBalaTime[a, 5]) + float.Parse(arrayLineBalaTime[a, 6]) + float.Parse(arrayLineBalaTime[a, 7]) + float.Parse(arrayLineBalaTime[a, 8]) + float.Parse(arrayLineBalaTime[a, 9]) + float.Parse(arrayLineBalaTime[a, 10]) + float.Parse(arrayLineBalaTime[a, 11]) + float.Parse(arrayLineBalaTime[a, 12]) + float.Parse(arrayLineBalaTime[a, 13]) + float.Parse(arrayLineBalaTime[a, 14]);
                totalTime15Key[a] = a;
            }

            Array.Sort(totalTime15, totalTime15Key);

            for (int a = 0; a < mmax; a++)
            {
                int b = totalTime15Key[a];
                if (15 * mmax + a + 1 <= count)
                {
                    showResult[b, 15] = prodtimResult[15 * mmax + a];
                    arrayLineBala[b, 15] = prodtim[15 * mmax + a];
                    arrayLineBalaTime[b, 15] = tim[15 * mmax + a];
                    //Debug.Log("min2max: " + totalTime15[a] + " " + "index: " + prodtim[15 * mmax + a + 1] + "\n");
                }
                if (15 * mmax + a + 1 > count)
                {
                    showResult[b, 15] = "-,-,";
                    arrayLineBala[b, 15] = "0,0,";
                    arrayLineBalaTime[b, 15] = "0";
                    //Debug.Log("min2max: " + totalTime15[a] + " " + "index: " + prodtim[15 * mmax + a + 1] + "\n");
                }
            }
        }
        if (nmax > 16)
        {
            for (int a = 0; a < mmax; a++)
            {

                totalTime16[a] = float.Parse(arrayLineBalaTime[a, 0]) + float.Parse(arrayLineBalaTime[a, 1]) + float.Parse(arrayLineBalaTime[a, 2]) + float.Parse(arrayLineBalaTime[a, 3]) + float.Parse(arrayLineBalaTime[a, 4]) + float.Parse(arrayLineBalaTime[a, 5]) + float.Parse(arrayLineBalaTime[a, 6]) + float.Parse(arrayLineBalaTime[a, 7]) + float.Parse(arrayLineBalaTime[a, 8]) + float.Parse(arrayLineBalaTime[a, 9]) + float.Parse(arrayLineBalaTime[a, 10]) + float.Parse(arrayLineBalaTime[a, 11]) + float.Parse(arrayLineBalaTime[a, 12]) + float.Parse(arrayLineBalaTime[a, 13]) + float.Parse(arrayLineBalaTime[a, 14]) + float.Parse(arrayLineBalaTime[a, 15]);
                totalTime16Key[a] = a;
            }

            Array.Sort(totalTime16, totalTime16Key);

            for (int a = 0; a < mmax; a++)
            {
                int b = totalTime16Key[a];
                if (16 * mmax + a + 1 <= count)
                {
                    showResult[b, 16] = prodtimResult[16 * mmax + a];
                    arrayLineBala[b, 16] = prodtim[16 * mmax + a];
                    arrayLineBalaTime[b, 16] = tim[16 * mmax + a];
                    //Debug.Log("min2max: " + totalTime16[a] + " " + "index: " + prodtim[16 * mmax + a + 1] + "\n");
                }
                if (16 * mmax + a + 1 > count)
                {
                    showResult[b, 16] = "-,-,";
                    arrayLineBala[b, 16] = "0,0,";
                    arrayLineBalaTime[b, 16] = "0";
                    //Debug.Log("min2max: " + totalTime16[a] + " " + "index: " + prodtim[16 * mmax + a + 1] + "\n");
                }
            }
        }
        if (nmax > 17)
        {
            for (int a = 0; a < mmax; a++)
            {

                totalTime17[a] = float.Parse(arrayLineBalaTime[a, 0]) + float.Parse(arrayLineBalaTime[a, 1]) + float.Parse(arrayLineBalaTime[a, 2]) + float.Parse(arrayLineBalaTime[a, 3]) + float.Parse(arrayLineBalaTime[a, 4]) + float.Parse(arrayLineBalaTime[a, 5]) + float.Parse(arrayLineBalaTime[a, 6]) + float.Parse(arrayLineBalaTime[a, 7]) + float.Parse(arrayLineBalaTime[a, 8]) + float.Parse(arrayLineBalaTime[a, 9]) + float.Parse(arrayLineBalaTime[a, 10]) + float.Parse(arrayLineBalaTime[a, 11]) + float.Parse(arrayLineBalaTime[a, 12]) + float.Parse(arrayLineBalaTime[a, 13]) + float.Parse(arrayLineBalaTime[a, 14]) + float.Parse(arrayLineBalaTime[a, 15])
                + float.Parse(arrayLineBalaTime[a, 16]);
                totalTime17Key[a] = a;
            }

            Array.Sort(totalTime17, totalTime17Key);

            for (int a = 0; a < mmax; a++)
            {
                int b = totalTime17Key[a];
                if (17 * mmax + a + 1 <= count)
                {
                    showResult[b, 17] = prodtimResult[17 * mmax + a];
                    arrayLineBala[b, 17] = prodtim[17 * mmax + a];
                    arrayLineBalaTime[b, 17] = tim[17 * mmax + a];
                    //Debug.Log("min2max: " + totalTime17[a] + " " + "index: " + prodtim[17 * mmax + a + 1] + "\n");
                }
                if (17 * mmax + a + 1 > count)
                {
                    showResult[b, 17] = "-,-,";
                    arrayLineBala[b, 17] = "0,0,";
                    arrayLineBalaTime[b, 17] = "0";
                    //Debug.Log("min2max: " + totalTime17[a] + " " + "index: " + prodtim[17 * mmax + a + 1] + "\n");
                }
            }
        }
        if (nmax > 18)
        {
            for (int a = 0; a < mmax; a++)
            {

                totalTime18[a] = float.Parse(arrayLineBalaTime[a, 0]) + float.Parse(arrayLineBalaTime[a, 1]) + float.Parse(arrayLineBalaTime[a, 2]) + float.Parse(arrayLineBalaTime[a, 3]) + float.Parse(arrayLineBalaTime[a, 4]) + float.Parse(arrayLineBalaTime[a, 5]) + float.Parse(arrayLineBalaTime[a, 6]) + float.Parse(arrayLineBalaTime[a, 7]) + float.Parse(arrayLineBalaTime[a, 8]) + float.Parse(arrayLineBalaTime[a, 9]) + float.Parse(arrayLineBalaTime[a, 10]) + float.Parse(arrayLineBalaTime[a, 11]) + float.Parse(arrayLineBalaTime[a, 12]) + float.Parse(arrayLineBalaTime[a, 13]) + float.Parse(arrayLineBalaTime[a, 14]) + float.Parse(arrayLineBalaTime[a, 15])
                + float.Parse(arrayLineBalaTime[a, 16]) + float.Parse(arrayLineBalaTime[a, 17]);
                totalTime18Key[a] = a;
            }

            Array.Sort(totalTime18, totalTime18Key);

            for (int a = 0; a < mmax; a++)
            {
                int b = totalTime18Key[a];
                if (18 * mmax + a + 1 <= count)
                {
                    showResult[b, 18] = prodtimResult[18 * mmax + a];
                    arrayLineBala[b, 18] = prodtim[18 * mmax + a];
                    arrayLineBalaTime[b, 18] = tim[18 * mmax + a];
                    //Debug.Log("min2max: " + totalTime18[a] + " " + "index: " + prodtim[18 * mmax + a + 1] + "\n");
                }
                if (18 * mmax + a + 1 > count)
                {
                    showResult[b, 18] = "-,-,";
                    arrayLineBala[b, 18] = "0,0,";
                    arrayLineBalaTime[b, 18] = "0";
                    //Debug.Log("min2max: " + totalTime18[a] + " " + "index: " + prodtim[18 * mmax + a + 1] + "\n");
                }
            }
        }
        if (nmax > 19)
        {
            for (int a = 0; a < mmax; a++)
            {

                totalTime19[a] = float.Parse(arrayLineBalaTime[a, 0]) + float.Parse(arrayLineBalaTime[a, 1]) + float.Parse(arrayLineBalaTime[a, 2]) + float.Parse(arrayLineBalaTime[a, 3]) + float.Parse(arrayLineBalaTime[a, 4]) + float.Parse(arrayLineBalaTime[a, 5]) + float.Parse(arrayLineBalaTime[a, 6]) + float.Parse(arrayLineBalaTime[a, 7]) + float.Parse(arrayLineBalaTime[a, 8]) + float.Parse(arrayLineBalaTime[a, 9]) + float.Parse(arrayLineBalaTime[a, 10]) + float.Parse(arrayLineBalaTime[a, 11]) + float.Parse(arrayLineBalaTime[a, 12]) + float.Parse(arrayLineBalaTime[a, 13]) + float.Parse(arrayLineBalaTime[a, 14]) + float.Parse(arrayLineBalaTime[a, 15])
                + float.Parse(arrayLineBalaTime[a, 16]) + float.Parse(arrayLineBalaTime[a, 17]) + float.Parse(arrayLineBalaTime[a, 18]);
                totalTime19Key[a] = a;
            }

            Array.Sort(totalTime19, totalTime19Key);

            for (int a = 0; a < mmax; a++)
            {
                int b = totalTime19Key[a];
                if (19 * mmax + a + 1 <= count)
                {
                    showResult[b, 19] = prodtimResult[19 * mmax + a];
                    arrayLineBala[b, 19] = prodtim[19 * mmax + a];
                    arrayLineBalaTime[b, 19] = tim[19 * mmax + a];
                    //Debug.Log("min2max: " + totalTime19[a] + " " + "index: " + prodtim[19 * mmax + a + 1] + "\n");
                }
                if (19 * mmax + a + 1 > count)
                {
                    showResult[b, 19] = "-,-,";
                    arrayLineBala[b, 19] = "0,0,";
                    arrayLineBalaTime[b, 19] = "0";
                    //Debug.Log("min2max: " + totalTime19[a] + " " + "index: " + prodtim[19 * mmax + a + 1] + "\n");
                }
            }
        }
        if (nmax > 20)
        {
            for (int a = 0; a < mmax; a++)
            {

                totalTime20[a] = float.Parse(arrayLineBalaTime[a, 0]) + float.Parse(arrayLineBalaTime[a, 1]) + float.Parse(arrayLineBalaTime[a, 2]) + float.Parse(arrayLineBalaTime[a, 3]) + float.Parse(arrayLineBalaTime[a, 4]) + float.Parse(arrayLineBalaTime[a, 5]) + float.Parse(arrayLineBalaTime[a, 6]) + float.Parse(arrayLineBalaTime[a, 7]) + float.Parse(arrayLineBalaTime[a, 8]) + float.Parse(arrayLineBalaTime[a, 9]) + float.Parse(arrayLineBalaTime[a, 10]) + float.Parse(arrayLineBalaTime[a, 11]) + float.Parse(arrayLineBalaTime[a, 12]) + float.Parse(arrayLineBalaTime[a, 13]) + float.Parse(arrayLineBalaTime[a, 14]) + float.Parse(arrayLineBalaTime[a, 15])
                + float.Parse(arrayLineBalaTime[a, 16]) + float.Parse(arrayLineBalaTime[a, 17]) + float.Parse(arrayLineBalaTime[a, 18]) + float.Parse(arrayLineBalaTime[a, 19]);
                totalTime20Key[a] = a;
            }

            Array.Sort(totalTime20, totalTime20Key);

            for (int a = 0; a < mmax; a++)
            {
                int b = totalTime20Key[a];
                if (20 * mmax + a + 1 <= count)
                {
                    showResult[b, 20] = prodtimResult[20 * mmax + a];
                    arrayLineBala[b, 20] = prodtim[20 * mmax + a];
                    arrayLineBalaTime[b, 20] = tim[20 * mmax + a];
                    //Debug.Log("min2max: " + totalTime20[a] + " " + "index: " + prodtim[20 * mmax + a + 1] + "\n");
                }
                if (20 * mmax + a + 1 > count)
                {
                    showResult[b, 20] = "-,-,";
                    arrayLineBala[b, 20] = "0,0,";
                    arrayLineBalaTime[b, 20] = "0";
                    //Debug.Log("min2max: " + totalTime20[a] + " " + "index: " + prodtim[20 * mmax + a + 1] + "\n");
                }
            }
        }
        if (nmax > 21)
        {
            for (int a = 0; a < mmax; a++)
            {

                totalTime21[a] = float.Parse(arrayLineBalaTime[a, 0]) + float.Parse(arrayLineBalaTime[a, 1]) + float.Parse(arrayLineBalaTime[a, 2]) + float.Parse(arrayLineBalaTime[a, 3]) + float.Parse(arrayLineBalaTime[a, 4]) + float.Parse(arrayLineBalaTime[a, 5]) + float.Parse(arrayLineBalaTime[a, 6]) + float.Parse(arrayLineBalaTime[a, 7]) + float.Parse(arrayLineBalaTime[a, 8]) + float.Parse(arrayLineBalaTime[a, 9]) + float.Parse(arrayLineBalaTime[a, 10]) + float.Parse(arrayLineBalaTime[a, 11]) + float.Parse(arrayLineBalaTime[a, 12]) + float.Parse(arrayLineBalaTime[a, 13]) + float.Parse(arrayLineBalaTime[a, 14]) + float.Parse(arrayLineBalaTime[a, 15])
                + float.Parse(arrayLineBalaTime[a, 16]) + float.Parse(arrayLineBalaTime[a, 17]) + float.Parse(arrayLineBalaTime[a, 18]) + float.Parse(arrayLineBalaTime[a, 19])
                + float.Parse(arrayLineBalaTime[a, 20]);
                totalTime21Key[a] = a;
            }

            Array.Sort(totalTime21, totalTime21Key);

            for (int a = 0; a < mmax; a++)
            {
                int b = totalTime21Key[a];
                if (21 * mmax + a + 1 <= count)
                {
                    showResult[b, 21] = prodtimResult[21 * mmax + a];
                    arrayLineBala[b, 21] = prodtim[21 * mmax + a];
                    arrayLineBalaTime[b, 21] = tim[21 * mmax + a];
                    //Debug.Log("min2max: " + totalTime21[a] + " " + "index: " + prodtim[21 * mmax + a + 1] + "\n");
                }
                if (21 * mmax + a + 1 > count)
                {
                    showResult[b, 21] = "-,-,";
                    arrayLineBala[b, 21] = "0,0,";
                    arrayLineBalaTime[b, 21] = "0";
                    //Debug.Log("min2max: " + totalTime21[a] + " " + "index: " + prodtim[21 * mmax + a + 1] + "\n");
                }
            }
        }
        if (nmax > 22)
        {
            for (int a = 0; a < mmax; a++)
            {

                totalTime22[a] = float.Parse(arrayLineBalaTime[a, 0]) + float.Parse(arrayLineBalaTime[a, 1]) + float.Parse(arrayLineBalaTime[a, 2]) + float.Parse(arrayLineBalaTime[a, 3]) + float.Parse(arrayLineBalaTime[a, 4]) + float.Parse(arrayLineBalaTime[a, 5]) + float.Parse(arrayLineBalaTime[a, 6]) + float.Parse(arrayLineBalaTime[a, 7]) + float.Parse(arrayLineBalaTime[a, 8]) + float.Parse(arrayLineBalaTime[a, 9]) + float.Parse(arrayLineBalaTime[a, 10]) + float.Parse(arrayLineBalaTime[a, 11]) + float.Parse(arrayLineBalaTime[a, 12]) + float.Parse(arrayLineBalaTime[a, 13]) + float.Parse(arrayLineBalaTime[a, 14]) + float.Parse(arrayLineBalaTime[a, 15])
                + float.Parse(arrayLineBalaTime[a, 16]) + float.Parse(arrayLineBalaTime[a, 17]) + float.Parse(arrayLineBalaTime[a, 18]) + float.Parse(arrayLineBalaTime[a, 19])
                + float.Parse(arrayLineBalaTime[a, 20]) + float.Parse(arrayLineBalaTime[a, 21]);
                totalTime22Key[a] = a;
            }

            Array.Sort(totalTime22, totalTime22Key);

            for (int a = 0; a < mmax; a++)
            {
                int b = totalTime22Key[a];
                if (22 * mmax + a + 1 <= count)
                {
                    showResult[b, 22] = prodtimResult[22 * mmax + a];
                    arrayLineBala[b, 22] = prodtim[22 * mmax + a];
                    arrayLineBalaTime[b, 22] = tim[22 * mmax + a];
                    //Debug.Log("min2max: " + totalTime22[a] + " " + "index: " + prodtim[22 * mmax + a + 1] + "\n");
                }
                if (22 * mmax + a + 1 > count)
                {
                    showResult[b, 22] = "-,-,";
                    arrayLineBala[b, 22] = "0,0,";
                    arrayLineBalaTime[b, 22] = "0";
                    //Debug.Log("min2max: " + totalTime22[a] + " " + "index: " + prodtim[22 * mmax + a + 1] + "\n");
                }
            }
        }
        if (nmax > 23)
        {
            for (int a = 0; a < mmax; a++)
            {

                totalTime23[a] = float.Parse(arrayLineBalaTime[a, 0]) + float.Parse(arrayLineBalaTime[a, 1]) + float.Parse(arrayLineBalaTime[a, 2]) + float.Parse(arrayLineBalaTime[a, 3]) + float.Parse(arrayLineBalaTime[a, 4]) + float.Parse(arrayLineBalaTime[a, 5]) + float.Parse(arrayLineBalaTime[a, 6]) + float.Parse(arrayLineBalaTime[a, 7]) + float.Parse(arrayLineBalaTime[a, 8]) + float.Parse(arrayLineBalaTime[a, 9]) + float.Parse(arrayLineBalaTime[a, 10]) + float.Parse(arrayLineBalaTime[a, 11]) + float.Parse(arrayLineBalaTime[a, 12]) + float.Parse(arrayLineBalaTime[a, 13]) + float.Parse(arrayLineBalaTime[a, 14]) + float.Parse(arrayLineBalaTime[a, 15])
                + float.Parse(arrayLineBalaTime[a, 16]) + float.Parse(arrayLineBalaTime[a, 17]) + float.Parse(arrayLineBalaTime[a, 18]) + float.Parse(arrayLineBalaTime[a, 19])
                + float.Parse(arrayLineBalaTime[a, 20]) + float.Parse(arrayLineBalaTime[a, 21]) + float.Parse(arrayLineBalaTime[a, 22]);
                totalTime23Key[a] = a;
            }

            Array.Sort(totalTime23, totalTime23Key);

            for (int a = 0; a < mmax; a++)
            {
                int b = totalTime23Key[a];
                if (23 * mmax + a + 1 <= count)
                {
                    showResult[b, 23] = prodtimResult[23 * mmax + a];
                    arrayLineBala[b, 23] = prodtim[23 * mmax + a];
                    arrayLineBalaTime[b, 23] = tim[23 * mmax + a];
                    //Debug.Log("min2max: " + totalTime23[a] + " " + "index: " + prodtim[23 * mmax + a + 1] + "\n");
                }
                if (23 * mmax + a + 1 > count)
                {
                    showResult[b, 23] = "-,-,";
                    arrayLineBala[b, 23] = "0,0,";
                    arrayLineBalaTime[b, 23] = "0";
                    //Debug.Log("min2max: " + totalTime23[a] + " " + "index: " + prodtim[23 * mmax + a + 1] + "\n");
                }
            }
        }
        if (nmax > 24)
        {
            for (int a = 0; a < mmax; a++)
            {

                totalTime24[a] = float.Parse(arrayLineBalaTime[a, 0]) + float.Parse(arrayLineBalaTime[a, 1]) + float.Parse(arrayLineBalaTime[a, 2]) + float.Parse(arrayLineBalaTime[a, 3]) + float.Parse(arrayLineBalaTime[a, 4]) + float.Parse(arrayLineBalaTime[a, 5]) + float.Parse(arrayLineBalaTime[a, 6]) + float.Parse(arrayLineBalaTime[a, 7]) + float.Parse(arrayLineBalaTime[a, 8]) + float.Parse(arrayLineBalaTime[a, 9]) + float.Parse(arrayLineBalaTime[a, 10]) + float.Parse(arrayLineBalaTime[a, 11]) + float.Parse(arrayLineBalaTime[a, 12]) + float.Parse(arrayLineBalaTime[a, 13]) + float.Parse(arrayLineBalaTime[a, 14]) + float.Parse(arrayLineBalaTime[a, 15])
                + float.Parse(arrayLineBalaTime[a, 16]) + float.Parse(arrayLineBalaTime[a, 17]) + float.Parse(arrayLineBalaTime[a, 18]) + float.Parse(arrayLineBalaTime[a, 19])
                + float.Parse(arrayLineBalaTime[a, 20]) + float.Parse(arrayLineBalaTime[a, 21]) + float.Parse(arrayLineBalaTime[a, 22]) + float.Parse(arrayLineBalaTime[a, 23]);
                totalTime24Key[a] = a;
            }

            Array.Sort(totalTime24, totalTime24Key);

            for (int a = 0; a < mmax; a++)
            {
                int b = totalTime24Key[a];
                if (24 * mmax + a + 1 <= count)
                {
                    showResult[b, 24] = prodtimResult[24 * mmax + a];
                    arrayLineBala[b, 24] = prodtim[24 * mmax + a];
                    arrayLineBalaTime[b, 24] = tim[24 * mmax + a];
                    //Debug.Log("min2max: " + totalTime24[a] + " " + "index: " + prodtim[24 * mmax + a + 1] + "\n");
                }
                if (24 * mmax + a + 1 > count)
                {
                    showResult[b, 24] = "-,-,";
                    arrayLineBala[b, 24] = "0,0,";
                    arrayLineBalaTime[b, 24] = "0";
                    //Debug.Log("min2max: " + totalTime24[a] + " " + "index: " + prodtim[24 * mmax + a + 1] + "\n");
                }
            }
        }
        if (nmax > 25)
        {
            for (int a = 0; a < mmax; a++)
            {

                totalTime25[a] = float.Parse(arrayLineBalaTime[a, 0]) + float.Parse(arrayLineBalaTime[a, 1]) + float.Parse(arrayLineBalaTime[a, 2]) + float.Parse(arrayLineBalaTime[a, 3]) + float.Parse(arrayLineBalaTime[a, 4]) + float.Parse(arrayLineBalaTime[a, 5]) + float.Parse(arrayLineBalaTime[a, 6]) + float.Parse(arrayLineBalaTime[a, 7]) + float.Parse(arrayLineBalaTime[a, 8]) + float.Parse(arrayLineBalaTime[a, 9]) + float.Parse(arrayLineBalaTime[a, 10]) + float.Parse(arrayLineBalaTime[a, 11]) + float.Parse(arrayLineBalaTime[a, 12]) + float.Parse(arrayLineBalaTime[a, 13]) + float.Parse(arrayLineBalaTime[a, 14]) + float.Parse(arrayLineBalaTime[a, 15])
                + float.Parse(arrayLineBalaTime[a, 16]) + float.Parse(arrayLineBalaTime[a, 17]) + float.Parse(arrayLineBalaTime[a, 18]) + float.Parse(arrayLineBalaTime[a, 19])
                + float.Parse(arrayLineBalaTime[a, 20]) + float.Parse(arrayLineBalaTime[a, 21]) + float.Parse(arrayLineBalaTime[a, 22]) + float.Parse(arrayLineBalaTime[a, 23])
                + float.Parse(arrayLineBalaTime[a, 24]);
                totalTime25Key[a] = a;
            }

            Array.Sort(totalTime25, totalTime25Key);

            for (int a = 0; a < mmax; a++)
            {
                int b = totalTime25Key[a];
                if (25 * mmax + a + 1 <= count)
                {
                    showResult[b, 25] = prodtimResult[25 * mmax + a];
                    arrayLineBala[b, 25] = prodtim[25 * mmax + a];
                    arrayLineBalaTime[b, 25] = tim[25 * mmax + a];
                    //Debug.Log("min2max: " + totalTime25[a] + " " + "index: " + prodtim[25 * mmax + a + 1] + "\n");
                }
                if (25 * mmax + a + 1 > count)
                {
                    showResult[b, 25] = "-,-,";
                    arrayLineBala[b, 25] = "0,0,";
                    arrayLineBalaTime[b, 25] = "0";
                    //Debug.Log("min2max: " + totalTime25[a] + " " + "index: " + prodtim[25 * mmax + a + 1] + "\n");
                }
            }
        }
        if (nmax > 26)
        {
            for (int a = 0; a < mmax; a++)
            {

                totalTime26[a] = float.Parse(arrayLineBalaTime[a, 0]) + float.Parse(arrayLineBalaTime[a, 1]) + float.Parse(arrayLineBalaTime[a, 2]) + float.Parse(arrayLineBalaTime[a, 3]) + float.Parse(arrayLineBalaTime[a, 4]) + float.Parse(arrayLineBalaTime[a, 5]) + float.Parse(arrayLineBalaTime[a, 6]) + float.Parse(arrayLineBalaTime[a, 7]) + float.Parse(arrayLineBalaTime[a, 8]) + float.Parse(arrayLineBalaTime[a, 9]) + float.Parse(arrayLineBalaTime[a, 10]) + float.Parse(arrayLineBalaTime[a, 11]) + float.Parse(arrayLineBalaTime[a, 12]) + float.Parse(arrayLineBalaTime[a, 13]) + float.Parse(arrayLineBalaTime[a, 14]) + float.Parse(arrayLineBalaTime[a, 15])
                + float.Parse(arrayLineBalaTime[a, 16]) + float.Parse(arrayLineBalaTime[a, 17]) + float.Parse(arrayLineBalaTime[a, 18]) + float.Parse(arrayLineBalaTime[a, 19])
                + float.Parse(arrayLineBalaTime[a, 20]) + float.Parse(arrayLineBalaTime[a, 21]) + float.Parse(arrayLineBalaTime[a, 22]) + float.Parse(arrayLineBalaTime[a, 23])
                + float.Parse(arrayLineBalaTime[a, 24]) + float.Parse(arrayLineBalaTime[a, 25]);
                totalTime26Key[a] = a;
            }

            Array.Sort(totalTime26, totalTime26Key);

            for (int a = 0; a < mmax; a++)
            {
                int b = totalTime26Key[a];
                if (26 * mmax + a + 1 <= count)
                {
                    showResult[b, 26] = prodtimResult[26 * mmax + a];
                    arrayLineBala[b, 26] = prodtim[26 * mmax + a];
                    arrayLineBalaTime[b, 26] = tim[26 * mmax + a];
                    //Debug.Log("min2max: " + totalTime26[a] + " " + "index: " + prodtim[26 * mmax + a + 1] + "\n");
                }
                if (26 * mmax + a + 1 > count)
                {
                    showResult[b, 26] = "-,-,";
                    arrayLineBala[b, 26] = "0,0,";
                    arrayLineBalaTime[b, 26] = "0";
                    //Debug.Log("min2max: " + totalTime26[a] + " " + "index: " + prodtim[26 * mmax + a + 1] + "\n");
                }
            }
        }
        if (nmax > 27)
        {
            for (int a = 0; a < mmax; a++)
            {

                totalTime27[a] = float.Parse(arrayLineBalaTime[a, 0]) + float.Parse(arrayLineBalaTime[a, 1]) + float.Parse(arrayLineBalaTime[a, 2]) + float.Parse(arrayLineBalaTime[a, 3]) + float.Parse(arrayLineBalaTime[a, 4]) + float.Parse(arrayLineBalaTime[a, 5]) + float.Parse(arrayLineBalaTime[a, 6]) + float.Parse(arrayLineBalaTime[a, 7]) + float.Parse(arrayLineBalaTime[a, 8]) + float.Parse(arrayLineBalaTime[a, 9]) + float.Parse(arrayLineBalaTime[a, 10]) + float.Parse(arrayLineBalaTime[a, 11]) + float.Parse(arrayLineBalaTime[a, 12]) + float.Parse(arrayLineBalaTime[a, 13]) + float.Parse(arrayLineBalaTime[a, 14]) + float.Parse(arrayLineBalaTime[a, 15])
                + float.Parse(arrayLineBalaTime[a, 16]) + float.Parse(arrayLineBalaTime[a, 17]) + float.Parse(arrayLineBalaTime[a, 18]) + float.Parse(arrayLineBalaTime[a, 19])
                + float.Parse(arrayLineBalaTime[a, 20]) + float.Parse(arrayLineBalaTime[a, 21]) + float.Parse(arrayLineBalaTime[a, 22]) + float.Parse(arrayLineBalaTime[a, 23])
                + float.Parse(arrayLineBalaTime[a, 24]) + float.Parse(arrayLineBalaTime[a, 25]) + float.Parse(arrayLineBalaTime[a, 26]);
                totalTime27Key[a] = a;
            }

            Array.Sort(totalTime27, totalTime27Key);

            for (int a = 0; a < mmax; a++)
            {
                int b = totalTime27Key[a];
                if (27 * mmax + a + 1 <= count)
                {
                    showResult[b, 27] = prodtimResult[27 * mmax + a];
                    arrayLineBala[b, 27] = prodtim[27 * mmax + a];
                    arrayLineBalaTime[b, 27] = tim[27 * mmax + a];
                    //Debug.Log("min2max: " + totalTime27[a] + " " + "index: " + prodtim[27 * mmax + a + 1] + "\n");
                }
                if (27 * mmax + a + 1 > count)
                {
                    showResult[b, 27] = "-,-,";
                    arrayLineBala[b, 27] = "0,0,";
                    arrayLineBalaTime[b, 27] = "0";
                    //Debug.Log("min2max: " + totalTime27[a] + " " + "index: " + prodtim[27 * mmax + a + 1] + "\n");
                }
            }
        }
        if (nmax > 28)
        {
            for (int a = 0; a < mmax; a++)
            {

                totalTime28[a] = float.Parse(arrayLineBalaTime[a, 0]) + float.Parse(arrayLineBalaTime[a, 1]) + float.Parse(arrayLineBalaTime[a, 2]) + float.Parse(arrayLineBalaTime[a, 3]) + float.Parse(arrayLineBalaTime[a, 4]) + float.Parse(arrayLineBalaTime[a, 5]) + float.Parse(arrayLineBalaTime[a, 6]) + float.Parse(arrayLineBalaTime[a, 7]) + float.Parse(arrayLineBalaTime[a, 8]) + float.Parse(arrayLineBalaTime[a, 9]) + float.Parse(arrayLineBalaTime[a, 10]) + float.Parse(arrayLineBalaTime[a, 11]) + float.Parse(arrayLineBalaTime[a, 12]) + float.Parse(arrayLineBalaTime[a, 13]) + float.Parse(arrayLineBalaTime[a, 14]) + float.Parse(arrayLineBalaTime[a, 15])
                + float.Parse(arrayLineBalaTime[a, 16]) + float.Parse(arrayLineBalaTime[a, 17]) + float.Parse(arrayLineBalaTime[a, 18]) + float.Parse(arrayLineBalaTime[a, 19])
                + float.Parse(arrayLineBalaTime[a, 20]) + float.Parse(arrayLineBalaTime[a, 21]) + float.Parse(arrayLineBalaTime[a, 22]) + float.Parse(arrayLineBalaTime[a, 23])
                + float.Parse(arrayLineBalaTime[a, 24]) + float.Parse(arrayLineBalaTime[a, 25]) + float.Parse(arrayLineBalaTime[a, 26]) + float.Parse(arrayLineBalaTime[a, 27]);
                totalTime28Key[a] = a;
            }

            Array.Sort(totalTime28, totalTime28Key);

            for (int a = 0; a < mmax; a++)
            {
                int b = totalTime28Key[a];
                if (28 * mmax + a + 1 <= count)
                {
                    showResult[b, 28] = prodtimResult[28 * mmax + a];
                    arrayLineBala[b, 28] = prodtim[28 * mmax + a];
                    arrayLineBalaTime[b, 28] = tim[28 * mmax + a];
                    //Debug.Log("min2max: " + totalTime28[a] + " " + "index: " + prodtim[28 * mmax + a + 1] + "\n");
                }
                if (28 * mmax + a + 1 > count)
                {
                    showResult[b, 28] = "-,-,";
                    arrayLineBala[b, 28] = "0,0,";
                    arrayLineBalaTime[b, 28] = "0";
                    //Debug.Log("min2max: " + totalTime28[a] + " " + "index: " + prodtim[28 * mmax + a + 1] + "\n");
                }
            }
        }

        for (int a = 0; a < mmax; a++)
        {
            for (int b = 0; b < nmax+1; b++)
            {
                System.IO.File.AppendAllText(fileToSave, arrayLineBala[a, b]);
                //System.IO.File.AppendAllText(@"LineBalancing.csv", a + ", " + b+ ", "); //show matrix number for verify

                if (b == nmax)
                {
                    System.IO.File.AppendAllText(fileToSave, "\n");
                }
            }
        }

        float[] TotalTimeTime = new float[ArrangeTableScript.SetNo];

        for (int a = 0; a < mmax; a++)
        {
            float timetime = 0;
            for (int b = 0; b < nmax; b++)
            {
                timetime = timetime + float.Parse(arrayLineBalaTime[a, b]);
                TotalTimeTime[a] = timetime;

            }
            //Debug.Log("checkc " + TotalTimeTime[a]);
        }

        TotalTime = (float)Math.Round(TotalTimeTime.Max(), 2);
        DifferentTime = (float)Math.Round((TotalTimeTime.Max() - TotalTimeTime.Min()), 2);

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
            for (int b = 0; b < nmax + 1; b++)
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
                    //Debug.Log("a is " + b);
                }
            }
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}


