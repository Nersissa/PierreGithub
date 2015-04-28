using UnityEngine;
using System.Collections;

public class ToolTipScript : MonoBehaviour
{
    // Variables

    GUIStyle textStyle;

    Rect ToolTipBox;
    float boxWidth, boxHeight;

    string DisplayingText;
    bool TextIsDisplaying = false;

    public bool StartedShowingText = false;

    void Start()
    {
        // Sets up our own style

        textStyle = new GUIStyle();

        // Since we have limited space and background
        // We want a custom colour and wrap the words

        textStyle.normal.textColor = Color.white;
        textStyle.wordWrap = true;

        boxWidth = Screen.width / 7;
        boxHeight = Screen.height / 12;

        ToolTipBox = new Rect(0, Screen.height - boxHeight, boxWidth, boxHeight);
    }

    void OnGUI()
    {
        GUILayout.BeginArea(ToolTipBox);
        GUILayout.Box(DisplayingText, textStyle);
        GUI.backgroundColor = Color.black;
        GUILayout.EndArea();
    }

    void Update()
    {
        if (TextIsDisplaying && Input.GetButtonDown("Use"))
            HideToolTip();
    }

    IEnumerator animateText(string strComplete)
    {
        DisplayingText = "";

        for (int i = 0; i < strComplete.Length; i++)
        {
            // Needed for calculating the height of the text

            GUIContent content = new GUIContent(DisplayingText + "\n");

            // If there is space left, add letters one by one to the diplaying text 

            if (textStyle.CalcHeight(content, boxWidth) < boxHeight)
                DisplayingText += strComplete[i];

            // time to wait before adding another letter

            yield return new WaitForSeconds(0.01f);
        }

        TextIsDisplaying = true;
    }

    public void ShowToolTip(string ToolTip)
    {

        GameObject.Find("Player").GetComponent<PlayerMovement>().Disable();

        DisplayingText = "";
        StartedShowingText = true;
        StartCoroutine(animateText(ToolTip));
    }

    void HideToolTip()
    {
        GameObject.Find("Player").GetComponent<PlayerMovement>().Enable();

        StartedShowingText = false;
        TextIsDisplaying = false;
        DisplayingText = "";
    }
}
