using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class JournalScript : MonoBehaviour
{
    public Texture2D Background;
    public Texture2D TextBackground;

    private int selectedQuest = 0;
    private bool displaying;

    private List<Quest> Quests;
    private GUIStyle questHeader;

    void Awake()
    {
        Quests = new List<Quest>();

        questHeader = new GUIStyle();
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

        float abstractPosX = texPositionX;
        float abstractPosY = texPositionY;
        float abstractWidth = texWidth * 0.6f;
        float abstractHeight = texHeight / 10;

        float descriptionPosX = abstractPosX + abstractWidth + 2;
        float descriptionPosY = abstractPosY;
        float descriptionWidth = texWidth * 0.3f;
        float descriptionHeight = abstractHeight;

        GUI.DrawTexture(new Rect(texPositionX, texPositionY, texWidth, texHeight), Background);

        for (int nr = 0; nr < Quests.Count; nr++)
        {
            if (GUI.Button(new Rect(abstractPosX, abstractPosY + abstractPosY * nr, abstractWidth, abstractHeight), Quests[nr].Name))
                selectedQuest = nr;
        }


        for (int nr = 0; nr < Quests[selectedQuest].NrOfSteps; nr++)
        {
            GUILayout.BeginArea(new Rect(descriptionPosX, descriptionPosY + descriptionHeight * nr, descriptionWidth, descriptionHeight));

            if (Quests[selectedQuest].GetStep(nr).Completed)
                GUILayout.Label(Quests[selectedQuest].GetStep(nr).Objective);
            else
            {
                GUILayout.Label(Quests[selectedQuest].GetStep(nr).Objective + "\n" + Quests[selectedQuest].GetStep(nr).Description, questHeader);
                GUILayout.EndArea();
                break;
            }
            GUILayout.EndArea();
        }
    }
}
