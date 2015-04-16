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

    private string pickupseeds = "Welcome! Your first mission is to pick up the seeds to your left! \n Good Luck!";
    private string pickedupseeds = "Now when you have picked up your seeds, start sowing them on the fieldish-looking thing to your right! \n Good Luck!";
    private string tryingtosowwithoutseeds = "You can't sow yet, you haven't picked up the seeds! \n It's to your left!";
    private string sowedseeds = "Good Job! \n You Deserve a break. \n walk into your house to rest.";
    private string seedpickupprompt = "Plocka upp säcken med frön längst bort i ladan!";

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
            ShowText(tryingtosowwithoutseeds, ref TryingToSowWithoutSeeds);

        if (PickedUpSeeds)
            ShowText(pickedupseeds, ref PickedUpSeeds);

        if (PickUpSeeds)
            ShowText(pickupseeds, ref PickUpSeeds);

        if (SowedSeeds)
            ShowText(sowedseeds, ref SowedSeeds);

        if (SeedPickupPrompt)
            ShowText(seedpickupprompt, ref SeedPickupPrompt);
    }

    void ShowText(string text, ref bool inputBool)
    {
        //Starts the countdown for how long the text will be displaying

        textTimer -= Time.deltaTime;

        //Sets the area in which the text will be diplayed

        GUILayout.BeginArea(new Rect(Camera.main.pixelWidth / 2, Camera.main.pixelHeight / 4, 200, 50));
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
