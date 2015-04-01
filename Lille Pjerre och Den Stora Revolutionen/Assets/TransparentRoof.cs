using UnityEngine;
using System.Collections;

public class TransparentRoof : MonoBehaviour
{
    SpriteRenderer[] sprites;
    float alpaValue = 1;
    bool isEntering;
    Color color;

    void Awake()
    {
        sprites = GetComponentsInChildren<SpriteRenderer>();
    }

    void FixedUpdate()
    {
        if (!isEntering && alpaValue < 1)
            alpaValue += 0.05f;
        else if (isEntering && alpaValue > 0)
            alpaValue -= 0.05f;

        color = new Color(1, 1, 1, alpaValue);

        foreach (var child in sprites)
            child.color = color;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Player")
            isEntering = true;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.name == "Player")
            isEntering = false;
    }
}
