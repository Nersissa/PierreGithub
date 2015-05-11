using UnityEngine;
using System.Collections;

public class SignScript : MonoBehaviour 
{
    public string text;
    private SpriteRenderer sprite;

    private GUIStyle style;

	void Start () 
    {
        sprite = gameObject.GetComponent<SpriteRenderer>();
        style = new GUIStyle();
        style.normal.textColor = Color.black;
        style.wordWrap = true;
	}


    void OnGUI()
    {
        Rect textRect = new Rect(transform.position.x, transform.position.y, 50, 20);
        textRect.position = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        Debug.Log(textRect.position);
        Debug.Log(sprite.bounds.size);
        GUILayout.BeginArea(textRect);        
        GUILayout.Label(text);
        GUILayout.EndArea();
    }
}
