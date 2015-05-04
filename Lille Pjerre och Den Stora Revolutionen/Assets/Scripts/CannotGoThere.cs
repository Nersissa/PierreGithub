using UnityEngine;
using System.Collections;

public class CannotGoThere : MonoBehaviour
{
    public bool canGoThere;

    string[] cannotGoThere = { "Pierre: Här kommer jag inte förbi.." };

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Player" && !canGoThere)
        {
            GameObject.Find("PermObject").GetComponent<DialogueScript>().StartDialogue(cannotGoThere);
        }
    }
}
