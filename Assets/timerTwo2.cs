using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System.IO;

public class timerTwo2: MonoBehaviour {
	Image fillImg;

	float ProcessTime;float ProcessTime1;float ProcessTime2;float ProcessTime3;float ProcessTime4;float ProcessTime5;float ProcessTime6;float ProcessTime7;float ProcessTime8;float ProcessTime9;
	float ProcessTime10;float ProcessTime11;
	float time;float time2;float time3;float time4;float time5;float time6;float time7;float time8;float time9;float time10;float time11;float time12;
	string ProcessText1; string ProcessText2;string ProcessText3;string ProcessText4;string ProcessText5;string ProcessText6;string ProcessText7;string ProcessText8;string ProcessText9;
	string ProcessText10;string ProcessText11;string ProcessText12;
	string FProcessText1; string FProcessText2;string FProcessText3;string FProcessText4;string FProcessText5;string FProcessText6;string FProcessText7;string FProcessText8;string FProcessText9;
	string FProcessText10;string FProcessText11;string FProcessText12;
	public Text FProcessText1a;
	public Text FProcessText2a;
	public Text FProcessText3a;public Text FProcessText4a;public Text FProcessText5a;public Text FProcessText6a;public Text FProcessText7a;public Text FProcessText8a;
	public Text FProcessText9a;public Text FProcessText10a;public Text FProcessText11a;public Text FProcessText12a;
	public Text ProcessText;
	public Text timeText;  
	public GameObject Workstation;
	public int IDf;
	float FillAmount=1;float FillAmount1=1;float FillAmount2=1;float FillAmount3=1;float FillAmount4=1;float FillAmount5=1;float FillAmount6=1;float FillAmount7=1;float FillAmount8=1;
	float FillAmount9=1;float FillAmount10=1;float FillAmount11=1;float FillAmount12=1;
	Color lerpedColor = Color.black;
	string gameobject;
	string ID;
	bool count1=true;bool count2=false;bool count3=false;bool count4=false;bool count5=false;bool count6=false;bool count7=false;bool count8=false;bool count9=false;
	bool count10=false;bool count11=false;bool count12=false;

	public List<dataFile>myList=new List<dataFile>();
	string q;


		
	void Start () {

        GameObject csv = GameObject.Find("CSV");
        //CSVLineBalancing CSVLineBalaScript = csv.GetComponent<CSVLineBalancing>();
        CSVLineBalancingAuto CSVLineBalaAutoScript = csv.GetComponent<CSVLineBalancingAuto>();

        fillImg = this.GetComponent<Image> ();
		time = ProcessTime * 60;
        //StreamReader reader = new StreamReader (CSVLineBalaAutoScript.fileToSave);
        StreamReader reader = new StreamReader("@/../_Data/Results/Sim_output.csv"); 
        string s = reader.ReadLine ();
		while (s != null) {
			char[] delimiter = { ',' };
			string[] fields = s.Split (delimiter);
			string t1 = fields [0];
			float t2 = float.Parse (fields [1]);
			string t3 = fields [2];
			float t4 = float.Parse (fields [3]);
			string t5 = fields [4];
			float t6 = float.Parse (fields [5]);
			string t7 = fields [6];
			float t8 = float.Parse (fields [7]);
			string t9 = fields [8];
			float t10 = float.Parse (fields [9]);
			string t11 = fields [10];
			float t12 = float.Parse (fields [11]);
			string t13 = fields [12];
			float t14 = float.Parse (fields [13]);
			string t15 = fields [14];
			float t16 = float.Parse (fields [15]);
			string t17 = fields [16];
			float t18 = float.Parse (fields [17]);
			string t19 = fields [18];
			float t20 = float.Parse (fields [19]);
			string t21 = fields [20];
			float t22 = float.Parse (fields [21]);
			string t23 = fields [22];
			float t24 = float.Parse (fields [23]);
            

			s = reader.ReadLine ();
			dataFile d1 = new dataFile (t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16, t17, t18, t19, t20, t21, t22, t23, t24);
			myList.Add (d1);
			gameobject = transform.root.gameObject.name;
			ID = gameobject.Split (' ') [1];
			IDf = int.Parse (ID);

		}

		dataFile d2 = myList [IDf - 1];  //[row number]
		ProcessTime = d2.col2;	//d2.columnn number
		ProcessTime1 = d2.col4;
		ProcessTime2 = d2.col6;
		ProcessTime3 = d2.col8;
		ProcessTime4 = d2.col10;
		ProcessTime5 = d2.col12;
		ProcessTime6 = d2.col14;
		ProcessTime7 = d2.col16;
		ProcessTime8 = d2.col18;
		ProcessTime9 = d2.col20;
		ProcessTime10 = d2.col22;
		ProcessTime11 = d2.col24;
		ProcessText1 = d2.col1;	//d2.columnn number
		ProcessText2 = d2.col3;
		ProcessText3 = d2.col5;
		ProcessText4 = d2.col7;
		ProcessText5 = d2.col9;
		ProcessText6 = d2.col11;
		ProcessText7 = d2.col13;
		ProcessText8 = d2.col15;
		ProcessText9 = d2.col17;
		ProcessText10 = d2.col19;
		ProcessText11 = d2.col21;
		ProcessText12 = d2.col23;

		time = ProcessTime * 60;
		time2 = ProcessTime1 * 60;
		time3 = ProcessTime2 * 60;
		time4 = ProcessTime3 * 60;
		time5 = ProcessTime4 * 60;
		time6 = ProcessTime5 * 60;
		time7 = ProcessTime6 * 60;
		time8 = ProcessTime7 * 60;
		time9 = ProcessTime8 * 60;
		time10 = ProcessTime9 * 60;
		time11 = ProcessTime10 * 60;
		time12 = ProcessTime11 * 60;

		if (ProcessText1 != "0") {
			FProcessText1a.text = ProcessText1;
		}
		if (ProcessText1 == "0"){
			FProcessText1a.text = "";
		}	
		if (ProcessText2 != "0") {
			FProcessText2a.text = ProcessText2;
		}
		if (ProcessText2 == "0"){
			FProcessText2a.text = "";
		}
		if (ProcessText3 != "0") {
			FProcessText3a.text = ProcessText3;
		}
		if (ProcessText3 == "0"){
			FProcessText3a.text = "";
		}
		if (ProcessText4 != "0") {
			FProcessText4a.text = ProcessText4;
		}
		if (ProcessText4 == "0"){
			FProcessText4a.text = "";
		}
		if (ProcessText5 != "0") {
			FProcessText5a.text = ProcessText5;
		}
		if (ProcessText5 == "0"){
			FProcessText5a.text = "";
		}
		if (ProcessText6 != "0") {
			FProcessText6a.text = ProcessText6;
		}
		if (ProcessText6 == "0"){
			FProcessText6a.text = "";
		}
		if (ProcessText7 != "0") {
			FProcessText7a.text = ProcessText7;
		}
		if (ProcessText7 == "0"){
			FProcessText7a.text = "";
		}
		if (ProcessText8 != "0") {
			FProcessText8a.text = ProcessText8;
		}
		if (ProcessText8 == "0"){
			FProcessText8a.text = "";
		}
		if (ProcessText9 != "0") {
			FProcessText9a.text = ProcessText9;
		}
		if (ProcessText9 == "0"){
			FProcessText9a.text = "";
		}
		if (ProcessText10 != "0") {
			FProcessText10a.text = ProcessText10;
		}
		if (ProcessText10 == "0"){
			FProcessText10a.text = "";
		}
		if (ProcessText11 != "0") {
			FProcessText11a.text = ProcessText11;
		}
		if (ProcessText11 == "0"){
			FProcessText11a.text = "";
		}
		if (ProcessText12 != "0") {
			FProcessText12a.text = ProcessText12;
		}
		if (ProcessText12 == "0"){
			FProcessText12a.text = "";
		}


	}
	// ________________________________________________________________________________________________________________________________
	void Update () {



		if (count1==true) {
			
			if (time > 0) {
				time -= Time.deltaTime;
				//Debug.Log (time);
				FillAmount -= Time.deltaTime / (ProcessTime * 60);
				fillImg.fillAmount = FillAmount;
				//string minsec = string.Format ("{0}:{1:00}", (int)time / 60, (int)time % 60);guiText.guiText = minsec;
				ProcessText.text= ProcessText1;
				timeText.text =(System.TimeSpan.FromSeconds((int)time)).ToString ();
				//timeText.text = q; 
				GetComponentInParent<Renderer> ().material.color = Color.Lerp (Color.white, Color.red, Mathf.PingPong (Time.time, 1));

				if (time <= 0) {
					count1 = false;
					count2 = true;
					GetComponentInParent<Renderer> ().material.color = Color.green;
					timeText.text = "Vacant";
				}

				if (time == 0) {
					GetComponentInParent<Renderer> ().material.color = Color.green;
					timeText.text = "Vacant";
				}
			}
		}



		if (count2==true) {
			if (time2 > 0) {
				
				time2 -= Time.deltaTime;
				FillAmount1 -= Time.deltaTime / (ProcessTime1 * 60);
				fillImg.fillAmount = FillAmount1;
				ProcessText.text= ProcessText2;
				timeText.text = time2.ToString ("F"); 
				GetComponentInParent<Renderer> ().material.color = Color.Lerp (Color.white, Color.red, Mathf.PingPong (Time.time, 1));
				if (time2 <= 0) {
					count2 = false;
					count3 = true;
					GetComponentInParent<Renderer> ().material.color = Color.green;
					timeText.text = "Vacant";
				}

				if (time2 == 0) {
					GetComponentInParent<Renderer> ().material.color = Color.green;
					timeText.text = "Vacant";
				}
			}
		}

		if (count3==true) {
			if (time3 > 0) {

				time3 -= Time.deltaTime;
				FillAmount2 -= Time.deltaTime / (ProcessTime2 * 60);
				fillImg.fillAmount = FillAmount2;
				ProcessText.text= ProcessText3;
				timeText.text = time3.ToString ("F"); 
				GetComponentInParent<Renderer> ().material.color = Color.Lerp (Color.white, Color.red, Mathf.PingPong (Time.time, 1));
				if (time3 <= 0) {
					count3 = false;
					count4 = true;
					GetComponentInParent<Renderer> ().material.color = Color.green;
					timeText.text = "Vacant";
				}

				if (time3 == 0) {
					GetComponentInParent<Renderer> ().material.color = Color.green;
					timeText.text = "Vacant";
				}
			}
		}

		if (count4==true) {

			Debug.Log (count4);

			if (time4 > 0) {

				time4 -= Time.deltaTime;
				FillAmount3 -= Time.deltaTime / (ProcessTime3 * 60);
				fillImg.fillAmount = FillAmount3;
				ProcessText.text= ProcessText4;
				timeText.text = time4.ToString ("F"); 
				GetComponentInParent<Renderer> ().material.color = Color.Lerp (Color.white, Color.red, Mathf.PingPong (Time.time, 1));
				if (time4 <= 0) {
					count4 = false;
					count5 = true;
					GetComponentInParent<Renderer> ().material.color = Color.green;
					timeText.text = "Vacant";
				}

				if (time4 == 0) {
					GetComponentInParent<Renderer> ().material.color = Color.green;
					timeText.text = "Vacant";
				}
			}
		}

		if (count5==true) {
			if (time5 > 0) {

				time5 -= Time.deltaTime;
				FillAmount4 -= Time.deltaTime / (ProcessTime4 * 60);
				fillImg.fillAmount = FillAmount4;
				ProcessText.text= ProcessText5;
				timeText.text = time5.ToString ("F"); 
				GetComponentInParent<Renderer> ().material.color = Color.Lerp (Color.white, Color.red, Mathf.PingPong (Time.time, 1));
				if (time5 <= 0) {
					count5 = false;
					count6 = true;
					GetComponentInParent<Renderer> ().material.color = Color.green;
					timeText.text = "Vacant";
				}

				if (time5 == 0) {
					GetComponentInParent<Renderer> ().material.color = Color.green;
					timeText.text = "Vacant";
				}
			}
		}

		if (count6==true) {
			if (time6 > 0) {

				time6 -= Time.deltaTime;
				FillAmount5 -= Time.deltaTime / (ProcessTime5 * 60);
				fillImg.fillAmount = FillAmount5;
				ProcessText.text= ProcessText6;
				timeText.text = time6.ToString ("F"); 
				GetComponentInParent<Renderer> ().material.color = Color.Lerp (Color.white, Color.red, Mathf.PingPong (Time.time, 1));
				if (time6 <= 0) {
					count6 = false;
					count7 = true;
					GetComponentInParent<Renderer> ().material.color = Color.green;
					timeText.text = "Vacant";
				}

				if (time6 == 0) {
					GetComponentInParent<Renderer> ().material.color = Color.green;
					timeText.text = "Vacant";
				}
			}
		}

		if (count7==true) {
			if (time7 > 0) {

				time7 -= Time.deltaTime;
				FillAmount6 -= Time.deltaTime / (ProcessTime6 * 60);
				fillImg.fillAmount = FillAmount6;
				ProcessText.text= ProcessText7;
				timeText.text = time7.ToString ("F"); 
				GetComponentInParent<Renderer> ().material.color = Color.Lerp (Color.white, Color.red, Mathf.PingPong (Time.time, 1));
				if (time7 <= 0) {
					count7 = false;
					count8 = true;
					GetComponentInParent<Renderer> ().material.color = Color.green;
					timeText.text = "Vacant";
				}

				if (time7 == 0) {
					GetComponentInParent<Renderer> ().material.color = Color.green;
					timeText.text = "Vacant";
				}
			}
		}

		if (count8==true) {
			if (time8 > 0) {

				time8 -= Time.deltaTime;
				FillAmount7 -= Time.deltaTime / (ProcessTime7 * 60);
				fillImg.fillAmount = FillAmount7;
				ProcessText.text= ProcessText8;
				timeText.text = time8.ToString ("F"); 
				GetComponentInParent<Renderer> ().material.color = Color.Lerp (Color.white, Color.red, Mathf.PingPong (Time.time, 1));
				if (time8 <= 0) {
					count8 = false;
					count9 = true;
					GetComponentInParent<Renderer> ().material.color = Color.green;
					timeText.text = "Vacant";
				}

				if (time8 == 0) {
					GetComponentInParent<Renderer> ().material.color = Color.green;
					timeText.text = "Vacant";
				}
			}
		}

		if (count9==true) {
			if (time9 > 0) {

				time9 -= Time.deltaTime;
				FillAmount8 -= Time.deltaTime / (ProcessTime8 * 60);
				fillImg.fillAmount = FillAmount8;
				ProcessText.text= ProcessText9;
				timeText.text = time9.ToString ("F"); 
				GetComponentInParent<Renderer> ().material.color = Color.Lerp (Color.white, Color.red, Mathf.PingPong (Time.time, 1));
				if (time9 <= 0) {
					count9 = false;
					count10 = true;
					GetComponentInParent<Renderer> ().material.color = Color.green;
					timeText.text = "Vacant";
				}

				if (time9 == 0) {
					GetComponentInParent<Renderer> ().material.color = Color.green;
					timeText.text = "Vacant";
				}
			}
		}

		if (count10==true) {
			if (time10 > 0) {

				time10 -= Time.deltaTime;
				FillAmount9 -= Time.deltaTime / (ProcessTime9 * 60);
				fillImg.fillAmount = FillAmount9;
				ProcessText.text= ProcessText10;
				timeText.text = time10.ToString ("F"); 
				GetComponentInParent<Renderer> ().material.color = Color.Lerp (Color.white, Color.red, Mathf.PingPong (Time.time, 1));
				if (time10 <= 0) {
					count10 = false;
					count11 = true;
					GetComponentInParent<Renderer> ().material.color = Color.green;
					timeText.text = "Vacant";
				}

				if (time10 == 0) {
					GetComponentInParent<Renderer> ().material.color = Color.green;
					timeText.text = "Vacant";
				}
			}
		}


		if (count11==true) {
			if (time11 > 0) {

				time11 -= Time.deltaTime;
				FillAmount10 -= Time.deltaTime / (ProcessTime10 * 60);
				fillImg.fillAmount = FillAmount10;
				ProcessText.text= ProcessText11;
				timeText.text = time11.ToString ("F"); 
				GetComponentInParent<Renderer> ().material.color = Color.Lerp (Color.white, Color.red, Mathf.PingPong (Time.time, 1));
				if (time11 <= 0) {
					count11 = false;
					count12 = true;
					GetComponentInParent<Renderer> ().material.color = Color.green;
					timeText.text = "Vacant";
				}

				if (time11 == 0) {
					GetComponentInParent<Renderer> ().material.color = Color.green;
					timeText.text = "Vacant";
				}
			}
		}

		if (count12==true) {
			if (time12 > 0) {

				time12 -= Time.deltaTime;
				FillAmount11 -= Time.deltaTime / (ProcessTime11 * 60);
				fillImg.fillAmount = FillAmount11;
				ProcessText.text= ProcessText12;
				timeText.text = time12.ToString ("F"); 
				GetComponentInParent<Renderer> ().material.color = Color.Lerp (Color.white, Color.red, Mathf.PingPong (Time.time, 1));
				if (time12 <= 0) {
					count12 = false;
					GetComponentInParent<Renderer> ().material.color = Color.green;
					timeText.text = "Vacant";
				}

				if (time12 == 0) {
					GetComponentInParent<Renderer> ().material.color = Color.green;
					timeText.text = "Vacant";
				}
			}
		}



}
}
	public class dataFile{

		//public string col1;
		//public float col2,col3,col4,col5,col6,col7,col8;
		public float col2,col4,col6,col8,col10,col12,col14,col16,col18,col20,col22,col24;
		public string col1, col3, col5, col7, col9, col11, col13, col15, col17, col19, col21, col23;

		//public dataFile(string x1, float y1, float z1, float a1, float b1, float c1, float d1, float e1){
	public dataFile(string x1, float y1, string z1, float a1, string b1, 
		float c1, string d1, float e1, string f1, float g1, string h1, 
		float i1, string j1, float k1, string l1, float m1,string p1, 
		float q1, string r1, float s1, string t1, 
		float u1, string v1,float w1) 

	{
			col1 = x1;
			col2 = y1;
			col3 = z1;
			col4 = a1;
			col5 = b1;
			col6 = c1;
			col7 = d1;
			col8 = e1;
			col9 = f1;
			col10 = g1;
			col11 = h1;
			col12 = i1;
			col13 = j1;
			col14 = k1;
			col15 = l1;
			col16 = m1;
			col17 = p1;
			col18 = q1;
			col19 = r1;
			col20 = s1;
			col21 = t1;
			col22 = u1;
			col23 = v1;
			col24 = w1;

		}
}




