using UnityEngine;
using System.Collections;

public class CompleteSeedQuest : MonoBehaviour
{

    void Start()
    {

    }

    void Update()
    {

    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (Input.GetButtonDown("Use"))
        {
            if (other.name == "Player")
            {
                SeedQuest quest = other.GetComponentInChildren<Sowing>().Quest;

                if (quest.SowSeeds.Completed)
                {
                    quest.Rest.Complete();
                }
                else
                    quest.Rest.NoCanDo();
            } 
        }
        
    }
}
