using System;
using System.Collections;
using UnityEngine;

    class Harvest : MonoBehaviour
    {
        public HarvestQuest Quest;

        void Start()
        {
            Quest = new HarvestQuest("Uppdrag nummer två");

            GameObject.Find("PermObject").GetComponent<JournalScript>().AddQuest(Quest);
        }
    }

    public class HarvestQuest : Quest
    {
        public QuestStep OverlookField, Talking_NobleMan, GetSickle, Harvest, HeadToTown;

        private DialogueScript dialogue;
        private NobleCutScene cutScene;
        private ScrollingText text;

        private string[] giveInstructions = { "PIERRE: -IDAG ÄR DET DAGS. JAG MÅSTE BÖRJA SKÖRDA SÅ ATT JAG INTE FÖRLORAR MIN VETE TILL TORKAN." };
        private string[] pickUpSickle = { "PIERRE: -FÖRHOPPNINGSVIS BLIR DET NÅGOT ÖVER TILL MIG.. JAG FÅR SÄTTA IGÅNG DIREKT. FÖRST MÅSTE JAG HÄMTA MIN SKÄRA UPPE PÅ LADULOFTET." };
        private string[] startHarvest = { "PIERRE: -SÅDÄR, NU KAN JAG BÖRJA SKÖRDA ADELSMANNENS VETE." };
        private string[] buySickle = { "PIERRE: -DÅ VAR JAG FÄRDIG MED ETT FÄLT. MIN SKÄRA ÄR DOCK VÄLDIGT DÅLIG. JAG BORDE NOG TA MIG TILL BYN OCH KÖPA EN NY INNAN JAG FORTSÄTTER." };
        private string[] noSickle = { "PIERRE: -JAG MÅSTE HA MIN SKÄRA FÖR ATT KUNNA SKÖRDA!" };

        public HarvestQuest(string Name)
            : base(Name)
        {
            dialogue = GameObject.Find("PermObject").GetComponent<DialogueScript>();
            cutScene = GameObject.Find("Nobleman").GetComponent<NobleCutScene>();
            text = GameObject.Find("PermObject").GetComponent<ScrollingText>();

            OverlookField = new QuestStep("KOLLA HUR SKÖRDEN SER UT", "Gå till ditt fält utanför huset till vänster.");
            OverlookField.Created += Instructions;
            OverlookField.StepComplete += StartCutScene;
            AddStep(OverlookField);

            Talking_NobleMan = new QuestStep("LYSSNA PÅ VAD LANDSHERREN HAR ATT SÄGA", "");
            Talking_NobleMan.StepComplete += PickUpSicke;
            AddStep(Talking_NobleMan);

            GetSickle = new QuestStep("HÄMTA SKÄRAN", "Skäran finns på laduloftet.");
            GetSickle.StepComplete += StartHarvest;
            AddStep(GetSickle);

            Harvest = new QuestStep("SKÖRDA VETE ÅT LANDSHERREN", "Gå till fältet och använd skäran med 'E' för att skörda.");
            Harvest.StepComplete += BuySickle;
            Harvest.IllegalAction += CantHarvest;
            AddStep(Harvest);

            HeadToTown = new QuestStep("GÅ TILL STADEN", "Vägen till staden ligger genom gläntan till höger.");
            HeadToTown.StepComplete += TriggerNextScene;
            AddStep(HeadToTown);
        }

        void Instructions(object sender, EventArgs e)
        {
            dialogue.StartDialogue(giveInstructions);
        }

        void StartCutScene(object sender, EventArgs e)
        {
            cutScene.StartCutScene();
        }

        void PickUpSicke(object sender, EventArgs e)
        {
            dialogue.StartDialogue(pickUpSickle);
            GameObject.Find("Sickle").GetComponent<PickUpAble>().Enable(GetSickle);
        }

        void CantHarvest(object sender, EventArgs e)
        {
            dialogue.StartDialogue(noSickle);
        }

        void StartHarvest(object sender, EventArgs e)
        {
            dialogue.StartDialogue(startHarvest);
        }

        void BuySickle(object sender, EventArgs e)
        {
            dialogue.StartDialogue(buySickle);
            GameObject.Find("BlockadeRight").GetComponent<CannotGoThere>().canGoThere = true;
            GameObject.Destroy(GameObject.Find("ColliderRight"));
        }

        void TriggerNextScene(object sender, EventArgs e)
        {
            text.DisplayFinal(1, 3);
        }
    }
