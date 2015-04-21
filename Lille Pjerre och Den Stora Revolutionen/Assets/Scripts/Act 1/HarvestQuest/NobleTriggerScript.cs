using UnityEngine;
using System.Collections;

public class NobleTriggerScript : MonoBehaviour
{
    // This script will only be used for triggering the cutscene

    NobleCutScene cutscene;

    void Start()
    {
        cutscene = GameObject.Find("Nobleman").GetComponent<NobleCutScene>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // When the player reaches the field, start the cutscene with the nobleman

        if (other.name == "Player")
        {
            cutscene.StartCutScene();
            Destroy(gameObject);
        }
    }
}
