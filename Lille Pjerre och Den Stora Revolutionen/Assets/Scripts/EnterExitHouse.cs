using UnityEngine;
using System.Collections;

public class EnterExitHouse : MonoBehaviour
{
    // You need to connect this with another Object for it to work!
    // Preferably another door, which in turn you connect this one with

    public GameObject teleport;

    void OnTriggerEnter2D(Collider2D other)
    {
        // This will only activate when the player presses the use-button

        if (other.gameObject.tag == "Player" && Input.GetButton("Use"))
        {
            other.gameObject.transform.position = teleport.gameObject.transform.position;
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        // This will only activate when the player presses the use-button

        if (other.gameObject.tag == "Player" && Input.GetButton("Use"))
        {
            other.gameObject.transform.position = teleport.gameObject.transform.position;
        }
    }
}
