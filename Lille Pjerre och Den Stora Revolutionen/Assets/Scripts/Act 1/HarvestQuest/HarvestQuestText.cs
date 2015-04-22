using UnityEngine;
using System.Collections;

public class HarvestQuestText : MonoBehaviour
{
    #region Variables

    // Sets up the bools we will be needing for display different textmessages

    public bool StartingUp = true;
    public bool PickUpSickle = false;
    public bool PickedUpSickle = false;

    // Sets up the strings of text. These are easily costumizable later on

    private string startingup = "-Jag undrar när landshorsjäveln kommer. \n Skörden börjar se förjävla bra ut. \n Fan nu vill jag ut och skörda.";
    private string pickupsickle = "-Det är väl bara att sätta igång. Först får jag gå och hämta min skära som hänger på laduloftet.";
    private string pickedupsickle = "-Sådär, nu kan jag börja skörda adelsmannens vete.";


    // Sets the time for which how long the text will show

    private float textTimer = 10;


    #endregion
    #region TextManagement

    void OnGUI()
    {
        // This method is called as an Update method
        // It checks if any of the bools are true
        // If any is true, it also displays the correct text

        if (StartingUp)
            ShowText(startingup, ref StartingUp);
        if (PickUpSickle)
        {
            ShowText(pickupsickle, ref PickUpSickle);
        }
        if (PickedUpSickle)
        {
            ShowText(pickedupsickle, ref PickedUpSickle);
        }

        // Special function for the conversation with the nobleman
        // We will be talking for a while so we need a few changes

    }

    void ShowText(string text, ref bool inputBool)
    {
        // Starts the countdown for how long the text will be displaying

        textTimer -= Time.deltaTime;

        // Sets the area in which the text will be diplayed

        GUILayout.BeginArea(new Rect(Camera.main.pixelWidth / 2, Camera.main.pixelHeight / 4, 1000, 1000));
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
