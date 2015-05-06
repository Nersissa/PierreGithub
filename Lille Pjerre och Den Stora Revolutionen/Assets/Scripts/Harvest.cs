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
        private ScrollingText scrollingText;

        private string[] giveInstructions = { "Pierre: -IDAG ÄR DET DAGS. JAG MÅSTE BÖRJA SKÖRDA SÅ ATT JAG INTE FÖRLORAR MIN VETE TILL TORKAN." };
        private string[] pickUpSickle = { "Pierre: -FÖRHOPPNINGSVIS BLIR DET NÅGOT ÖVER TILL MIG.. JAG FÅR SÄTTA IGÅNG DIREKT. FÖRST MÅSTE JAG HÄMTA MIN SKÄRA UPPE PÅ LADULOFTET." };
        private string[] startHarvest = { "Pierre: -SÅDÄR, NU KAN JAG BÖRJA SKÖRDA ADELSMANNENS VETE." };
        private string[] buySickle = { "Pierre: -DÅ VAR JAG FÄRDIG MED ETT FÄLT. MIN SKÄRA ÄR DOCK VÄLDIGT DÅLIG. JAG BORDE NOG TA MIG TILL BYN OCH KÖPA EN NY INNAN JAG FORTSÄTTER. VÄGEN TILL BYN LIGGER BORTOM     TRÄDEN TILL HÖGER." };
        private string[] noSickle = { "Pierre: -JAG MÅSTE HA MIN SKÄRA FÖR ATT KUNNA SKÖRDA!" };

        public HarvestQuest(string Name)
            : base(Name)
        {
            dialogue = GameObject.Find("PermObject").GetComponent<DialogueScript>();
            scrollingText = GameObject.Find("PermObject").GetComponent<ScrollingText>();
            cutScene = GameObject.Find("Nobleman").GetComponent<NobleCutScene>();

            OverlookField = new QuestStep("Kolla hur skörden ser ut", "Gå till ditt fält utanför huset till vänster");
            OverlookField.Created += Instructions;
            OverlookField.StepComplete += StartCutScene;
            AddStep(OverlookField);

            Talking_NobleMan = new QuestStep("Lyssna på vad landsherren har att säga", "");
            Talking_NobleMan.StepComplete += PickUpSicke;
            AddStep(Talking_NobleMan);

            GetSickle = new QuestStep("Hämta din skära", "Skäran finns på laduloftet");
            GetSickle.StepComplete += StartHarvest;
            AddStep(GetSickle);

            Harvest = new QuestStep("Skörda ett dagsverk åt landsherren", "Gå till fältet och använd skäran för att skörda");
            Harvest.StepComplete += BuySickle;
            Harvest.IllegalAction += CantHarvest;
            AddStep(Harvest);

            HeadToTown = new QuestStep("Gå till staden", "Staden är raka vägen åt höger");
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
        }

        void TriggerNextScene(object sender, EventArgs e)
        {
            scrollingText.Display(1, 3);
        }
    }
