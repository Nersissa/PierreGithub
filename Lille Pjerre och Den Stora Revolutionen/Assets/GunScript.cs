using UnityEngine;
using System.Collections;

public class GunScript : MonoBehaviour
{
    bool pickedup;

    PlayerMovement player;

    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerMovement>();
    }

    void Update()
    {
        if (!pickedup)
            return;

        transform.position = new Vector3(player.transform.position.x + 0.05f,
                                         player.transform.position.y);
        transform.localScale = player.transform.localScale;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            pickedup = true;
        }
    }
}
