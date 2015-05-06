using UnityEngine;
using System.Collections;

public class PickUpAble : MonoBehaviour
{
    public Sprite OriginalPicture, NewPicture;
    public Texture GuidancePicture;

    private Rect guidanceBox;
    private int boxW, boxH;

    private bool inside = false;

    private SpriteRenderer texture;

    void Start()
    {
        texture = GetComponent<SpriteRenderer>();

        boxW = Screen.width / 25;
        boxH = boxW;

        guidanceBox = new Rect(Screen.width / 2 - boxW / 2, Screen.height / 2 - boxH, boxW, boxH);

        Disable();
    }

    public void Disable()
    {
        enabled = false;
    }

    private QuestStep queststep;
    public void Enable(QuestStep quest)
    {
        enabled = true;
        queststep = quest;
    }

    void OnGUI()
    {
        if (inside)
        {
            GUI.DrawTexture(guidanceBox, GuidancePicture);
            texture.sprite = NewPicture;

            if (Input.GetButtonDown("Use"))
            {
                Destroy(gameObject);
                queststep.Complete();
            }

        }
        else
        {
            texture.sprite = OriginalPicture;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Player")
            inside = true;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.name == "Player")
            inside = false;
    }
}
