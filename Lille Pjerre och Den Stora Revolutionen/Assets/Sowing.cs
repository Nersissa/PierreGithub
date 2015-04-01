using UnityEngine;
using System.Collections;

public class Sowing : MonoBehaviour
{
    public bool CarryingSeeds = false;
    public bool insideField = false;

    SeedQuestText QuestText;
    ParticleSystem pSystem;
    int nrOfSeedsPlanted = 0;

    void Start()
    {
        pSystem = gameObject.GetComponent<ParticleSystem>();
        QuestText = gameObject.GetComponent<SeedQuestText>();
    }

    void Update()
    {
        if (nrOfSeedsPlanted > 5)
            Destroy(gameObject);

       if (insideField)
        {
            if (Input.GetAxisRaw("Horizontal") != 0)
                transform.localRotation = Quaternion.LookRotation(new Vector3(Input.GetAxisRaw("Horizontal"), 0));

            if (Input.GetButtonDown("Use") && nrOfSeedsPlanted <= 5)
            {
                if (CarryingSeeds)
                {
                    pSystem.Play();
                    nrOfSeedsPlanted++;
                }
                else
                    QuestText.TryingToSowWithoutSeeds = true;
            }
            else
                pSystem.Stop();
        }
    }
}
