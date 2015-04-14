using UnityEngine;
using System.Collections;

public class MenuButtonsFactory : MonoBehaviour
{
    #region Variables

    enum ScreenState
    {
        StartScreen,
        ActScreen,
    }

    private float buttonWidth,
                  buttonHeight,
                  topButtonX,
                  topButtonY;

    ScreenState state = ScreenState.StartScreen;

    ScrollingText introText;

    // Sets a method which is used to wait an amount of seconds before proceeding

    void Start()
    {
        introText = GetComponent<ScrollingText>();

        buttonWidth = Screen.width / 4;
        buttonHeight = Screen.height / 8;

        topButtonX = Screen.width / 2 - buttonWidth / 2;
        topButtonY = Screen.height / 2 - buttonHeight / 2;

        // Because of the fading function, we do not want to destroy this gameobject right away after starting the game

        DontDestroyOnLoad(gameObject);
    }

    #endregion

    #region Buttons

    void OnGUI()
    {
        switch (state)
        {
            case ScreenState.StartScreen:

                if (GUI.Button(new Rect(topButtonX, topButtonY, buttonWidth, buttonHeight), "Play From Start"))
                    introText.Display(1);

                if (GUI.Button(new Rect(topButtonX, topButtonY + buttonHeight * 2, buttonWidth, buttonHeight), "Choose Act"))
                    state = ScreenState.ActScreen;


                break;
            case ScreenState.ActScreen:

                if (GUI.Button(new Rect(10, 10, 100, 50), "Go Back"))
                    state = ScreenState.StartScreen;

                if (GUI.Button(new Rect(topButtonX, topButtonY, buttonWidth, buttonHeight), "Act Two"))
                    introText.Display(2);

                break;
        }
    }

    #endregion
}
