using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class JournalScript : MonoBehaviour
{
    public Texture2D Background;
    public Font font;

    private int selectedQuest = 0;
    private bool displaying;

    private List<Quest> Quests;

    private GUIStyle completed;
    private GUIStyle inCompleted;

    void Awake()
    {
        Quests = new List<Quest>();

        completed = new GUIStyle();
        completed.font = font;
        completed.normal.textColor = Color.white;

        inCompleted = new GUIStyle();
        inCompleted.font = font;
        inCompleted.normal.textColor = Color.black;
    }

    void Update()
    {
        if (Input.GetButtonDown("Journal"))
            displaying = !displaying;
    }

    public void AddQuest(Quest Quest)
    {
        Quests.Add(Quest);
        Quest.IsCreated();
    }

    void OnGUI()
    {
        if (!displaying)
            return;

        float texPositionX = Screen.width / 10;
        float texPositionY = Screen.height / 10;
        float texWidth = Screen.width * 0.8f;
        float texHeight = Screen.height * 0.8f;

        float offsetX = texWidth / 50;
        float offsetY = texHeight / 60;

        float abstractPosX = texPositionX;
        float abstractPosY = texPositionY;
        float abstractWidth = texWidth * 0.6f;
        float abstractHeight = texHeight / 10;

        float descriptionPosX = abstractPosX + abstractWidth + offsetX;
        float descriptionPosY = abstractPosY;
        float descriptionWidth = texWidth * 0.3f;
        float descriptionHeight = abstractHeight;

        GUI.DrawTexture(new Rect(texPositionX, texPositionY, texWidth, texHeight), Background);

        for (int nr = 0; nr < Quests.Count; nr++)
        {
            
            if (GUI.Button(new Rect(abstractPosX + offsetX, abstractPosY + abstractPosY * nr + offsetY, abstractWidth - offsetX, abstractHeight - offsetY), Quests[nr].Name))
                selectedQuest = nr;
        }

        for (int nr = 0; nr < Quests[selectedQuest].NrOfSteps; nr++)
        {
            GUILayout.BeginArea(new Rect(descriptionPosX, descriptionPosY + descriptionHeight * nr + offsetY, descriptionWidth - offsetX, descriptionHeight - offsetY));

            if (Quests[selectedQuest].GetStep(nr).Completed)
                GUILayout.Label(Quests[selectedQuest].GetStep(nr).Objective, completed);
            else
            {
                GUILayout.Label(Quests[selectedQuest].GetStep(nr).Objective + "\n" + Quests[selectedQuest].GetStep(nr).Description, inCompleted);
                GUILayout.EndArea();
                break;
            }

            GUILayout.EndArea();
        }
    }
}
