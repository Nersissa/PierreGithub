using UnityEngine;
using System.Collections;

public class HarvestQuestText : MonoBehaviour
{
    #region Variables

    public Font font;

    // Sets up the bools we will be needing for display different textmessages

    public bool StartingUp = true;
    public bool PickUpSickle = false;
    public bool PickedUpSickle = false;
    public bool FinishedHarvest = false;

    // Sets up the strings of text. These are easily costumizable later on

    private string[] startingup = { "Pierre: -IDAG ÄR DET DAGS. JAG MÅSTE BÖRJA SKÖRDA SÅ ATT JAG INTE FÖRLORAR MIN VETE TILL TORKAN." };
    private string[] pickupsickle = { "Pierre: -FÖRHOPPNINGSVIS BLIR DET NÅGOT ÖVER TILL MIG.. JAG FÅR SÄTTA IGÅNG DIREKT. FÖRST MÅSTE JAG HÄMTA MIN SKÄRA UPPE PÅ LADULOFTET." };
    private string[] pickedupsickle = { "Pierre: -SÅDÄR, NU KAN JAG BÖRJA SKÖRDA ADELSMANNENS VETE." };
    private string[] finishedharvest = { "Pierre: -DÅ VAR JAG FÄRDIG MED ETT FÄLT. MIN SKÄRA ÄR DOCK VÄLDIGT DÅLIG. JAG BORDE NOG TA MIG TILL BYN OCH KÖPA EN NY INNAN JAG FORTSÄTTER. VÄGEN TILL BYN LIGGER BORTOM     TRÄDEN TILL HÖGER." };


    DialogueScript dialogue;

    void Start()
    {
        dialogue = GameObject.Find("PermObject").GetComponent<DialogueScript>();
    }

    #endregion
    #region TextManagement

    void OnGUI()
    {
        // This method is called as an Update method
        // It checks if any of the bools are true
        // If any is true, it also displays the correct text

        if (StartingUp)
            TryDialogue(ref StartingUp, startingup);
        if (PickUpSickle)
        {
            TryDialogue(ref PickUpSickle, pickupsickle);
        }
        if (PickedUpSickle)
        {
            TryDialogue(ref PickedUpSickle, pickedupsickle);
        }
        if (FinishedHarvest)
        {
            TryDialogue(ref FinishedHarvest, finishedharvest);
        }

        // Special function for the conversation with the nobleman
        // We will be talking for a while so we need a few changes

    }

    void TryDialogue(ref bool InputBool, string[] text)
    {
        if (InputBool)
        {
            if (!dialogue.IsTalking)
            {
                dialogue.StartDialogue(text);

                InputBool = false;
            }
            else
                InputBool = false;
        }
    }

    #endregion
}
