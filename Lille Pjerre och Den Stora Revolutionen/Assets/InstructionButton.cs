using UnityEngine;
using System.Collections;

public class InstructionButton : MonoBehaviour
{
    public Texture2D background;

    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(2);
        Destroy(this);
    }

    void OnGUI()
    {
        float width = Screen.width / 7,
            height = Screen.height / 10;

        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), background);

        if (GUI.Button(new Rect(Screen.width - width * 2, Screen.height - height * 2, width, height), "JAG FÖRSTÅR"))
        {
            GameObject.Find("PermObject").GetComponent<Scenes>().TryNextScene();
            StartCoroutine(Destroy());
        }

    }
}
