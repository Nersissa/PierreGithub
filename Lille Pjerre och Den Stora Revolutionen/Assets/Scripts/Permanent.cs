using UnityEngine;
using System.Collections;

public class Permanent : MonoBehaviour
{

    GameObject otherPermObject;

    void Start()
    {

        // This object will be used over the entire project

        DontDestroyOnLoad(gameObject);

        // Check if there is another PermObject - if so - delete it.

        otherPermObject = GameObject.Find("PermObject");

        if (otherPermObject != gameObject)
            Destroy(gameObject);
    }

    void OnLevelWasLoaded()
    {
        Debug.Log(Application.loadedLevelName);
    }
}
