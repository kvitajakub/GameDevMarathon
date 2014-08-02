using UnityEngine;
using System.Collections;

public class floorbehav : MonoBehaviour {

	// Use this for initialization
	void Start () {
		gameObject.tag = "floor";
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D colObj) {
		if(colObj.gameObject.tag == "enemy"){
			colObj.gameObject.rigidbody2D.transform.position = new Vector2(
					colObj.gameObject.rigidbody2D.transform.position.x,
					120);
		}
	}
}
