using UnityEngine;
using System.Collections;

public class TransparentRoof : MonoBehaviour
{
    #region Variables

    // Sets the variables we will be using

    SpriteRenderer[] sprites;
    float alpaValue = 1;
    bool isEntering;
    Color color;

    void Awake()
    {
        // Initialize SpriteRenderer, the component we will be using to change the color
        // The SpriteRenderer will need to access every child to the GameObject

        sprites = GetComponentsInChildren<SpriteRenderer>();
    }

    #endregion

    #region Collision and ColorManagement

    void FixedUpdate()
    {
        // Checks if player is entering or exiting the roof of the barn.
        // If he is, make the roof more or less visible

        if (!isEntering && alpaValue < 1)
            alpaValue += 0.05f;
        else if (isEntering && alpaValue > 0)
            alpaValue -= 0.05f;

        color = new Color(1, 1, 1, alpaValue);

        // Set the alpha color to every child to the roof (every part of the roof)

        foreach (var child in sprites)
            child.color = color;
    }

    #endregion

    #region CollisionChecks
    void OnTriggerEnter2D(Collider2D other)
    {
        // Determines if it really is the player who is entering the roof

        if (other.name == "Player")
            isEntering = true;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        // Determines if it really is the player who is exiting the roof

        if (other.name == "Player")
            isEntering = false;
    }

    #endregion
}
