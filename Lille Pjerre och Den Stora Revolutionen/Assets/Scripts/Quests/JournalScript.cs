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
    private GUIStyle inCompleted;
    private GUIStyle completed;

    void Awake()
    {
        Quests = new List<Quest>();

        inCompleted = new GUIStyle();
        inCompleted.normal.textColor = Color.black;
        inCompleted.font = font;

        completed = new GUIStyle();
        completed.normal.textColor = Color.green;
        completed.font = font;
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

        float abstractPosX = texPositionX + offsetX;
        float abstractPosY = texPositionY + offsetY;
        float abstractWidth = texWidth * 0.6f - offsetX;
        float abstractHeight = texHeight / 10;

        float descriptionPosX = abstractPosX + abstractWidth + (offsetX * 1.5f);
        float descriptionPosY = abstractPosY;
        float descriptionWidth = texWidth * 0.4f - offsetX * 3;
        float descriptionHeight = abstractHeight;

        GUI.DrawTexture(new Rect(texPositionX, texPositionY, texWidth, texHeight), Background);

        for (int nr = 0; nr < Quests.Count; nr++)
        {
            GUI.skin.font = font;

            if (GUI.Button(new Rect(abstractPosX, abstractPosY + abstractPosY * nr, abstractWidth, abstractHeight), Quests[nr].Name))
                selectedQuest = nr;
        }


        for (int nr = 0; nr < Quests[selectedQuest].NrOfSteps; nr++)
        {
            GUILayout.BeginArea(new Rect(descriptionPosX, descriptionPosY + descriptionHeight * nr, descriptionWidth, descriptionHeight));

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
