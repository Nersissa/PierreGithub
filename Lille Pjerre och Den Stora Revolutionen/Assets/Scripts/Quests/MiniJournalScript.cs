using UnityEngine;
using System.Collections;

public class MiniJournalScript : JournalScript
{

    void Start()
    {

    }

    void Update()
    {

    }

    void OnGUI()
    {
        if (displaying)
            return;

        float Width = Screen.width / 20;
        float Height = Screen.height / 10;
        float X = Screen.width - Width;
        float Y = Height;


        if (GUI.Button(new Rect(X, Y, Width, Height), "Quests"))
            displaying = true;



    }
}
