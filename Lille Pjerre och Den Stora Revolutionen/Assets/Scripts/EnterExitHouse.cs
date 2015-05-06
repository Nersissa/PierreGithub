using UnityEngine;
using System.Collections;

public class EnterExitHouse : MonoBehaviour
{
    // You need to connect this with another Object for it to work!
    // Preferably another door, which in turn you connect this one with

    public GameObject teleport;
    GameObject player;
    private bool inside;

    void Start()
    {
        player = GameObject.Find("Player");
    }

    void Update()
    {
        if (inside && Input.GetButtonDown("Use"))
        {
            player.gameObject.transform.position = teleport.gameObject.transform.position; 
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        // This will only activate when the player presses the use-button

        if (other.gameObject.tag == "Player")
        {
            inside = true;
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        // This will only activate when the player presses the use-button

        if (other.gameObject.tag == "Player")
        {
            inside = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        // This will only activate when the player presses the use-button

        inside = false;

    }
}
