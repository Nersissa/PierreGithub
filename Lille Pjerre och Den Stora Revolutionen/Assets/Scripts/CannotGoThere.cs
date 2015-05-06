using UnityEngine;
using System.Collections;

public class CannotGoThere : MonoBehaviour
{
    private bool collide;
    public bool canGoThere;

    string[] cannotGoThere = { "Pierre: Här kommer jag inte förbi.." };

    private DialogueScript dialogue;

    void Start()
    {
        dialogue = GameObject.Find("PermObject").GetComponent<DialogueScript>();
    }

    void Update()
    {        
        TryDialogue(ref collide, cannotGoThere);      
    }

    void TryDialogue(ref bool inputBool, string[] text)
    {
        if (inputBool)
        {
            if (!dialogue.IsTalking)
            {
                dialogue.StartDialogue(text);

                inputBool = false;
            }
            else
                inputBool = false;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Player" && !canGoThere)
        {
            collide = true;
        }
    }
}
