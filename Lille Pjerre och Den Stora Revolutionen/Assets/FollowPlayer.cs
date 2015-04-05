using UnityEngine;
using System.Collections;

public class FollowPlayer : MonoBehaviour
{
    Transform player;
    Vector3 cameraPosition;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        cameraPosition = player.position - transform.position;
    }

    void Update()
    {
        // Makes the camera follow the player's position, but not angle

        transform.position = player.position - cameraPosition;
    }
}
