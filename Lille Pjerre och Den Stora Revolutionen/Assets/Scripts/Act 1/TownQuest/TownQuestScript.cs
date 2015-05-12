using UnityEngine;
using System.Collections;
using System;

public class TownQuestScript : MonoBehaviour
{
    public TownQuest Quest;

    void Start()
    {
        Quest = new TownQuest();

        GameObject.Find("PermObject").GetComponent<JournalScript>().AddQuest(Quest);

    }
}


public class TownQuest : Quest
{
    public QuestStep MeetJacques, GoToMarket, GoBackToJacques, BuySickle, SleepAtJacques;

    private string[] FirstJacquesDialogue = {
                                                "JACQUES: BONJOUR(GODDAG) PIERRE! VART ÄR DU PÅ VÄG IDAG, MIN VÄN? ",
                                                "PIERRE: BONJOUR JACQUES! MIN GAMLA SKÄRA BÖRJAR ROSTA SÖNDER, OCH JAG BEHÖVER EN NY, SÅ JAG SKA TILL MARKNADEN!",
                                                "JACQUES: OKEJ, TITTA FÖRBI PÅ VÄGEN TILLBAKA!"
                                            };

    private string[] DialogueWithSickleWoman = {
                                                   "PIERRE: BONJOUR MADAME!(GODDAG, MIN DAM!) JAG SKULLE BEHÖVA EN NY SKÄRA, VAD KOSTAR EN SÅDAN?",
                                                   "FÖRSÄLJARE: DEN KOSTAR 20 LIVRE!",
                                                   "PIERRE: 20 LIVRE?! DEN FÖRRA BETALADE JAG JU 10 FÖR, OCH DEN KÖPTE JAG OCKSÅ HÄR!",
                                                   "FÖRSÄLJARE: TYVÄRR, MONSIEUR, MED DE HÖJDA SKATTERNA MÅSTE JAG HÖJA PRISERNA FÖR ATT ÖVERLEVA. DET FINNS INGENTING JAG KAN GÖRA...",
                                                   "PIERRE: JAHA, DÅ FÅR JAG VÄL NÖJA MIG MED MIN GAMLA ROSTIGA. JAG MÅSTE JU HA PENGAR TILL MAT!"
                                               };

    private string[] SecondJacquesDialogue =  {
                                                  "JACQUES: BLEV DET INGEN SKÄRA?",
                                                  "PIERRE: NEJ, PRISERNA HAR HÖJTS PÅ ALLT VERKAR DET SOM, 20 LIVRE FÖR EN SKÄRA!",
                                                  "JACQUES: KLART DU SKA HA EN NY SKÄRA. HÄR, TA DESSA!",
                                                  "PIERRE: ... MERCI (TACK) JACQUES! TYVÄRR KAN JAG INTE BETALA TILLBAKA.",
                                                  "JACQUES: NONSENS, VAD SKA MAN ANNARS HA VÄNNER TILL?"
                                              };

    private string[] BuySickleDialogue = {
                                             "PIERRE: BONJOUR IGEN! NU HAR JAG PENGAR SÅ DET RÄCKER!",
                                             "FÖRSÄLJARE: MAN TACKAR, HÄR HAR DU DIN SKÄRA",
                                             "PIERRE: MERCI, AU REVOIR! (TACK, PÅ ÅTERSEENDE!)"
                                         };

    private string[] SleepWithJacques = {
                                            "PIERRE: LÅT MIG SOVA HOS DIG!",
                                            "JACQUES: OKEJ!",
                                            "PIERRE: TACK!",
                                            "JACQUES: LUGNT!"
                                        };

    private string[] NotEnoughMoney = {
                                          "PIERRE: JAG HAR INTE TILLRÄCKLIGT MED PENGAR, JAG FÅR GÅ HEM IGEN."
                                      };

    private string[] YouHaveSickle = {
                                         "PIERRE: JAG HAR REDAN KÖPT MIN SKÄRA. JAG MÅSTE SKYNDA MIG HEM!"
                                     };

    private DialogueScript dialogue;

    public TownQuest()
        : base("Uppdrag Nummer tre")
    {
        GameObject.Find("PermObject").GetComponent<JournalScript>().activated = true;
        dialogue = GameObject.Find("PermObject").GetComponent<DialogueScript>();

        MeetJacques = new QuestStep("MÖT JACQUES", "JACQUES BOR I HUSET LÄNGST UT TILL VÄNSTER I STADEN");
        GoToMarket = new QuestStep("KÖP EN NY SKÄRA PÅ MARKNADEN", "SKÄRAN HITTAR DU I ETT AV MARKNADSSTÅNDEN I STADEN");
        GoBackToJacques = new QuestStep("GÅ HEM IGEN", "DU HADE INTE NOG MED PENGAR, GÅ HEM OCH FORTSÄTT SKÖRDA.");
        BuySickle = new QuestStep("KÖP SKÄRAN MED PENGARNA DU FICK AV JACQUES", "");
        SleepAtJacques = new QuestStep("GÅ TILLBAKA TILL GÅRDEN", "DET BÖRJAR REGNA, DU FÅR NOG SNABBA DIG!");


        GoToMarket.StepComplete += IsAtMarket;
        GoBackToJacques.StepComplete += JacquesSecondDialogue;
        BuySickle.StepComplete += BoughtSickle;
        SleepAtJacques.StepComplete += AskJacques;
        MeetJacques.StepComplete += JacquesFirstDialogue;

        BuySickle.IllegalAction += GetMoreMoney;

        AddStep(MeetJacques);
        AddStep(GoToMarket);
        AddStep(GoBackToJacques);
        AddStep(BuySickle);
        AddStep(SleepAtJacques);
    }

    void JacquesFirstDialogue(object sender, EventArgs e)
    {
        dialogue.StartDialogue(FirstJacquesDialogue);
    }

    void IsAtMarket(object sender, EventArgs e)
    {
        dialogue.StartDialogue(DialogueWithSickleWoman);
    }

    void JacquesSecondDialogue(object sender, EventArgs e)
    {
        dialogue.StartDialogue(SecondJacquesDialogue);
    }

    void BoughtSickle(object sender, EventArgs e)
    {
        dialogue.StartDialogue(BuySickleDialogue);
    }

    void AskJacques(object sender, EventArgs e)
    {
        dialogue.StartDialogue(SleepWithJacques);
    }

    void GetMoreMoney(object sender, EventArgs e)
    {
        if (!BuySickle.Completed)
            dialogue.StartDialogue(NotEnoughMoney);
        else
            dialogue.StartDialogue(YouHaveSickle);
    }
}