using UnityEngine;
using System.Collections;

public class SoundLoader : MonoBehaviour
{

    public GameObject soundManager;

    Transform player;
    Vector3 myPosition;
    

    void Start()
    {
        DontDestroyOnLoad(gameObject);

        //Check if a SoundManager has already been assigned to static variable GameManager.instance or if it's still null

        if (SoundManager.instance == null)

            //Instantiate SoundManager prefab
            Instantiate(soundManager);
    }
    void OnLevelWasLoaded()
    {
        if (GameObject.Find("Player") != null)
            player = GameObject.Find("Player").transform;
    }
    void Update()
    {
        // Makes the object follow the player's position, but not angle

        if (player != null)
            transform.position = player.position - myPosition;
    }

}
