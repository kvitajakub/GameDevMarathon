using UnityEngine;
using System.Collections;

public class bulletbehav : MonoBehaviour {

	// Use this for initialization
	public bool explosion = false;
	Animator anim;
	int finished = 0;

	void Start () {
		gameObject.tag = "Bullet";
	}

	void OnCollisionEnter2D(Collision2D colObj) {

		if (finished == 0) {
			GameObject go = GameObject.Find ("ExplosionAnimator");
			go.transform.position = transform.position;
			anim = go.GetComponent<Animator> ();
			anim.SetBool ("expBool", true);
			go.GetComponent<AudioSource>().Play();
		}
		if(finished == 1) Destroy (gameObject);
		finished++;
	}
}
