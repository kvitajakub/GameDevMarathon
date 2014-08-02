using UnityEngine;
using System.Collections;

public class WatchScript : MonoBehaviour {

	// Use this for initialization
	public float timeToDie;
	float time = 0;
	GameObject hand;
//	GameObject alert;

	float flash;
	float tmpTime;
	float alertX;
	float alertY;
	float alertZ;
	Vector3 ok, bad;

	void Start () {
		timeToDie = 60f;
		hand = GameObject.Find("stopwatch_0");
		//alert = GameObject.Find ("reAlert_0");

		time = timeToDie;
		hand.transform.Rotate(0,0,time*6);
		flash = 0;
	}
	
	// Update is called once per frame
	void Update () {
		//drawRedAlert(time);
		tmpTime = Time.deltaTime;
		time -= tmpTime;

		if (time <= 0.0) {
			// gameover
		} else {
			hand.transform.Rotate(0,0,tmpTime*6);
		}
	}
/*
	void drawRedAlert(float time){
		if (time >= 30.0)return; // no need to hurry
		alert.transform.Translate(ok);

		flash += tmpTime;

		if (flash > 5.0 && flash <= 5.1) {
			alert.transform.Translate(bad);
		} else if (flash > 5.1 && flash<= 5.2) {
			alert.transform.Translate(ok);
		} else if (flash > 5.2 && flash <= 5.3) {
			alert.transform.Translate(bad);
		} else if (flash > 5.3 && flash <= 5.4) {
			alert.transform.Translate(ok);
		} else if (flash > 5.4 && flash <= 5.5) {
			alert.transform.Translate(bad);
		} else {
			alert.transform.Translate(ok);
			flash = 0.5f;
		}
	}
*/
	void topUp(){
		time += 2.0f;
	}
}
