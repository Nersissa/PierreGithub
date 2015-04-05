using UnityEngine;
using System.Collections;

public class MainMenuScript : MonoBehaviour
{
    #region Variables

    // Sets the variables we will be using

    public Texture2D fadeOutTexture;

    int drawDepth = 1;
    int fadeDir = -1;
    int nextLevel;

    float fadeSpeed = 0.5f;
    float alpha = 0.0f;

    bool clickedPlay = false;

    IntroText introText;

    // Sets a method which is used to wait an amount of seconds before proceeding

    IEnumerator WaitForGame()
    {
        yield return new WaitForSeconds(3);
        if (!Application.loadedLevelName.Contains("MainMenu"))
            Destroy(gameObject);
    }

    void Start()
    {
        // Gets the IntroText Component in order to start the scrolling text

        introText = GetComponent<IntroText>();

        // Sets the next level to be one index higher than our current level index

        nextLevel = Application.loadedLevel + 1;

        // Because of the fading function, we do not want to destroy this gameobject right away after starting the game

        DontDestroyOnLoad(gameObject);
    }

    #endregion

    #region LevelManagement

    void OnLevelWasLoaded()
    {
        // This is called when a new level is loaded, and we begin fading from 0 to 100

        BeginFade(-1);

        // Calls the waiting method, to give the fading some time

        StartCoroutine(WaitForGame());
    }

    #endregion

    #region Buttons and fading

    void OnGUI()
    {
        // If we haven't clicked the Play Game button yet, display the button

        if (!clickedPlay)
            if (GUI.Button(new Rect(200, 200, 200, 200), "Play Game"))
            {
                // If we clicked it, start fading, start showing the text

                clickedPlay = true;
                BeginFade(1);
                introText.Show();
            }

            // Handles the fading mechanics

            alpha += fadeDir * fadeSpeed * Time.deltaTime;

            alpha = Mathf.Clamp01(alpha);

            GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, alpha);
            GUI.depth = drawDepth;
            GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), fadeOutTexture);
    }

    public float BeginFade(int direction)
    {
        // When called, the fading is started

        fadeDir = direction;
        return (fadeSpeed);
    }

    #endregion
}
