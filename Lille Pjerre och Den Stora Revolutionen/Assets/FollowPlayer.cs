using UnityEngine;
using System.Collections;

public class FollowPlayer : MonoBehaviour {

    Transform player;
    Vector3 cameraPosition;
	
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        cameraPosition = player.position - transform.position;
    }

	void Update () 
    {
        transform.position = player.position - cameraPosition;
	}
}
