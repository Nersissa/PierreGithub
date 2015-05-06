using UnityEngine;
using System.Collections;

public class Interactable : MonoBehaviour
{
    private bool inside = false;

    public Texture GuidancePicture;
    private Rect guidanceBox;
    private int boxW, boxH;

    void Start()
    {
        boxW = Screen.width / 25;
        boxH = boxW;

        guidanceBox = new Rect(Screen.width / 2 - boxW / 2, Screen.height / 2 - boxH, boxW, boxH);
    }

    void OnGUI()
    {
        if (inside)
            GUI.DrawTexture(guidanceBox, GuidancePicture);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Player")
            inside = true;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.name == "Player")
            inside = false;
    }
}
