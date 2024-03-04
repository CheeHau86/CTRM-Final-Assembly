using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class timerTwo : MonoBehaviour {
	Image fillImg;
	public float ProcessTime;
	float time;
	public Text timeText;  
	float FillAmount=1;
	Color lerpedColor = Color.black;

	// Use this for initialization
	void Start () {
		fillImg = this.GetComponent<Image>();
		time = ProcessTime*60;

	}

	// Update is called once per frame
	void Update () {
		if(time  > 0){
			time -= Time.deltaTime;
			FillAmount -= Time.deltaTime/(ProcessTime*60);
			fillImg.fillAmount = FillAmount;
			timeText.text = time.ToString("F"); 
			GetComponentInParent<Renderer> ().material.color = Color.Lerp(Color.white, Color.red, Mathf.PingPong(Time.time,1));

			if (time<0f) {

				//fillImg.fillAmount = 1;
				//fillImg.color = Color.green;
				GetComponentInParent<Renderer> ().material.color = Color.green;
				//lerpedColor = Color.Lerp(Color.white, Color.black, Mathf.PingPong(Time.time,ProcessTime*60 ));
				timeText.text = "Vacant";
			}
		}
	}
}