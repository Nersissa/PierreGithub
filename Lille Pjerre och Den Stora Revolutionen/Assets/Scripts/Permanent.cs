using UnityEngine;
using System.Collections;

public class Permanent : MonoBehaviour {

	void Start () {

        // This object will be used over the entire project

        DontDestroyOnLoad(gameObject);
	}
}
