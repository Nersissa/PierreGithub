using UnityEngine;
using System.Collections;

public class Harvest : MonoBehaviour
{
    HarvestQuestText questText;
    CannotGoThere nextScene;

    Vector3 temp = new Vector3(0, 0.06f, 0);

    public bool carryingSickle;
    public bool finishedHarvest;
    bool insideField;

    int nrOfHarvests;

    void Start()
    {
        questText = GameObject.Find("HarvestQuest").GetComponent<HarvestQuestText>();
        nextScene = GameObject.Find("BlockadeRight").GetComponent<CannotGoThere>();
    }

    void Update()
    {
        if (!insideField)
            return;

        if (nrOfHarvests >= 5)
        {
            Destroy(gameObject);
            finishedHarvest = true;
            questText.FinishedHarvest = true;
            nextScene.canGoThere = true;
        }

        if (Input.GetButtonDown("Use") && !finishedHarvest)
        {
            if (carryingSickle)
            {
                nrOfHarvests++;
                transform.position -= temp;
            }
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
