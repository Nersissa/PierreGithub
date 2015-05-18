using UnityEngine;
using System.Collections;
using System;

public class SeedQuest : Quest
{
    public QuestStep PickUpSeeds, SowSeeds, Rest;

    private DialogueScript dialogue;
    private Interactable interactable;
    private Scenes scenes;

    private string[] pickUpSeedsPrompt = { "PIERRE: -VILKEN VACKER VÅRDAG! IDAG PASSAR DET UTMÄRKT ATT SÅ MITT VETE INFÖR SOMMAREN. TRYCK PÅ 'J' FÖR ATT SE VAD SOM BEHÖVER GÖRAS." };
    private string[] goSowPrompt = { "PIERRE: -VAD BRA, NU HAR JAG MINA FRÖN OCH KAN BÖRJA SÅ." };
    private string[] illegalSowPrompt = { "PIERRE: -JAG BEHÖVER DOCK MINA FRÖN FÖR ATT KUNNA SÅ.. DE LIGGER PÅ LADULOFTET!" };
    private string[] illegalSleepPrompt = { "PIERRE: -JAG KAN INTE VILA ÄN. MINA UPPGIFTER ÄR INTE KLARA!" };
    private string[] goToSleepPrompt = { "PIERRE: -DÅ VAR ETT FÄLT KLART! DET BÖRJAR DOCK BLI SENT, SÅ JAG FÅR GÅ OCH LÄGGA MIG FÖR DAGEN." };

    public SeedQuest(string Name)
        : base(Name)
    {
        dialogue = GameObject.Find("PermObject").GetComponent<DialogueScript>();
        interactable = GameObject.Find("Field").GetComponent<Interactable>();
        scenes = GameObject.Find("PermObject").GetComponent<Scenes>();

        PickUpSeeds = new QuestStep("PLOCKA UPP FRÖNA PÅ LADULOFTET", "Du hittar ladan till vänster om Pierres hus.");
        SowSeeds = new QuestStep("SÅ FRÖNA PÅ FÄLTET", "Fältet finns till höger om Pierres Hus.");
        Rest = new QuestStep("GÅ TILL SÄNGEN FÖR ATT VILA", "Sängen finns inuti Pierres hus.");

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
        GameObject.Find("Seeds").GetComponent<PickUpAble>().Enable(PickUpSeeds);
    }

    void DontSleepYet(object sender, EventArgs e)
    {
        dialogue.StartDialogue(illegalSleepPrompt);
    }

    void TriggerNextScene(object sender, EventArgs e)
    {
        scenes.TransitionToScene();
    }

    void TryToSowSeeds(object sender, EventArgs e)
    {
        dialogue.StartDialogue(illegalSowPrompt);
    }

    void SowSeedsComplete(object sender, EventArgs e)
    {
        dialogue.StartDialogue(goToSleepPrompt);
        interactable.Disable();
    }

    void PickUpSeedsComplete(object sender, EventArgs e)
    {
        dialogue.StartDialogue(goSowPrompt);
    }
}
