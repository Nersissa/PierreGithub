using UnityEngine;
using System.Collections;

public class TriggerNextScene : MonoBehaviour
{
    FadingScript fading;
    Scenes scenes;
    PlayerMovement playerMove;

    public int scene;
    public int act;
    public int direction; // positive = right, negative = left

    private IEnumerator TriggerScene()
    {
        fading.Begin(1);
        playerMove.Disable();
        playerMove.MoveHorizontal(direction);
        yield return new WaitForSeconds(3);
        scenes.LoadScene(act, scene);
        fading.Begin(-1);
        Destroy(gameObject);
    }

    void Start()
    {
        DontDestroyOnLoad(gameObject);
        
        fading = GameObject.Find("PermObject").GetComponent<FadingScript>();
        scenes = GameObject.Find("PermObject").GetComponent<Scenes>();
        playerMove = GameObject.Find("Player").GetComponent<PlayerMovement>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Player")
            StartCoroutine(TriggerScene());
    }
}
