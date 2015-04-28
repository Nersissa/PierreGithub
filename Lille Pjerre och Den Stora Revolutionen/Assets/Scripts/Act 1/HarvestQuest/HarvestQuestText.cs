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

    private string[] startingup = { "Pierre: -Jag undrar när landshorsjäveln kommer. Skörden börjar se förjävla bra ut. Fan nu vill jag ut och skörda." };
    private string[] pickupsickle = { "Pierre: -Förhoppningsvis blir det något över till mig.. Jag får sätta igång direkt. Först måste jag hämta min skära uppe på laduloftet." };
    private string[] pickedupsickle = { "Pierre: -Sådär, nu kan jag börja skörda adelsmannens vete." };
    private string[] finishedharvest = { "Pierre: -Då var jag färdig med ett fält. Min skära är dock väldigt dålig. Jag borde nog ta mig till byn och köpa en ny innan jag fortsätter." };


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
