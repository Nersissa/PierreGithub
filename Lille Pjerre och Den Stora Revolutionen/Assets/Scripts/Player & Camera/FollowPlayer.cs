using UnityEngine;
using System.Collections;

public class FollowPlayer : MonoBehaviour
{
    Transform player;
    Vector3 myPosition;

    void Awake()
    {

        player = GameObject.FindGameObjectWithTag("Player").transform;
        myPosition = player.position - transform.position;
    }

    void Update()
    {
        // Makes the object follow the player's position, but not angle

        transform.position = player.position - myPosition;
    }
}
