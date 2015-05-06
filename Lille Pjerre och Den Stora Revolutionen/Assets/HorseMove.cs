using UnityEngine;
using System.Collections;

public class HorseMove : MonoBehaviour
{
    Animator animator;
    Rigidbody2D body;

    void Start()
    {
        animator = GetComponent<Animator>();
        body = GetComponentInParent<Rigidbody2D>();
    }

    void Update()
    {
        if (body.velocity.x > 0 || body.velocity.x < 0)
            animator.SetFloat("Speed", 1);
    }
}
