using UnityEngine;
using System.Collections;

public class TriggerNextScene : MonoBehaviour
{
    bool tryingToRest = false;

    ScrollingText text;
    SeedQuestText quest;

    void Start()
    {
        text = GameObject.Find("PermObject").GetComponent<ScrollingText>();
        quest = GameObject.Find("Sowing").GetComponent<SeedQuestText>();

        // We will be using this in the next scene as well

        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {
        // We do not need this script unless the player has completed the sowing quest

        //if (!quest.SowedSeeds)
        //    return;

        // If the player is close to the bed and trying to rest

        if (tryingToRest)
            if (Input.GetButtonDown("Use"))
                text.Display(1, 2);

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Player")
            tryingToRest = true;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.name == "Player")
            tryingToRest = false;
    }
}
