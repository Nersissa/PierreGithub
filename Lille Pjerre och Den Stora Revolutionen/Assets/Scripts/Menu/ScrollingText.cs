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

    int ActToLoad;
    int SceneToLoad;

    GUIStyle style;

    FadingScript fading;
    Scenes scenes;

    void Start()
    {
        fading = GetComponent<FadingScript>();
        scenes = GetComponent<Scenes>();

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

            GUI.Label(new Rect(labelPosX, labelPosY, labelSize.x, labelSize.y), currLine.ToString(), style);

            // If the last line has reached the top of the screen
            // We are finished and can start the game
            // And stop displaying the text

            if (currLine == lastLine && labelPosY <= 0)
            {
                scenes.LoadScene(ActToLoad, SceneToLoad);
                fading.Begin(-1);
                DisplayingText = false;
            }
        }
    }

    public void Display(int ActNumber, int SceneNumber, MonoBehaviour script = null)
    {
        // Hides scripts if needed, like menu buttons

        if (script != null)
            script.enabled = false;

        //  Makes sure the correct Scene is loaded afterwards

        ActToLoad = ActNumber;
        SceneToLoad = SceneNumber;

        // Displays the correct text depending on act

        Text = scenes.GetActText(ActNumber, SceneNumber);
        DisplayingText = true;
        fading.Begin(1);
    }
}