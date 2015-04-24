using UnityEngine;
using System.Collections;

public class Spin : MonoBehaviour {

    public float rotationSpeed = -1;
	void Start () {
	
	}
	
	void Update () {

        transform.Rotate(new Vector3(0, 0, rotationSpeed));
	}
}
