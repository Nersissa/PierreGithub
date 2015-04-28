using UnityEngine;
using System.Collections;

public class DialogueScript : MonoBehaviour
{
    // Variables

    GUIStyle textStyle;

    Rect DialogueBox;

    public Font font;

    public bool IsTalking = false;

    bool NextPersonTalk = false;
    bool MoreTextComing = false;

    float boxWidth, boxHeight;

    string DisplayingText;
    string MessageToDispay;
    string TalkingPerson;
    string[] Dialogue;

    int PlaceInDialogue = 0;

    void Start()
    {
        // Sets up our own style

        textStyle = new GUIStyle();

        textStyle.font = font;

        // Since we have limited space and background
        // We want a custom colour and wrap the words

        textStyle.normal.textColor = Color.white;
        textStyle.wordWrap = true;

        boxWidth = Screen.width / 5;
        boxHeight = Screen.height / 8;

        DialogueBox = new Rect(Screen.width / 2 - boxWidth / 2, Screen.height - boxHeight, boxWidth, boxHeight);
    }

    void Update()
    {
        // If some text is not shown because the space in the dialoguebox is out,
        // The user can press the Use button in order to show the remaining text

        if (MoreTextComing && Input.GetButtonDown("Use"))
        {
            DisplayingText = "";
            MoreTextComing = false;
        }

            // If we have displayed all text, let the user see the next sentence

        else if (NextPersonTalk && Input.GetButtonDown("Use"))
            Talk();
    }

    void OnGUI()
    {
        textStyle.normal.textColor = Color.white;
        GUI.backgroundColor = Color.black;
        GUILayout.BeginArea(DialogueBox);
        GUILayout.Box(TalkingPerson + DisplayingText, textStyle);
        GUILayout.EndArea();
    }

    IEnumerator animateText(string strComplete)
    {
        DisplayingText = "";

        for (int i = 0; i < strComplete.Length; i++)
        {
            // Needed for calculating the height of the text

            GUIContent content = new GUIContent(TalkingPerson + DisplayingText + "\n");

            // If there is space left, add letters one by one to the diplaying text 

            if (textStyle.CalcHeight(content, boxWidth) < boxHeight && !MoreTextComing)
                DisplayingText += strComplete[i];
            else
            {
                MoreTextComing = true;
                i--;
            }

            // time to wait before adding another letter

            yield return new WaitForSeconds(0.01f);
        }

        NextPersonTalk = true;
        PlaceInDialogue++;
    }

    public void StartDialogue(string[] Dialogue)
    {
        // The player wont be able to move during the dialogue to prevent bugs or unintented behavior

        GameObject.Find("Player").GetComponent<PlayerMovement>().Disable();

        IsTalking = true;

        this.Dialogue = Dialogue;

        PlaceInDialogue = 0;

        Talk();
    }

    void Talk()
    {
        // If we have gone through the array, end the dialogue

        if (PlaceInDialogue >= Dialogue.Length)
        {
            EndDialogue();
            return;
        }

        // We start every new string in an arraw by "<name>:"
        // This is where we split it, to show the name above everything else

        string[] splitString = Dialogue[PlaceInDialogue].Split(':');

        // As long as the text doesnt contain anyother ":" sign, 
        // its safe to say that the remaining text is our message to the user

        TalkingPerson = splitString[0] + "\n";
        MessageToDispay = splitString[1];

        NextPersonTalk = false;

        StartCoroutine(animateText(MessageToDispay));
    }

    IEnumerator WaitForEnd()
    {
        yield return new WaitForSeconds(1);
        IsTalking = false;
    }

    void EndDialogue()
    {
        // Resets every string, bool and int we have in order to prevent bugs

        TalkingPerson = "";
        MessageToDispay = "";
        DisplayingText = "";

        PlaceInDialogue = 0;

        NextPersonTalk = false;
        MoreTextComing = false;

        // Makes the player able to walk again

        GameObject.Find("Player").GetComponent<PlayerMovement>().Enable();

        StartCoroutine(WaitForEnd());
    }
}
