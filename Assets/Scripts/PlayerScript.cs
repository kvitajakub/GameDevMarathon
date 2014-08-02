using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

	public Vector2 speed = new Vector2(10,10);

	private Vector2 movement;		

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float inputX = Input.GetAxis("Horizontal");
		float inputY = Input.GetAxis("Vertical");

		movement = new Vector2 (
			speed.x * inputX,
			speed.y * inputY + 0.2f*rigidbody2D.velocity.y - 10.0f
		);

		if (movement.y > 50) {
			movement.y = 50;}
	}

	void FixedUpdate()
	{
		// 5 - Move the game object
		rigidbody2D.velocity = movement;
	}


}
