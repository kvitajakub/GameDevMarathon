using UnityEngine;
using System.Collections;

public class CharacterScript : MonoBehaviour {


	public float maxSpeed = 100f;
	public bool rightWay = true;
	Animator anim;

	bool onGround = false; 
	public Transform groundCheck;
	float grRadius = 0.2f;
	public LayerMask whatIsGround; // water | etc.
	public float jumpForce = 700f;
	public int shooting = 0;
	float move = 10f;

	public AudioSource[] audios;

	public GUITexture left,right,jump,shot;

	bool leftMove, rightMove = false;
	// Use this for initialization

	public int score;
	public GUIText guiScore;

	// time to update score
	private float time = 0.0f;
	public float interpolatedPeriod = 3f;

	void Start () {
		anim = GetComponent<Animator>();
		audios = gameObject.GetComponents<AudioSource>();
		score = 0;
		guiScore.text = "Score: 0";
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		onGround = Physics2D.OverlapCircle(groundCheck.position, grRadius, whatIsGround);

		if (anim.GetCurrentAnimatorStateInfo(0).IsName("Stop")) {
			audios[1].Play();
			shooting = 3;
		}

		anim.SetBool("isGround", onGround);
		anim.SetInteger("Shoot", shooting);
		anim.SetFloat("jumpSpeed", rigidbody2D.velocity.y);

		if(!leftMove || !rightMove) move = Input.GetAxis("Horizontal"); 

		anim.SetFloat("Speed",Mathf.Abs (move));
		rigidbody2D.velocity = new Vector2 (move * maxSpeed, rigidbody2D.velocity.y);

		if (move > 0 && !rightWay) {
			flip();
		} else if (move < 0 && rightWay) {
			flip();
		}
	}

	void Update(){
		if (onGround && Input.GetKeyDown (KeyCode.UpArrow)) { // radsi napsat KeyController
			anim.SetBool("isGround", false);
			audios[0].Play();
			rigidbody2D.AddForce(new Vector2(0,jumpForce));
		}
		if (Input.GetKeyDown (KeyCode.LeftControl) ) {
			shooting = 1;

		} else if (Input.GetKeyUp (KeyCode.LeftControl)) {
			shooting = 2;
		}

		Input.multiTouchEnabled = true;
		// if(GameObject.Find("Mobile Controller") != NULL && Input.touchCount > 0)
		if (((Application.platform == RuntimePlatform.Android) ||
		(Application.platform == RuntimePlatform.WP8Player)) && Input.touchCount > 0) {
			Touch t = Input.GetTouch(0);

			if(t.phase == TouchPhase.Stationary || t.phase == TouchPhase.Began){
				if(left.HitTest(t.position, Camera.main)){
					leftMove = true;
				}
				if(right.HitTest(t.position, Camera.main)){
					rightMove = true;
				}
				if(onGround && jump.HitTest(t.position, Camera.main)){
					anim.SetBool("isGround", false);
					rigidbody2D.AddForce(new Vector2(0,jumpForce));
				}
			}
			
			if(t.phase == TouchPhase.Ended){
				leftMove = rightMove = false;
			}
		}

		// update Score
		time += Time.deltaTime;
		if (time >= interpolatedPeriod) {
			time = 0.0f;
			updateScore();
		}
	}

	void flip(){
		rightWay = !rightWay;
		Vector3 scale = transform.localScale;
		scale.x *= -1;
		transform.localScale = scale;
	}

	void OnCollisionEnter2D(Collision2D colObj) {
		if (colObj.gameObject.tag == "enemy" ||
		    colObj.gameObject.tag == "floor") {
			OnDestroy();			
		}
	}

	void OnDestroy() {
		audios [2].Play ();
		Time.timeScale = 0.0f;
		transform.gameObject.AddComponent<GameOverScript>();
		//Time.timeScale = 0;
	}

	void updateScore() {
		score += 1;
		Debug.Log(score);
		guiScore.text = "Score: " + score;
	}
}
