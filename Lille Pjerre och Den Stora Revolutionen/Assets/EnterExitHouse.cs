using UnityEngine;
using System.Collections;

public class EnterExitHouse : MonoBehaviour {

    public GameObject teleport;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && Input.GetKeyDown(KeyCode.E))
        {
            other.gameObject.transform.position = teleport.gameObject.transform.position;
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && Input.GetKeyDown(KeyCode.E))
        {
            other.gameObject.transform.position = teleport.gameObject.transform.position;
        }
    }
}
