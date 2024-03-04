﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.IO;
using System;
using System.Runtime.InteropServices;

public class CSVLineBalancingAuto : MonoBehaviour
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

        GameObject thePlayer = GameObject.Find("Check collision");
        ArrangeTableAR ArrangeTableScript = thePlayer.GetComponent<ArrangeTableAR>();
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

        string[,] arrayLineBala = new string[mmax, nmax+2];
        string[,] arrayLineBalaTime = new string[mmax, nmax+2];
        string[,] showResult = new string[mmax, nmax+2];
        //SaveFile();
        fileToSave = "@/../_Data/Results/Compute/Sim_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".csv";
        System.IO.File.WriteAllText(fileToSave, " ");
        //string fileResult = System.IO.Path.GetFileNameWithoutExtension(fileToSave) + "_Result.csv";
        //string fileResult = System.IO.Path.ChangeExtension(fileToSave, "_Result.csv");
        //string fileResult = System.IO.Path.GetDirectoryName(fileToSave) + "\\" + System.IO.Path.GetFileNameWithoutExtension(fileToSave) + "_Result.csv";
        string fileResult = "@/../_Data/Results/" + System.IO.Path.GetFileNameWithoutExtension(fileToSave) + "_Result.csv";
        System.IO.File.WriteAllText(fileResult, " ");

        int[] totalTimeKey = new int[mmax];
        float[] totalTime = new float[mmax];
        int ii = 0;

        for (int a = 0; a < mmax; a++)
        {
            showResult[a, 0] = prodtimResult[a];
            arrayLineBala[a, 0] = prodtim[a];
            arrayLineBalaTime[a, 0] = tim[a];            
        }

        for (int b = 0; b < (nmax + 1); b++)
        {

            for (int a = 0; a < mmax; a++)
            {
                float time2 = 0;
                for (int bloop = 0; bloop < (b + 1); bloop++)
                {
                    time2 = time2 + float.Parse(arrayLineBalaTime[a, bloop]);
                }
                totalTime[a] = time2;
                //Debug.Log(totalTime[a]);
                totalTimeKey[a] = a;
            }

            Array.Sort(totalTime, totalTimeKey);

            for (int a = 0; a < mmax; a++)
            {
                int bb = totalTimeKey[a];
                if ((b + 1) * mmax + a + 1 <= count)
                {
                    showResult[bb, (b + 1)] = prodtimResult[(b + 1) * mmax + a];
                    arrayLineBala[bb, (b + 1)] = prodtim[(b + 1) * mmax + a];
                    arrayLineBalaTime[bb, (b + 1)] = tim[(b + 1) * mmax + a];
                }
                if ((b + 1) * mmax + a + 1 > count)
                {
                    showResult[bb, (b + 1)] = "-,-,";
                    arrayLineBala[bb, (b + 1)] = "0,0,";
                    arrayLineBalaTime[bb, (b + 1)] = "0";
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

