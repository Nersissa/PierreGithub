using UnityEngine;
using System.Collections;
using System;

public class SeedQuest : Quest
{
    public QuestStep PickUpSeeds, SowSeeds, Rest;

    private DialogueScript dialogue;
    private ScrollingText scrollingText;

    private string[] pickUpSeedsPrompt = { "PIERRE: -VILKEN VACKER VÅRDAG! IDAG PASSAR DET UTMÄRKT ATT SÅ MITT VETE INFÖR SOMMAREN. STYR MIG MED PILTANGENTERNA SÅ JAG KAN HÄMTA MINA FRÖN LÄNGST BORT I LADULOFTET." };
    private string[] goSowPrompt = { "PIERRE: -VAD BRA, NU HAR JAG MINA FRÖN! STYR MIG TILLBAKA TILL HUSET OCH VIDARE, SÅ JAG KAN SÅ MIN VETE!" };
    private string[] illegalSowPrompt = { "PIERRE: -JAG BEHÖVER DOCK MINA FRÖN FÖR ATT KUNNA SÅ.. DE LIGGER PÅ LADULOFTET TILL VÄNSTER, STYR MIG DIT SÅ JAG KAN HÄMTA DEM!" };
    private string[] illegalSleepPrompt = { "PIERRE: -JAG KAN INTE VILA ÄN. MINA UPPGIFTER ÄR INTE KLARA!" };
    private string[] goToSleepPrompt = { "PIERRE: -PUH, DET VAR HÅRT ARBETE, MEN NU ÄR DET KLART!\nSTYR MIG IN I MITT HUS, SÅ KAN JAG GÅ OCH LÄGGA MIG FÖR DAGEN." };

    public SeedQuest(string Name)
        : base(Name)
    {
        dialogue = GameObject.Find("PermObject").GetComponent<DialogueScript>();
        scrollingText = GameObject.Find("PermObject").GetComponent<ScrollingText>();

        PickUpSeeds = new QuestStep("Plocka upp fröna på laduloftet.", "Du hittar ladan till vänster om Pierres hus");
        SowSeeds = new QuestStep("Så fröna på fältet.", "Fältet finns till höger om Pierres Hus");
        Rest = new QuestStep("Gå till sängen för att vila", "Sängen finns inuti Pierres hus");

        PickUpSeeds.Created += Instructions;

        PickUpSeeds.StepComplete += PickUpSeedsComplete;
        SowSeeds.StepComplete += SowSeedsComplete;
        Rest.StepComplete += TriggerNextScene;

        SowSeeds.IllegalAction += TryToSowSeeds;
        Rest.IllegalAction += DontSleepYet;

        AddStep(PickUpSeeds);
        AddStep(SowSeeds);
        AddStep(Rest);
    }

    void Instructions(object sender, EventArgs e)
    {
        dialogue.StartDialogue(pickUpSeedsPrompt);
    }

    void DontSleepYet(object sender, EventArgs e)
    {
        dialogue.StartDialogue(illegalSleepPrompt);
    }

    void TriggerNextScene(object sender, EventArgs e)
    {
        scrollingText.Display(1, 2, GameObject.Find("Player").GetComponent<PlayerMovement>());
    }

    void TryToSowSeeds(object sender, EventArgs e)
    {
        dialogue.StartDialogue(illegalSowPrompt);
    }

    void SowSeedsComplete(object sender, EventArgs e)
    {
        dialogue.StartDialogue(goToSleepPrompt);
    }

    void PickUpSeedsComplete(object sender, EventArgs e)
    {
        dialogue.StartDialogue(goSowPrompt);
    }
}
