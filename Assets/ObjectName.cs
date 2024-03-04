using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectName : MonoBehaviour {

	string gameobject;
	string ID;
	public int IDf;

	// Use this for initialization
	void Start () {

		//gameobject = gameObject.GetInstanceID(ToString);
		gameobject=gameObject.name;
		ID= gameobject.Split(' ')[1];
		IDf = int.Parse (ID);
		//Debug.Log (IDf);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
