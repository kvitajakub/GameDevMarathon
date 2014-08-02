using UnityEngine;
using System.Collections;

/// <summary>
/// Start or quit the game
/// </summary>
public class GameOverScript : MonoBehaviour
{
	void OnGUI()
	{
		const int buttonWidth = 60;
		const int buttonHeight = 30;
		
		if (
			GUI.Button(
			// Center in X, 1/3 of the height in Y
			new Rect(
			Screen.width / 2 - (buttonWidth / 2),
			(1 * Screen.height / 3) - (buttonHeight / 2),
			buttonWidth,
			buttonHeight
			),
			"Again!"
			)
			)
		{
			//Time.timeScale = 1;
			// Reload the level

			Application.LoadLevel("GamePlay");
		}
		
		if (
			GUI.Button(
			// Center in X, 2/3 of the height in Y
			new Rect(
			Screen.width / 2 - (buttonWidth / 2),
			(2 * Screen.height / 3) - (buttonHeight / 2),
			buttonWidth,
			buttonHeight
			),
			"I give up"
			)
			)
		{
			//Time.timeScale = 1;
			// Reload the level

			Application.LoadLevel("Menu");
		}
	}
}