using UnityEngine;
using System.Collections;
using System;

public class WalkToTownScript : MonoBehaviour
{
    public WalkToTownQuest quest;
    void Start()
    {
        quest = new WalkToTownQuest();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Trigger")
        {
            quest.GetToTown.Complete();
        }
    }
}

public class WalkToTownQuest : Quest
{
    public QuestStep GetToTown;

    public WalkToTownQuest()
        : base("Walk to town")
    {
        GetToTown = new QuestStep("TA DIG TILL STADEN", "STADEN LIGGER FÖRBI BRON ÅT HÖGER");

        GetToTown.StepComplete += TriggerTownScene;
    }

    void TriggerTownScene(object sender, EventArgs e)
    {
        GameObject.Find("PermObject").GetComponent<Scenes>().TransitionToScene();
    }
}
