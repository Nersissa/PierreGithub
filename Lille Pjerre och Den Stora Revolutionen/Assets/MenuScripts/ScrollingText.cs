using UnityEngine;
using System.Collections;
using System.IO;

public class ScrollingText : MonoBehaviour
{
    // The varibles we will be using

    bool DisplayingText = false;

    ArrayList Text;

    float ScrollingSpeed = 50;
    float textOffset = 0;

    int levelToLoad;

    GUIStyle style;

    FadingScript fading;

    void Start()
    {
        fading = GetComponent<FadingScript>();

        AdjustStyle();
    }

    void AdjustStyle()
    {
        // Creates the GUI we will be using during the scrolling text

        style = new GUIStyle();

        style.fontSize = 20;

        style.fontStyle = FontStyle.Normal;

        style.normal.textColor = Color.red;
    }

    void OnGUI()
    {
        // If we haven't clicked the Start Button, we haven't started and we won't be needing any text

        if (!DisplayingText)
            return;

        // Handles the scrolling

        textOffset -= (Time.deltaTime * ScrollingSpeed);

        for (var i = 0; i < Text.Count; i++)
        {
            var lastLine = Text[Text.Count - 1];
            var currLine = Text[i];

            // Measures each row

            var labelSize = style.CalcSize(new GUIContent(currLine.ToString()));

            // Varibles for both x- and y-axis positions

            var labelPosY = Screen.height + (i * labelSize.y + textOffset);
            var labelPosX = (Screen.width / 2) - (labelSize.x / 2);

            // Controlls the color of each line
            // Fades in / out when close to a border

            var alpha = Mathf.Sin((labelPosY / Screen.height) * 180 * Mathf.Deg2Rad);

            GUI.color = new Color(1, 1, 1, alpha);

            // Draws the actual label, fixing size and position
            // Via the variables above

            GUI.depth = -1;

            GUI.Label(new Rect(labelPosX, labelPosY, labelSize.x, labelSize.y), currLine.ToString(), style);

            // If the last line has reached the top of the screen
            // We are finished and can start the game
            // And stop displaying the text

            if (currLine == lastLine && labelPosY <= 0)
            {
                Application.LoadLevel("Act" + levelToLoad.ToString() + "Scene1");
                DisplayingText = false;
                fading.Begin(1);
            }
        }
    }

    internal void Display(int ActNumber)
    {
        // Hides the menu buttons

        GetComponent<MenuButtonsFactory>().enabled = false;

        //  Makes sure the correct level is loaded

        levelToLoad = ActNumber;

        // Displays the correct text depending on act

        Text = Scenes.GetActText(ActNumber);
        DisplayingText = true;
        fading.Begin(1);
    }
}