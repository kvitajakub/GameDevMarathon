using UnityEngine;
using System.Collections;

public class enemiBehav : MonoBehaviour {

	// x velocity abs value
	public float movX = 5.0f;
	public bool rightWay = true;
	Animator anim;
	// initial movement
	public Vector2 initMovement;

	private GameObject player;
	
	Vector2 tmp;

	private float time = 0.0f;
	public float interpolatedPeriod = 0.5f;

	// Use this for initialization
	void Start () {
		initMovement = new Vector2 (movX, 0);
		rigidbody2D.velocity = initMovement;

		player = GameObject.Find("Player");
		anim = GetComponent<Animator>();
		gameObject.tag = "enemy";
		anim.SetFloat("Speed", movX);
	}

	void OnCollisionEnter2D(Collision2D colObj) {

		if (colObj.gameObject.tag == "Bullet") {
			Destroy (this.gameObject);

			player.SendMessage("updateScore");
		}
	}

	// Update is called once per frame
	void Update () {
		time += Time.deltaTime;
		if (time >= interpolatedPeriod) {
			time = 0.0f;	
		
			Vector2 tmp = rigidbody2D.velocity;
			float playerPos = player.gameObject.rigidbody2D.transform.position.x;
			
			
			float whereIsPlayer = playerPos - rigidbody2D.transform.position.x;
			tmp.x = whereIsPlayer <= 0 ? -movX : movX;
			
			rigidbody2D.velocity = tmp;

			float x = rigidbody2D.velocity.x;

			if (x > 0 && !rightWay) {
				flip();
			} else if (x < 0 && rightWay) {
				flip();
			}
		}
	}

	void flip(){
		rightWay = !rightWay;
		Vector3 scale = transform.localScale;
		scale.x *= -1;
		transform.localScale = scale;
	}
}
