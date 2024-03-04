using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ReadCSV : MonoBehaviour {

	public List myList;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		//string[] values=new string[7] ;

		//static void Main(string[] args){
		using (var fs = File.OpenRead (@"C:\Users\Sivadas-AMIC\Desktop\TestCSV\LineBalancing1.csv"))
		using (var reader = new StreamReader (fs)) {
			List<string> listA = new List<string> ();
			List<string> listB = new List<string> ();
				
			while (!reader.EndOfStream) {
				var line = reader.ReadLine ();
				var values = line.Split (';');

				listA.Add (values[0]);
				listB.Add(values[1]);
					
			}

			//foreach (string item in listA) {
			//	Debug.Log (item);
			//}
			//	foreach (string item1 in listB) {
			//		Debug.Log (item1);

			//}	
					
		}
	}
}
