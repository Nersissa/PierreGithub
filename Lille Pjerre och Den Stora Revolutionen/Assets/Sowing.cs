using UnityEngine;
using System.Collections;

public class Sowing : MonoBehaviour
{
    #region Variables

    // Sets the variables we will be using

    public bool CarryingSeeds = false;
    public bool insideField = false;

    SeedQuestText QuestText;
    ParticleSystem pSystem;
    int nrOfSeedsPlanted = 0;

    void Start()
    {
        // Gets the particlesystem and text which will be used by the GameObject

        pSystem = gameObject.GetComponent<ParticleSystem>();
        QuestText = gameObject.GetComponent<SeedQuestText>();
    }

    #endregion

    #region Handle Sowing

    void Update()
    {
        // The Sowing object will only need to update when the player are inside the sowing field

        if (insideField == false)
            return;

        // When we have planted enough seeds we don't need this object anymore

        if (nrOfSeedsPlanted > 5)
            Destroy(gameObject);

        // Mirrors the direction of the seeds according to the x-axis and the direction of which the player is facing

        if (Input.GetAxisRaw("Horizontal") != 0)
            transform.localRotation = Quaternion.LookRotation(new Vector3(Input.GetAxisRaw("Horizontal"), 0));

        if (Input.GetButtonDown("Use") && nrOfSeedsPlanted <= 5)
        {
            // If you sowe and have the seeds on you, you are able to sowe

            if (CarryingSeeds)
            {
                pSystem.Play();
                nrOfSeedsPlanted++;
            }
            // Otherwise a text will show, telling you to pick up the seeds

            else
                QuestText.TryingToSowWithoutSeeds = true;
        }
            // Stop the particle system so that it doesn't repeat and only plays when you use it

        else
            pSystem.Stop();

    }

    #endregion
}
