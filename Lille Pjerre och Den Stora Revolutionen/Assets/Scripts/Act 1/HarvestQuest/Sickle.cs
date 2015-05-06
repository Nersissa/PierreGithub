using UnityEngine;
using System.Collections;

public class Sickle : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            GameObject.Find("HarvestQuest").GetComponent<Harvest>().Quest.GetSickle.Complete();

            Destroy(gameObject);
        }
    }
}
