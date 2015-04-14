using UnityEngine;
using System.Collections;

public class ChooseActScript : MonoBehaviour
{
    MenuButtonsFactory mainmenu;
    ScrollingText text;

    IEnumerator WaitForGame(int seconds)
    {
        yield return new WaitForSeconds(seconds);
        if (!Application.loadedLevelName.Contains("MainMenu"))
            Destroy(gameObject);
    }

    void Start()
    {
        enabled = false;

        mainmenu = GetComponent<MenuButtonsFactory>();
        text = GetComponent<ScrollingText>();
    }

    void OnGUI()
    {



            //SelectAct(2);
    }

    void SelectAct(int ActNumber)
    {
        text.Display(ActNumber);
        enabled = false;
    }
}
