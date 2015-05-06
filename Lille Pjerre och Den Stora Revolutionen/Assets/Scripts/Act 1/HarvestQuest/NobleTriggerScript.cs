using UnityEngine;
using System.Collections;

public class NobleTriggerScript : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            GameObject.Find("HarvestQuest").GetComponent<Harvest>().Quest.OverlookField.Complete();

            Destroy(gameObject);
        }
    }
}
