using UnityEngine;
using System.Collections;

public class MenuManager : MonoBehaviour
{
    public Texture2D MenuBackground;

    void OnGUI()
    {
        GUI.depth = 10000;

        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), MenuBackground);
    }

    void OnLevelWasLoaded()
    {
        Destroy(gameObject);
    }
}
