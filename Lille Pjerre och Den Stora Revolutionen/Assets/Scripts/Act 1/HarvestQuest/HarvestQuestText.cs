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

    private string startingup = "-Jag undrar när landshorsjäveln kommer. \n Skörden börjar se förjävla bra ut. \n Fan nu vill jag ut och skörda.";
    private string pickupsickle = "-Förhoppningsvis blir det något över till mig..\nJag får sätta igång direkt. Först måste jag hämta min skära uppe på laduloftet.";
    private string pickedupsickle = "-Sådär, nu kan jag börja skörda adelsmannens vete.";
    private string finishedharvest = "-Då var jag färdig med ett fält.\nMin skära är dock väldigt dålig.\nJag borde nog ta mig till byn och köpa en ny innan jag fortsätter.";


    // Sets the time for which how long the text will show

    private float textTimer = 10;

    private GUIStyle style;


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
        if (FinishedHarvest)
        {
            ShowText(finishedharvest, ref FinishedHarvest);
        }

        // Special function for the conversation with the nobleman
        // We will be talking for a while so we need a few changes

    }

    void ShowText(string text, ref bool inputBool)
    {
        style = new GUIStyle(GUI.skin.label);

        style.font = font;

        style.fontSize = 14;

        style.normal.textColor = Color.white;

        // Starts the countdown for how long the text will be displaying

        textTimer -= Time.deltaTime;

        // Sets the area in which the text will be diplayed

        GUILayout.BeginArea(new Rect(575, Camera.main.pixelHeight / 4, 1000, 1000));
        GUILayout.Label(text, style);
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
