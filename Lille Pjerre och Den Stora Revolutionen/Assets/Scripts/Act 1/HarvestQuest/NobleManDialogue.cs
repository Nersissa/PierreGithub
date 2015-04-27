using UnityEngine;
using System.Collections;

public class NobleManDialogue : MonoBehaviour
{
    NobleCutScene cutscene;

    private float dialogueTimer = 5;

    // Just an int for displaying the strings in the dialogue

    private int dialogueNumber = 0;
    public bool HavingDialogue = false;

    private string[] Dialogue = {
                                    "-Pierre! Jag vill tala med dig!", 
                                    "-Vad kan jag göra för er monsieur?",
                                    "-Som du är väl medveten om är det min mark du hyr och odlar vete på.\nJag har därför kommit för att kräva in min del av skörden,\nsom en del av betalningen för detta.",
                                    "-Snälla monsieur, det har varit en torr vår och skördar jag ditt vete\nså har jag knappt kvar till mig själv sen, än mindre till att sälja på marknaden!\nKan jag inte slippa detta elände, bara i år? Jag lovar att du får dubbel skörd nästa år!",
                                "-Kommer inte på fråga! Och glöm inte att betala skatt heller.\nDu var sen med förra betalningen. Så svårt kan det inte vara!",
                                "-Lätt för dig att säga, som aldrig har behövt arbeta eller betala en livre i skatt i hela ditt liv!\nMedan bönder som jag måste slita OCH betala både skatt och spannmål till er adelsmän.",
                                "-Du ska vakta din tunga, bonde, det är jag som bestämmer här.\nJag vill att du sätter igång direkt, för nu måste jag iväg till granngården\noch hämta mina ärtor." };

    // Use this for initialization
    void Start()
    {
        cutscene = GetComponent<NobleCutScene>();
    }

    // Update is called once per frame
    void OnGUI()
    {
        if (HavingDialogue)
            HaveDialogue();
    }

    void HaveDialogue()
    {
        // Starts countdown

        dialogueTimer -= Time.deltaTime;

        // Displays the text area

        if (dialogueNumber == 0 || dialogueNumber == 2 || dialogueNumber == 4 || dialogueNumber == 6)
            GUILayout.BeginArea(new Rect(900, Camera.main.pixelHeight / 4, 1000, 1000));
        else
            GUILayout.BeginArea(new Rect(575, Camera.main.pixelHeight / 4, 1000, 1000));

        GUILayout.Label(Dialogue[dialogueNumber]);
        GUILayout.EndArea();

        // When the timer reaches zero, it resets the timer
        // and turns the bool to false so it isn't called repeatedly

        if (dialogueTimer <= 0)
        {
            if (dialogueNumber < (Dialogue.Length - 1))
                dialogueNumber++;
            else
            {
                HavingDialogue = false;
                StartCoroutine(cutscene.EndCutScene());
            }

            dialogueTimer = 15;
        }
    }
}
