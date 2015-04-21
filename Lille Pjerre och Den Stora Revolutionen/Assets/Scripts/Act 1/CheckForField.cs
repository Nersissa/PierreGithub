using UnityEngine;
using System.Collections;

public class CheckForField : MonoBehaviour
{
    Sowing sowing;

    void Start()
    {
        // This script will only check if the player has entered the field

        sowing = GetComponentInParent<Sowing>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Field")
            sowing.insideField = true;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.name == "Field")
            sowing.insideField = false;
    }
}
