using UnityEngine;
using System.Collections;

public class Destroy : MonoBehaviour
{
    CannotGoThere cannotGoThere;
    void Start()
    {
        cannotGoThere = GameObject.Find("BlockadeRight").GetComponent<CannotGoThere>();
    }

    void Update()
    {
        if (cannotGoThere.canGoThere)
        {
            Destroy(this.gameObject);
        }
    }
}
