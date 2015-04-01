using UnityEngine;
using System.Collections;

public class MainMenuScript : MonoBehaviour
{
    public Texture2D fadeOutTexture;

    int drawDepth = 1;
    int fadeDir = -1;
    int nextLevel;

    float fadeSpeed = 0.5f;
    float alpha = 1.0f;

    bool isEntering = false;

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(3);
        if (!Application.loadedLevelName.Contains("MainMenu"))
            Destroy(gameObject);
    }

    void Start()
    {
        nextLevel = Application.loadedLevel + 1;
        DontDestroyOnLoad(gameObject);
    }

    void OnGUI()
    {
        if (!isEntering)
            if (GUI.Button(new Rect(200, 200, 200, 200), "Play Game"))
            {
                Application.LoadLevel(nextLevel);
                isEntering = true;
            }

        if (isEntering)
        {
            alpha += fadeDir * fadeSpeed * Time.deltaTime;

            alpha = Mathf.Clamp01(alpha);

            GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, alpha);
            GUI.depth = drawDepth;
            GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), fadeOutTexture);
        }
    }

    public float BeginFade(int direction)
    {
        fadeDir = direction;
        return (fadeSpeed);
    }

    void OnLevelWasLoaded()
    {
        BeginFade(-1);
        StartCoroutine(Wait());
    }
}
