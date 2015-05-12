using UnityEngine;
using System.Collections;

public class SickleWomanScript : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        TownQuest townQuest = GameObject.Find("TownQuest").GetComponent<TownQuestScript>().Quest;

        if (other.name == "Player")
        {
            if (!townQuest.GoToMarket.Completed)
                townQuest.GoToMarket.Complete();
            else if (!townQuest.BuySickle.Completed && townQuest.GoBackToJacques.Completed)
                townQuest.BuySickle.Complete();
            else
                townQuest.BuySickle.NoCanDo();
        }
    }
}
