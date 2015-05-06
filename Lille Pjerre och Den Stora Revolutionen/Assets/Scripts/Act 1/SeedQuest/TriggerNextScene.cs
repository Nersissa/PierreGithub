using UnityEngine;
using System.Collections;

public class TriggerNextScene : MonoBehaviour
{
    bool inside;

    Sowing sowing;

    void Start()
    {
        sowing = GameObject.Find("Sowing").GetComponent<Sowing>();

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Player")
            inside = true;        
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.name == "Player")
            inside = false;
    }

    void Update()
    {

        if (inside)
        {
            if (sowing.Quest.SowSeeds.Completed && Input.GetButtonDown("Use"))
                sowing.Quest.Rest.Complete();
            else if (!sowing.Quest.SowSeeds.Completed && Input.GetButtonDown("Use"))
                sowing.Quest.Rest.NoCanDo(); 
        }
    }
}
