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
                                    "Pierre! Var god kom hit en stund!", 
                                    "Nu är det dags för dig att skörda, \n senast imorgon vill jag ha min skörd!",
                                    "Absolut chefen, jag sätter igång direkt",
                                    "Jag kommer tillbaka om fem dagar för att se så det har gått bra, \n fem dagsverk ska jag ha!" };

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

        GUILayout.BeginArea(new Rect(0, Camera.main.pixelHeight / 4, 1000, 1000));
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

            dialogueTimer = 5;
        }
    }
}
