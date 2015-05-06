using UnityEngine;
using System.Collections;

public class TriggerAct1Scene4 : MonoBehaviour
{
    FadingScript fading;
    Scenes scenes;
    PlayerMovement playerMove;

    private IEnumerator TriggerNextScene()
    {
        fading.Begin(1);
        playerMove.Disable();
        playerMove.MoveHorizontal(1);
        yield return new WaitForSeconds(3);
        scenes.LoadScene(1, 4);
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
            StartCoroutine(TriggerNextScene());
    }
}
