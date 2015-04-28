using UnityEngine;
using System.Collections;

public class SeedQuestText : MonoBehaviour
{
    #region Variables

    // Sets up the bools we will be needing for display different textmessages

    public bool TryingToSowWithoutSeeds = false;
    public bool PickedUpSeeds = false;
    public bool PickUpSeeds = true;
    public bool SowedSeeds = false;
    public bool SeedPickupPrompt = false;

    // Sets up the strings of text. These are easily costumizable later on

    private string[] pickupseeds = { "Pierre: -Vilken vacker vårdag! Idag passar det utmärkt att så mitt vete inför sommaren. Styr mig med piltangenterna så jag kan hämta mina frön uppe på laduloftet åt vänster." };
    private string[] seedpickupprompt = { "Pierre: -Säcken med frön jag behöver ligger längst bort i ladan!" };
    private string[] pickedupseeds = { "Pierre: -Vad bra, nu har jag mina frön! Styr mig tillbaka till huset och vidare, till jag kommer till mitt vetefält!" };
    private string[] tryingtosowwithoutseeds = { "Pierre: -Jag behöver dock mina frön för att kunna så.. De ligger på laduloftet till vänster, styr mig dit så jag kan hämta dem!" };
    private string[] sowedseeds = { "Pierre: -Puh, det var hårt arbete, men nu är det klart!\nStyr mig in i mitt hus, så kan jag gå och lägga mig för dagen." };

    private DialogueScript dialogue;

    void Start()
    {
        dialogue = GameObject.Find("PermObject").GetComponent<DialogueScript>();
    }

    #endregion
    #region TextManagement

    void Update()
    {
        if (TryingToSowWithoutSeeds)
            TryDialogue(ref TryingToSowWithoutSeeds, tryingtosowwithoutseeds);

        if (PickUpSeeds)
            TryDialogue(ref PickUpSeeds, pickupseeds);

        if (PickedUpSeeds)
            TryDialogue(ref PickedUpSeeds, pickedupseeds);

        if (SowedSeeds)
            TryDialogue(ref SowedSeeds, sowedseeds);

        if (SeedPickupPrompt)
            TryDialogue(ref SeedPickupPrompt, seedpickupprompt);

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
