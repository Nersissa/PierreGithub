using UnityEngine;
using System.Collections;

public class EnterFieldPrompt : MonoBehaviour
{
    SeedQuestText QuestText;

    void Start()
    {
        QuestText = GameObject.Find("Sowing").GetComponent<SeedQuestText>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            QuestText.EnterField = true;
        }
    }
}
