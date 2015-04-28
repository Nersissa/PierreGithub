using UnityEngine;
using System.Collections;

public class NobleCutScene : MonoBehaviour
{
    // Variables

    private bool movingRight = false;
    private bool movingPlayer = false;
    private bool startedTalking = false;

    PlayerMovement playermove;
    DialogueScript dialogue;
    HarvestQuestText questText;
    Sickle sicklePickup;

    Rigidbody2D body;
    Rigidbody2D playerbody;

    private string[] Dialogue = {
                                    "Adelsman: -Pierre! Jag vill tala med dig!", 
                                    "Pierre: -Vad kan jag göra för er monsieur?",
                                    "Adelsman: -Som du är väl medveten om är det min mark du hyr och odlar vete på.\nJag har därför kommit för att kräva in min del av skörden,\nsom en del av betalningen för detta.",
                                    "Pierre: -Snälla monsieur, det har varit en torr vår och skördar jag ditt vete\nså har jag knappt kvar till mig själv sen, än mindre till att sälja på marknaden!\nKan jag inte slippa detta elände, bara i år? Jag lovar att du får dubbel skörd nästa år!",
                                "Adelsman: -Kommer inte på fråga! Och glöm inte att betala skatt heller.\nDu var sen med förra betalningen. Så svårt kan det inte vara!",
                                "Pierre: -Lätt för dig att säga, som aldrig har behövt arbeta eller betala en livre i skatt i hela ditt liv!\nMedan bönder som jag måste slita OCH betala både skatt och spannmål till er adelsmän.",
                                "Adelsman: -Du ska vakta din tunga, bonde, det är jag som bestämmer här.\nJag vill att du sätter igång direkt, för nu måste jag iväg till granngården\noch hämta mina ärtor." };

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
                startedTalking = true;
                movingPlayer = false;
            }
        }

        if (!dialogue.IsTalking && startedTalking)
        {
            StartCoroutine(EndCutScene());
            startedTalking = false;
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
