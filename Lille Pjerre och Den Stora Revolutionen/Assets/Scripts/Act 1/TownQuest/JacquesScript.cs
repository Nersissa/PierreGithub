using UnityEngine;
using System.Collections;

public class JacquesScript : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        TownQuest quest = GameObject.Find("TownQuest").GetComponent<TownQuestScript>().Quest;

        if (other.name == "Player")
        {
            if (other.transform.position.x < transform.position.x)
                transform.rotation = new Quaternion(0, 180, 0, 0);
            else
                transform.rotation = new Quaternion(0, 0, 0, 0);


            if (!quest.MeetJacques.Completed)
                quest.MeetJacques.Complete();
            else if (quest.GoToMarket.Completed && !quest.GoBackToJacques.Completed)
                quest.GoBackToJacques.Complete();
            else if (quest.BuySickle.Completed)
                quest.SleepAtJacques.Complete();
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            if (other.transform.position.x < transform.position.x)
                transform.rotation = new Quaternion(0, 180, 0, 0);
            else
                transform.rotation = new Quaternion(0, 0, 0, 0);
        }
    }
}
