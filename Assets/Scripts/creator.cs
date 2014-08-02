using UnityEngine;
using System.Collections;

public class creator : MonoBehaviour {

	public GameObject thePrefab;

	Vector3 initPos = new Vector3(0, 0, 0);

	const int mazeHalfSize = 100;

	const int rowPosTop = mazeHalfSize;
	const int rowPosBottom = -mazeHalfSize;
	const int colPosLeft = -mazeHalfSize;
	const int colPosRight = mazeHalfSize;

	const int horStep = 3;
	const int verStep = 6;

	enum genState {
		BLANK,
		BRICK
	};

	void Start () {
		Time.timeScale = 1f;

		genState state = genState.BLANK;

		for (int row = rowPosTop; row >= rowPosBottom; row -= horStep) {
			for (int col = colPosLeft; col <= colPosRight; col += verStep) {
				Vector3 pos = initPos;
				initPos.x = row;
				initPos.y = col;

				if (state == genState.BRICK) {
					GameObject instance = Instantiate(thePrefab, pos, transform.rotation) as GameObject;
				}

				state = Random.Range(1, 10) > 5 ? genState.BLANK : genState.BRICK;
			}
		}


	}
}
