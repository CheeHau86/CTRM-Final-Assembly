using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System.IO;

public class timerTwo1 : MonoBehaviour {
	Image fillImg;
	float ProcessTime;
	float time;
	public Text timeText;  
	public GameObject Workstation;
	public int IDf;
	float FillAmount=1;
	Color lerpedColor = Color.black;
	string gameobject;
	string ID;

	public List<dataFile>myList=new List<dataFile>();

	// Use this for initialization
	void Start () {
		fillImg = this.GetComponent<Image> ();
		time = ProcessTime * 60;
		StreamReader reader = new StreamReader (@"C:\Users\Sivadas-AMIC\Desktop\TestCSV\LineBalancing1.csv");
		string s = reader.ReadLine ();
		while (s != null) {
			char[] delimiter = { ',' };
			string[] fields = s.Split (delimiter);
			float t1 = float.Parse (fields [0]);
			float t2 = float.Parse (fields [1]);
			float t3 = float.Parse (fields [2]);
			//Debug.Log (t1);
			s = reader.ReadLine ();
			dataFile d1 = new dataFile (t1, t2,t3);
			myList.Add (d1);
			gameobject=transform.root.gameObject.name;
			Debug.Log (gameobject);
			ID= gameobject.Split(' ')[1];
			IDf = int.Parse (ID);



	}

		dataFile d2=myList[IDf-1]; 
		ProcessTime = d2.col1;
		time = ProcessTime*60;
		Debug.Log (time);

		//Debug.Log(ProcessTime);

	}
	// Update is called once per frame
	void Update () {

		if (time > 0) {
			
			//ProcessTime = d2.col1;
			time -= Time.deltaTime;
			FillAmount -= Time.deltaTime / (ProcessTime * 60);
			fillImg.fillAmount = FillAmount;
			timeText.text = time.ToString ("F"); 
			GetComponentInParent<Renderer> ().material.color = Color.Lerp (Color.white, Color.red, Mathf.PingPong (Time.time, 1));

		}
		//Debug.Log (time);

			if (time<0f) {

				//fillImg.fillAmount = 1;
				//fillImg.color = Color.green;
				GetComponentInParent<Renderer> ().material.color = Color.green;
				//lerpedColor = Color.Lerp(Color.white, Color.black, Mathf.PingPong(Time.time,ProcessTime*60));
				timeText.text = "Vacant";
			}



	}


		public class dataFile{

			public float col1,col2,col3;

		public dataFile(float x1, float y1, float z1){

				col1 = x1;
				col2 = y1;
				col3 = z1;
			}

		}


}