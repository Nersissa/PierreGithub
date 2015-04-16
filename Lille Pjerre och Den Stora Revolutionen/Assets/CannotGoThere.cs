using UnityEngine;
using System.Collections;

public class CannotGoThere : MonoBehaviour
{
    private float textTimer = 10;

    private bool collide;

    void Start()
    {

    }

    void OnGUI()
    {

        if (collide)
        {
            textTimer -= Time.deltaTime;

            GUILayout.BeginArea(new Rect(Camera.main.pixelWidth / 2, Camera.main.pixelHeight / 4, 200, 50));
            GUILayout.Label("-Här kommer jag inte förbi..");
            GUILayout.EndArea();

            if (textTimer <= 0)
            {
                collide = false;
                textTimer = 10;

            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            collide = true;
        }
    }
}
