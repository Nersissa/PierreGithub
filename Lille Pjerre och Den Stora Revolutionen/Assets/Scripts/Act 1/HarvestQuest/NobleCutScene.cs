using UnityEngine;
using System.Collections;

public class NobleCutScene : MonoBehaviour
{
    // Variables

    private bool movingRight = false;
    private bool movingPlayer = false;

    PlayerMovement playermove;
    DialogueScript dialogue;
    HarvestQuestText questText;
    Sickle sicklePickup;

    Rigidbody2D body;
    Rigidbody2D playerbody;

    private string[] Dialogue = {
                                    "Adelsman: Nu är det dags för dig att skörda",
                                    "Pierre: Absolut chefen, jag sätter igång direkt",
                                    "Adelsman: Jag kommer tillbaka om fem dagar för att se så det har gått bra, fem dagsverk ska jag ha!" };

    void Start()
    {
        playermove = GameObject.Find("Player").GetComponent<PlayerMovement>();
        playerbody = GameObject.Find("Player").GetComponent<Rigidbody2D>();
        sicklePickup = GameObject.Find("Sickle").GetComponent<Sickle>();
        questText = GameObject.Find("HarvestQuest").GetComponent<HarvestQuestText>();

        dialogue = GameObject.Find("PermObject").GetComponent<DialogueScript>();
        body = GetComponent<Rigidbody2D>();
    }

    // The nobleman needs some time to get away from pierre

    public IEnumerator EndCutScene()
    {
        movingRight = true;
        yield return new WaitForSeconds(2);
        playermove.Enable();
        Destroy(gameObject);
        questText.PickUpSickle = true;
        sicklePickup.canPickUpSickle = true;
    }

    void Update()
    {
        // We are moving the player

        if (movingPlayer)
        {
            // But only if they are far away from eachother

            if (Vector2.Distance(playerbody.position, body.position) > 2)
                playermove.MoveHorizontal(1);
            else
            {
                // When the player gets close we can start the dialogue

                playermove.MoveHorizontal(0);
                dialogue.StartDialogue(Dialogue);
                movingPlayer = false;
            }
        }

        if (movingRight)
            body.velocity = new Vector2(5, 0);
    }

    void FixedUpdate()
    {
        // Used later for animating the fucker
    }

    public void StartCutScene()
    {
        // Disables playermovement
        // Allows us to alter player's position

        playermove.Disable();
        movingPlayer = true;
    }
}
