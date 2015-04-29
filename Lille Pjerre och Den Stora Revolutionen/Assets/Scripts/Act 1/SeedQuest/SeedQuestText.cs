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


    private string[] pickupseeds = { "PIERRE: -VILKEN VACKER VÅRDAG! IDAG PASSAR DET UTMÄRKT ATT SÅ MITT VETE INFÖR SOMMAREN. STYR MIG MED PILTANGENTERNA SÅ JAG KAN HÄMTA MINA FRÖN LÄNGST BORT I LADULOFTET." };
    private string[] seedpickupprompt = { "PIERRE: -SÄCKEN MED FRÖN JAG BEHÖVER LIGGER LÄNGST BORT I LADAN!" };
    private string[] pickedupseeds = { "PIERRE: -VAD BRA, NU HAR JAG MINA FRÖN! STYR MIG TILLBAKA TILL HUSET OCH VIDARE, SÅ JAG KAN SÅ MIN VETE!" };
    private string[] tryingtosowwithoutseeds = { "PIERRE: -JAG BEHÖVER DOCK MINA FRÖN FÖR ATT KUNNA SÅ.. DE LIGGER PÅ LADULOFTET TILL VÄNSTER, STYR MIG DIT SÅ JAG KAN HÄMTA DEM!" };
    private string[] sowedseeds = { "PIERRE: -PUH, DET VAR HÅRT ARBETE, MEN NU ÄR DET KLART!\nSTYR MIG IN I MITT HUS, SÅ KAN JAG GÅ OCH LÄGGA MIG FÖR DAGEN." };

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