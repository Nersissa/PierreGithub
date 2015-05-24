using UnityEngine;
using System.Collections;

public class FadingScript : MonoBehaviour
{
    // Sets the variables we will be using

    public Texture2D fadeOutTexture;

    int drawDepth = 1;
    int fadeDir = -1;

    float fadeSpeed = 0.5f;
    float alpha = 0.0f;

    void OnGUI()
    {
        // Handles the fading mechanics

        alpha += fadeDir * fadeSpeed * Time.deltaTime;

        alpha = Mathf.Clamp01(alpha);

        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, alpha);
        GUI.depth = drawDepth;
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), fadeOutTexture);
    }

    public float Begin(int direction)
    {
        if (direction > 0)
            GameObject.Find("PermObject").GetComponent<JournalScript>().activated = false;
        else
            GameObject.Find("PermObject").GetComponent<JournalScript>().activated = true;

        //around this point, we stopped caring

        if (Application.loadedLevelName == "MainMenuScene")
        {
            GameObject.Find("PermObject").GetComponent<JournalScript>().activated = false;
        }

        // When called, the fading is started

        fadeDir = direction;
        return (fadeSpeed);
    }
}
