using UnityEngine;
using System.Collections;
using System;

public class WalkToTownScript : MonoBehaviour
{
    public WalkToTownQuest Quest;
    void Start()
    {
        Quest = new WalkToTownQuest();

        GameObject.Find("PermObject").GetComponent<JournalScript>().AddQuest(Quest);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Trigger")
        {
            Quest.GetToTown.Complete();
        }
    }
}

public class WalkToTownQuest : Quest
{
    public QuestStep GetToTown;

    private string[] WalkPrompt = {
                                      "PIERRE: JAG MÅSTE BARA FORTSÄTTA ÅT HÖGER FÖR ATT KOMMA TILL STADEN!"
                                  };

    public WalkToTownQuest()
        : base("Walk to town")
    {
        GetToTown = new QuestStep("TA DIG TILL STADEN", "STADEN LIGGER FÖRBI BRON ÅT HÖGER");

        GetToTown.Created += StartWalking;

        GetToTown.StepComplete += TriggerTownScene;

        AddStep(GetToTown);
    }

    void TriggerTownScene(object sender, EventArgs e)
    {
        GameObject.Find("PermObject").GetComponent<Scenes>().TryNextScene();
    }

    void StartWalking(object sender, EventArgs e)
    {
        GameObject.Find("PermObject").GetComponent<DialogueScript>().StartDialogue(WalkPrompt);
    }
}
