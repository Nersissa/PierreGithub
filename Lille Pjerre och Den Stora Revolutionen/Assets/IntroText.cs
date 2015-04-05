using UnityEngine;
using System.Collections;
using System.IO;

public class IntroText : MonoBehaviour
{
    #region Variables

    // The varibles we will be using

    internal bool IsFinished = false;
    internal bool ShowText = false;

    ArrayList Text = new ArrayList();

    float ScrollingSpeed = 50;
    float textOffset = 0;

    GUIStyle style;

    void Start()
    {
        ReadFile();
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

    void ReadFile()
    {
        // First of all we need to find the file
        // And for that we need the name

        var filename = "IntroText";

        // Then we search through the entire asset folder

        var paths = Directory.GetFiles(Application.dataPath, filename + ".txt", SearchOption.AllDirectories);

        // Tell the Streamreader which file to read

        var reader = new StreamReader(paths[0], System.Text.Encoding.Default);

        // Read and save every line of the file

        while (!reader.EndOfStream)
            Text.Add(reader.ReadLine());

        reader.Close();
    }

    #endregion
    #region TextManagement

    void OnGUI()
    {
        // If we haven't clicked the Start Button, we haven't started and we won't be needing any text

        if (!ShowText)
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

            if (currLine == lastLine)
                if (labelPosY <= 0)
                    Application.LoadLevel(Application.loadedLevel + 1);
        }
    }

    internal void Show()
    {
        // Just a method which triggers the text to show
        ShowText = !ShowText;
    }

    #endregion
}