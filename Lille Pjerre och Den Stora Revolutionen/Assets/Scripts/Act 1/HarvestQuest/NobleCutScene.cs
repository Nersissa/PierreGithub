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
                                    "ADELSMAN: -PIERRE! JAG VILL TALA MED DIG!", 
                                    "PIERRE: - VAD KAN JAG GÖRA FÖR ER MONSIEUR (MIN HERRE)?",
                                    "ADELSMAN: -SOM DU ÄR VÄL MEDVETEN OM ÄR DET MIN MARK DU HYR OCH ODLAR VETE PÅ.\nJAG HAR DÄRFÖR KOMMIT FÖR ATT KRÄVA IN MIN DEL AV SKÖRDEN,\nSOM EN DEL AV DIN BETALNING.",
                                    "PIERRE: -SNÄLLA MONSIEUR, DET HAR VARIT EN TORR VÅR OCH SKÖRDAR JAG DITT VETE\n SÅ HAR JAG KNAPPT KVAR TILL MIG SJÄLV SEN, ÄN MINDRE TILL ATT SÄLJA PÅ MARKNADEN!\nKAN JAG INTE SLIPPA DETTA ELÄNDE, BARA I ÅR? JAG LOVAR ATT DU FÅR DUBBEL SKÖRD NÄSTA ÅR!",
                                "ADELSMAN: -KOMMER INTE PÅ FRÅGA! OCH GLÖM INTE ATT BETALA SKATTEN HELLER.\nDU VAR SEN MED FÖRRA BETALNINGEN. SÅ SVÅRT KAN DET INTE VARA!",
                                "PIERRE: -LÄTT FÖR DIG ATT SÄGA, SOM ALDRIG BEHÖVER ARBETA ELLER BETALA EN LIVRE I SKATT I HELA DITT LIV!\nMEDAN BÖNDER SOM JAG MÅSTE SLITA OCH BETALA BÅDE SKATT OCH SPANNMÅL TILL ER ADELSMÄN.",
                                "ADELSMAN: -DU SKA VAKTA DIN TUNGA, BONDE, DET ÄR JAG SOM BESTÄMMER HÄR.\nJAG VILL ATT DU SÄTTER IGÅNG DIREKT, FÖR NU MÅSTE JAG IVÄG TILL GRANNGÅRDEN\nOCH HÄMTA MINA ÄRTOR." };

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
