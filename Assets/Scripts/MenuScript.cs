using UnityEngine;
using System.Collections;

public class MenuScript : MonoBehaviour
{
  void OnGUI()
  {
    const int buttonWidth = 60;
    const int buttonHeight = 30;

    // Draw a button to start the game
    if (
      GUI.Button(
        // Center in X, 2/3 of the height in Y
        new Rect(
          Screen.width / 1.15f - (buttonWidth / 2),
          (Screen.height / 6) - (buttonHeight / 2),
          buttonWidth,
          buttonHeight
        ),
        "Start!"
      )
    )
    {
      // On Click, load the first level.
      // "Stage1" is the name of the first scene we created.
			Application.LoadLevel("GamePlay");
    }
  }
}