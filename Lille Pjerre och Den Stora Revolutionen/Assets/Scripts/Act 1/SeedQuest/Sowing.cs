using UnityEngine;
using System.Collections;

public class Sowing : MonoBehaviour
{
    public SeedQuest Quest;
    public bool InsideField = false;

    int nrOfSeedsPlanted = 0;

    ParticleSystem pSystem;

    void Start()
    {
        // Create our first quest

        Quest = new SeedQuest("Uppdrag Nummer Ett");

        GameObject.Find("PermObject").GetComponent<JournalScript>().AddQuest(Quest);

        pSystem = GetComponent<ParticleSystem>();
    }

    void Update()
    {
        // The Sowing object will only need to update when the player are inside the sowing field

        if (InsideField == false)
            return;

        // Tell the text script when we have completed the quest

        if (nrOfSeedsPlanted >= 5)
        {
            Quest.SowSeeds.Complete();
            Destroy(GameObject.Find("FieldCollision"));
            InsideField = false;
        }

        // Mirrors the direction of the seeds according to the x-axis and the direction of which the player is facing

        if (Input.GetAxisRaw("Horizontal") != 0)
            transform.localRotation = Quaternion.LookRotation(new Vector3(Input.GetAxisRaw("Horizontal"), 0));

        if (Input.GetButtonDown("Use") && nrOfSeedsPlanted < 5)
        {
            // If you sowe and have the seeds on you, you are able to sowe

            if (Quest.PickUpSeeds.Completed)
            {
                pSystem.Play();
                nrOfSeedsPlanted++;
            }

            // Otherwise a text will show, telling you to pick up the seeds

            else
                Quest.SowSeeds.NoCanDo();
        }
        // Stop the particle system so that it doesn't repeat and only plays when you use it

        else
            pSystem.Stop();

    }
}
