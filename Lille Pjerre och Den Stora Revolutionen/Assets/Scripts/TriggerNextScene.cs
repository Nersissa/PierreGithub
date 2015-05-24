//using UnityEngine;
//using System.Collections;

//public class TriggerNextScene : MonoBehaviour
//{
//    FadingScript fading;
//    Scenes scenes;
//    PlayerMovement playerMove;
//    private ScrollingText scrollingText;

//    public int nextScene;
//    public int nextAct;
//    public int direction; // positive = right, negative = left

//    public IEnumerator TriggerScene()
//    {
//        fading.Begin(1);
//        playerMove.Disable();
//        playerMove.MoveHorizontal(direction);
//        yield return new WaitForSeconds(3);
//        scenes.LoadNextScene();
//        Destroy(gameObject);
//    }

//    void Start()
//    {
//        DontDestroyOnLoad(gameObject);
        
//        fading = GameObject.Find("PermObject").GetComponent<FadingScript>();
//        scenes = GameObject.Find("PermObject").GetComponent<Scenes>();
//        playerMove = GameObject.Find("Player").GetComponent<PlayerMovement>();
//        scrollingText = GameObject.Find("PermObject").GetComponent<ScrollingText>();
//    }

//    void OnTriggerEnter2D(Collider2D other)
//    {
//        if (other.name == "Player")
//            StartCoroutine(TriggerScene());
//    }
//}
