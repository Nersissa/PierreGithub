using UnityEngine;
using System.Collections;

public class TriggerScene3Act1 : MonoBehaviour 
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Player")
            GameObject.Find("HarvestQuest").GetComponent<Harvest>().Quest.HeadToTown.Complete();
    }
}
