using UnityEngine;
using System.Collections;

public class bulletscr : MonoBehaviour {

	public Rigidbody2D projectile;
	public int speed = 30;

	// Update is called once per frame
	void Update () {
	
		CharacterScript charscr = (CharacterScript)transform.parent.gameObject.GetComponent("CharacterScript");

		if(charscr.shooting == 3){

			Rigidbody2D clone = (Rigidbody2D)Instantiate(projectile, transform.position, transform.rotation);

			clone.velocity = transform.TransformDirection( new Vector3 (speed*(charscr.rightWay?1:-1), speed/2));

			Destroy (clone.gameObject, 5);
			charscr.shooting = 0;
		}
	}
}


