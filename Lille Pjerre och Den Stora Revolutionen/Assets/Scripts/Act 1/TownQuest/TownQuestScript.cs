using UnityEngine;
using System.Collections;
using System;

public class TownQuestScript : MonoBehaviour
{
    TownQuest Quest;

    private bool questCreated;
    void Start()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Jacques" && !questCreated)
        {
            Quest = new TownQuest();
            GameObject.Find("PermObject").GetComponent<JournalScript>().AddQuest(Quest);
            questCreated = true;
        }
    }
    

}


public class TownQuest : Quest
{
    public QuestStep MeetJacques, TryBuySickle, GoToJacques, BuySickle;

    private string[] FirstJacquesDialogue = {
                                                "JACQUES: BONJOUR(GODDAG) PIERRE! VART ÄR DU PÅ VÄG IDAG, MIN VÄN? ",
                                                "PIERRE: BONJOUR JACQUES! MIN GAMLA SKÄRA BÖRJAR ROSTA SÖNDER, OCH JAG BEHÖVER EN NY, SÅ JAG SKA TILL MARKNADEN!",
                                                "JACQUES: OKEJ, TITTA FÖRBI PÅ VÄGEN TILLBAKA!"
                                            };
    private DialogueScript dialogue;

    public TownQuest()
        : base("Uppdrag Nummer tre")
    {
        GameObject.Find("PermObject").GetComponent<JournalScript>().activated = true;
        dialogue = GameObject.Find("PermObject").GetComponent<DialogueScript>();
        MeetJacques = new QuestStep("MÖT JACQUES", "JACQUES BOR I HUSET LÄNGST UT I STADEN");

        MeetJacques.Created += JacquesFirstDialogue;

        AddStep(MeetJacques);

    }

    void JacquesFirstDialogue(object sender, EventArgs e)
    {
        dialogue.StartDialogue(FirstJacquesDialogue);
    }




}