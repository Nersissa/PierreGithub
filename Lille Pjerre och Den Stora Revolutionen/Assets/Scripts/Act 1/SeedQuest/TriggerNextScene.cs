using UnityEngine;
using System.Collections;

public class TriggerNextScene : MonoBehaviour
{
    Sowing sowing;

    void Start()
    {
        sowing = GameObject.Find("Sowing").GetComponent<Sowing>();
    }

    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Player")
            if (sowing.Quest.SowSeeds.Completed)
                sowing.Quest.Rest.Complete();
            else
                sowing.Quest.Rest.NoCanDo();
    }

    //void OnTriggerStay2D(Collider2D other)
    //{
    //    if (other.name == "Player" && Input.GetButtonDown("Use"))
    //        if (sowing.Quest.SowSeeds.Completed)
    //            sowing.Quest.Rest.Complete();
    //        else
    //            sowing.Quest.Rest.NoCanDo();
    //}
}
