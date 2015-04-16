using UnityEngine;
using System.Collections;

public class MenuManager : MonoBehaviour
{

    public Texture2D MenuBackground;

    //private FadingScript fading;

    //private bool ShowingBackground = true;

    void Start()
    {
        //fading = GameObject.Find("PermObject").GetComponent<FadingScript>();
    }

    //IEnumerator WaitForGame(int seconds)
    //{
    //    yield return new WaitForSeconds(seconds);
    //    if (!Application.loadedLevelName.Contains("MainMenu"))
    //        Destroy(gameObject);
    //}

    void OnGUI()
    {
        GUI.depth = 10000;

        //if (ShowingBackground)
            GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), MenuBackground);
    }

    void OnLevelWasLoaded()
    {
        //// This is called when a new level is loaded, and we begin fading from 0 to 100

        //fading.Begin(-1);

        // And stop showing the background

        //ShowingBackground = false;

        // Calls the waiting method, to give the fading some time

        //StartCoroutine(WaitForGame(5));
        Destroy(gameObject);
    }
}
