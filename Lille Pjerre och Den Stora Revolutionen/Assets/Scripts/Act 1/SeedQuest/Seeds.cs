using UnityEngine;
using System.Collections;

public class Seeds : MonoBehaviour
{
    #region Variables

    // Sets the variables we will be using

    Sowing sowingQuest;
    SeedQuestText QuestText;

    void Start () 
    {
        // Initializes the script for the sowing quest as well as the text needed

        sowingQuest = GameObject.Find("Sowing").GetComponent<Sowing>();
        QuestText = GameObject.Find("Sowing").GetComponent<SeedQuestText>();
	}

    #endregion

    #region Collision

    void OnTriggerEnter2D(Collider2D other)
    {
        // This will only trigger when the player is colliding with the bag of seeds

        if (other.name == "Player")
        {
            // When the player picks up the seeds, this object will destroy itself

            Destroy(gameObject);

            // The player will then get the seeds, thus being able to sow at the field

            sowingQuest.CarryingSeeds = true;

            // And at last telling the script that the player has picked up the seeds

            QuestText.PickedUpSeeds = true;
        }
    }

    #endregion
}
