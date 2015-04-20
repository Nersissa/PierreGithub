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
    public bool EnterField = false;
    public bool ClimbLadder = false;
    public bool EnterHouse = false;

    // Sets up the strings of text. These are easily costumizable later on

    private string pickupseeds = "-Vilken vacker vårdag!\nIdag passar det utmärkt att så mitt vete inför sommaren.\nStyr mig med piltangenterna så jag kan hämta mina frön uppe på laduloftet åt vänster.";
    private string seedpickupprompt = "-Säcken med frön jag behöver ligger längst bort i ladan!";
    private string pickedupseeds = "-Vad bra, nu har jag mina frön!\nStyr mig tillbaka till huset och vidare, till jag kommer till mitt vetefält!";
    private string enterfield = "-Använd E för att hjälpa mig så mina frön här på fältet!";
    private string tryingtosowwithoutseeds = "-Jag behöver dock mina frön för att kunna så..\nDe ligger på laduloftet till vänster, styr mig dit så jag kan hämta dem!";
    private string climbladder = "-Använd piltangenterna för att styra mig upp och ner för stegen till laduloftet!";
    private string sowedseeds = "-Puh, det var hårt arbete, men nu är det klart!\nStyr mig in i mitt hus, så kan jag gå och lägga mig för dagen.";
    private string enterhouse = "-För att styra in mig i huset kan du använda E vid dörren här.";

    // Sets the time for which how long the text will show

    private float textTimer = 10;

    #endregion
    #region TextManagement

    void OnGUI()
    {
        // This method is called as an Update method
        // It checks if any of the bools are true
        // If any is true, it also displays the correct text

        if (TryingToSowWithoutSeeds)
        { 
            ShowText(tryingtosowwithoutseeds, ref TryingToSowWithoutSeeds);
            PickUpSeeds = false;
            EnterField = false;
        }

        if (PickedUpSeeds)
        {
            ShowText(pickedupseeds, ref PickedUpSeeds);
            SeedPickupPrompt = false;
        }

        if (PickUpSeeds)
            ShowText(pickupseeds, ref PickUpSeeds);

        if (SowedSeeds)
        {
            ShowText(sowedseeds, ref SowedSeeds);
            EnterField = false;
        }

        if (SeedPickupPrompt)
        {
            ShowText(seedpickupprompt, ref SeedPickupPrompt);
            PickUpSeeds = false;
            ClimbLadder = false;
        }

        if (EnterField)
        {
            ShowText(enterfield, ref EnterField);
            PickUpSeeds = false;
        }
        if (ClimbLadder)
        {
            ShowText(climbladder, ref ClimbLadder);
            PickUpSeeds = false;
            PickedUpSeeds = false;
            SeedPickupPrompt = false;
            EnterHouse = false;
        }
        if (EnterHouse)
        {
            ShowText(enterhouse, ref EnterHouse);
            PickUpSeeds = false;
            TryingToSowWithoutSeeds = false;
            EnterField = false;
            ClimbLadder = false;
            SeedPickupPrompt = false;
            PickedUpSeeds = false;
            SowedSeeds = false;
        }
    }

    void ShowText(string text, ref bool inputBool)
    {
        //Starts the countdown for how long the text will be displaying
        
        textTimer -= Time.deltaTime;

        //Sets the area in which the text will be diplayed

        GUILayout.BeginArea(new Rect(Camera.main.pixelWidth / 2, Camera.main.pixelHeight / 2.5f, 200, 100));
        GUILayout.Label(text);
        GUILayout.EndArea();

        // When the timer reaches zero, it resets the timer
        // and turns the bool to false so it isn't called repeatedly

        if (textTimer <= 0)
        {
            inputBool = false;
            textTimer = 10;

        }
    }

    #endregion
}
