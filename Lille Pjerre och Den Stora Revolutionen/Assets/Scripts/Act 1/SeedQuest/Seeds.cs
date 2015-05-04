using UnityEngine;
using System.Collections;

public class Seeds : MonoBehaviour
{
    Sowing sowing;

    void Start()
    {
        // Initializes the script for the sowing quest as well as the text needed

        sowing = GameObject.Find("Sowing").GetComponent<Sowing>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // This will only trigger when the player is colliding with the bag of seeds

        if (other.name == "Player")
        {
            // When the player picks up the seeds, this object will destroy itself

            Destroy(gameObject);

            // The player will then get the seeds, thus being able to sow at the field

            sowing.Quest.PickUpSeeds.Complete();
        }
    }
}
