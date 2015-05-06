using UnityEngine;
using System.Collections;

public class TriggerNextScene : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name != "Player")
            return;

        Sowing sowing = GameObject.Find("Sowing").GetComponent<Sowing>();

        if (sowing.Quest.SowSeeds.Completed)
            sowing.Quest.Rest.Complete();
        else
            sowing.Quest.Rest.NoCanDo();
    }
}
