using UnityEngine;
using System.Collections;

enum Part
{
    CallPlayer,
    MovePlayer,
    TalkToPlayer,
    MoveFromPlayer,
}

public class NobleCutScene : MonoBehaviour
{
    Rigidbody2D body;
    Rigidbody2D playerbody;

    Part part;

    PlayerMovement playermove;
    DialogueScript dialogue;
    Harvest harvest;

    bool facingLeft = true;

    string[] callPlayer = {
                           "ADELSMAN: -PIERRE! JAG VILL TALA MED DIG!"
                          };

    string[] Dialogue = {
                         "PIERRE: - VAD KAN JAG GÖRA FÖR ER MONSIEUR (MIN HERRE)?",
                         "ADELSMAN: -SOM DU ÄR VÄL MEDVETEN OM ÄR DET MIN MARK DU HYR OCH ODLAR VETE PÅ.\nJAG HAR DÄRFÖR KOMMIT FÖR ATT KRÄVA IN MIN DEL AV SKÖRDEN,\nSOM EN DEL AV DIN BETALNING.",
                         "PIERRE: -SNÄLLA MONSIEUR, DET HAR VARIT EN TORR VÅR OCH SKÖRDAR JAG DITT VETE\n SÅ HAR JAG KNAPPT KVAR TILL MIG SJÄLV SEN, ÄN MINDRE TILL ATT SÄLJA PÅ MARKNADEN!\nKAN JAG INTE SLIPPA DETTA ELÄNDE, BARA I ÅR? JAG LOVAR ATT DU FÅR DUBBEL SKÖRD NÄSTA ÅR!",
                         "ADELSMAN: -KOMMER INTE PÅ FRÅGA! OCH GLÖM INTE ATT BETALA SKATTEN HELLER.\nDU VAR SEN MED FÖRRA BETALNINGEN. SÅ SVÅRT KAN DET INTE VARA!",
                         "PIERRE: -LÄTT FÖR DIG ATT SÄGA, SOM ALDRIG BEHÖVER ARBETA ELLER BETALA EN LIVRE (FRANKRIKES VALUTA) I SKATT.\nMEDAN BÖNDER SOM JAG MÅSTE SLITA OCH BETALA BÅDE SKATT OCH SPANNMÅL TILL ER ADELSMÄN.",
                         "ADELSMAN: -DU SKA VAKTA DIN TUNGA, BONDE, DET ÄR JAG SOM BESTÄMMER HÄR.\nJAG VILL ATT DU SÄTTER IGÅNG DIREKT, FÖR NU MÅSTE JAG IVÄG TILL GRANNGÅRDEN." 
                        };

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        
        playerbody = GameObject.Find("Player").GetComponent<Rigidbody2D>();
        playermove = GameObject.Find("Player").GetComponent<PlayerMovement>();

        dialogue = GameObject.Find("PermObject").GetComponent<DialogueScript>();
        harvest = GameObject.Find("HarvestQuest").GetComponent<Harvest>();        
    }

    public void StartCutScene()
    {
        dialogue.StartDialogue(callPlayer);

        part = Part.MovePlayer;
    }

    public IEnumerator EndCutScene()
    {
        playermove.Disable();
        body.velocity = new Vector2(1, 0);

        yield return new WaitForSeconds(2);

        Destroy(gameObject);
        playermove.Enable();
        harvest.Quest.Talking_NobleMan.Complete();
    }

    void Update()
    {
        switch (part)
        {
            case Part.MovePlayer:

                if (Vector2.Distance(playerbody.position, body.position) > 2)
                    playermove.MoveHorizontal(1);

                else
                {
                    playermove.MoveHorizontal(0);

                    dialogue.IsTalking = false;
                    dialogue.StartDialogue(Dialogue);

                    part = Part.TalkToPlayer;
                }

                break;
            case Part.TalkToPlayer:

                if (!dialogue.IsTalking)
                    part = Part.MoveFromPlayer;

                break;
            case Part.MoveFromPlayer:

                StartCoroutine(EndCutScene());

                break;
        }

        if (body.velocity.x > 0 && facingLeft)
            Flip();
    }

    void Flip()
    {
        // Mirrors the animation image if you change direction

        facingLeft = !facingLeft;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
