using UnityEngine;
using System.Collections;

public class SpeakingScript : MonoBehaviour
{
    public Texture2D backgroundTexture;

    public int boxX, boxY, boxW, boxH;

    bool showtext1, showtext2, showtext3;

    string text1 = "Text One", text2 = "Text Two", text3 = "Text Three";

    float textTimer = 10;

    void OnGUI()
    {
        if (Input.GetKey(KeyCode.A))
            showtext1 = true;

        if (Input.GetKey(KeyCode.S))
            showtext2 = true;

        if (Input.GetKey(KeyCode.D))
            showtext3 = true;

        if (showtext1)
            ShowText(text1, ref showtext1);

        if (showtext2)
            ShowText(text2, ref showtext2);

        if (showtext3)
            ShowText(text3, ref showtext3);
    }

    void ShowText(string text, ref bool inputBool)
    {
        //Starts the countdown for how long the text will be displaying

        textTimer -= Time.deltaTime;

        //Sets the area in which the text will be diplayed

            GUI.Box(new Rect(boxX, boxY, boxW, boxH), text);

        // When the timer reaches zero, it resets the timer
        // and turns the bool to false so it isn't called repeatedly

        if (textTimer <= 0)
        {
            inputBool = false;
            textTimer = 10;
        }
    }
}
