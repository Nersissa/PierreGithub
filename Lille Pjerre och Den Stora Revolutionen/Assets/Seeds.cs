using UnityEngine;
using System.Collections;

public class Seeds : MonoBehaviour 
{
    Sowing sowingQuest;
    SeedQuestText QuestText;

	void Start () 
    {
        sowingQuest = GameObject.Find("Sowing").GetComponent<Sowing>();
        QuestText = GameObject.Find("Sowing").GetComponent<SeedQuestText>();
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            Destroy(gameObject);
            sowingQuest.CarryingSeeds = true;
            QuestText.PickedUpSeeds = true;
        }
    }
}
