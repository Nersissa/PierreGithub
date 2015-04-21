using UnityEngine;
using System.Collections;

public class NobleCutScene : MonoBehaviour
{
    // Variables

    private bool movingRight = false;
    private bool movingPlayer = false;

    PlayerMovement playermove;
    NobleManDialogue dialogue;

    Rigidbody2D body;
    Rigidbody2D playerbody;

    void Start()
    {
        playermove = GameObject.Find("Player").GetComponent<PlayerMovement>();
        playerbody = GameObject.Find("Player").GetComponent<Rigidbody2D>();

        dialogue = GetComponent<NobleManDialogue>();
        body = GetComponent<Rigidbody2D>();
    }

    // The nobleman needs some time to get away from pierre

    public IEnumerator EndCutScene()
    {
        movingRight = true;
        yield return new WaitForSeconds(2);
        playermove.IsEnabled = true;
        Destroy(gameObject);
    }

    void Update()
    {
        // We are moving the player

        if (movingPlayer)
        {
            // But only if they are far away from eachother

            if (Vector2.Distance(playerbody.position, body.position) > 2)
                playermove.moveX = 1;
            else
            {
                // When the player gets close we can start the dialogue

                playermove.moveX = 0;
                dialogue.HavingDialogue = true;
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

        playermove.IsEnabled = false;
        movingPlayer = true;
    }
}
