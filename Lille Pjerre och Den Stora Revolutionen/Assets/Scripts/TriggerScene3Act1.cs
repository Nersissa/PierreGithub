using UnityEngine;
using System.Collections;

public class TriggerScene3Act1 : MonoBehaviour 
{
    ScrollingText text;

	void Start () 
    {
        text = GameObject.Find("PermObject").GetComponent<ScrollingText>();
	}
	
	void Update () 
    {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Player")
            text.Display(1, 3);
    }
}
