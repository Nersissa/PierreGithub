using UnityEngine;
using System.Collections;

public class HarvestFieldScript : MonoBehaviour
{
    Harvest harvest;

    Vector3 harvestHeight = new Vector3(0, 0.06f, 0);

    bool insideField;
    int nrOfHarvests;

    void Start()
    {
        harvest = GameObject.Find("HarvestQuest").GetComponent<Harvest>();
    }

    void Update()
    {
        if (!insideField)
            return;

        if (nrOfHarvests >= 5)
        {
            harvest.Quest.Harvest.Complete();

            Destroy(gameObject);
        }

        if (Input.GetButtonDown("Use") && harvest.Quest.Talking_NobleMan.Completed)
        {
            if (harvest.Quest.GetSickle.Completed)
            {
                nrOfHarvests++;
                transform.position -= harvestHeight;
            }
            else
                harvest.Quest.Harvest.NoCanDo();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            insideField = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            insideField = false;
        }
    }
}
