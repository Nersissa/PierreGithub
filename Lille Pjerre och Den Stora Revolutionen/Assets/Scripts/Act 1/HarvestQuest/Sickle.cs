using UnityEngine;
using System.Collections;

public class Sickle : MonoBehaviour
{
    HarvestQuestText harvestQuestText;

    public bool canPickUpSickle;

    void Start()
    {
        harvestQuestText = GameObject.Find("HarvestQuest").GetComponent<HarvestQuestText>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // This will only trigger when the player is colliding with the sickle

        if (canPickUpSickle)
        {
            if (other.name == "Player")
            {
                // When the player picks up the sickle, this object will destroy itself

                Destroy(gameObject);

                harvestQuestText.PickedUpSickle = true;

            } 
        }
    }
}
