using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class List : MonoBehaviour {
	public List<dataFile>myList=new List<dataFile>();
	// Use this for initialization
	void Start () {
		
		StreamReader reader = new StreamReader (@"C:\Users\Sivadas-AMIC\Desktop\TestCSV\LineBalancing1.csv");
		string s = reader.ReadLine ();
		while (s!=null){
			char[] delimiter = { ',' };
			string[] fields = s.Split (delimiter);
			float t1 = float.Parse (fields [0]);
			float t2 = float.Parse (fields [1]);
			s = reader.ReadLine ();
			dataFile d1 = new dataFile (t1, t2);
			myList.Add (d1);
		
	}
	}
		
	public class dataFile{

			public float fx,fy;

			public dataFile(float x1, float y1){

				fx=x1;
				fy=y1;
			}

		}
			
	// Update is called once per frame


	void update()
	{

		

	}
}


