using UnityEngine;
using System.Collections;

public class Interactable : MonoBehaviour
{
    private bool inside = false;
    private bool ladder = false;

    public Texture GuidancePicture;
    private Rect guidanceBox;
    private int boxW, boxH;

    void Start()
    {
        boxW = Screen.width / 25;
        boxH = boxW;

        guidanceBox = new Rect(Screen.width / 2 - boxW / 2, Screen.height / 2 - boxH, boxW, boxH);

        Enable();

    }

    void OnGUI()
    {
            if (inside)
            {
                GUI.DrawTexture(guidanceBox, GuidancePicture);

                if (ladder)
                    guidanceBox = new Rect(Screen.width / 2 - boxW / 2, Screen.height / 2 - boxH - (boxH / 2), boxW, boxH * 2);
            }  
        
        
    }

    public void Disable()
    {
        enabled = false;
    }

    public void Enable()
    {
        enabled = true;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Player")
            inside = true;
        if (this.gameObject.name == "Ladder")
            ladder = true;        
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.name == "Player")
            inside = false;
        if (this.gameObject.name == "Ladder")
            ladder = false;
    }
}
