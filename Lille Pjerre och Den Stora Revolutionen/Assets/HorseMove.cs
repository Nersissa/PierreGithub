using UnityEngine;
using System.Collections;

public class HorseMove : MonoBehaviour
{
    Animator animator;
    Rigidbody2D body;

    bool facingLeft = true;

    void Start()
    {
        animator = GetComponent<Animator>();
        body = GetComponentInParent<Rigidbody2D>();
    }

    void Update()
    {
        if (body.velocity.x > 0 || body.velocity.x < 0)
        {
            animator.SetFloat("Speed", 1);
        }

        //if (body.velocity.x > 0 && facingLeft)
        //    Flip();
        //if (body.velocity.x < 0 && !facingLeft)
        //    Flip();
    }

    void Flip()
    {
        facingLeft = !facingLeft;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
