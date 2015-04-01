using UnityEngine;
using System.Collections;

public enum PlayerState
{
    neutral,
    carryingSeeds,
    climbing,
}

public class PlayerMovement : MonoBehaviour
{
    PlayerState currentState;
    float speed = 2;
    float runningSpeed = 4;

    Rigidbody2D rigidBody2D;
    bool facingRight = true;

    Animator anim;

    void Start()
    {
        this.rigidBody2D = gameObject.GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        currentState = PlayerState.neutral;
    }

    void Update()
    {
        Movement();

        LadderClimb();
    }

    private void Movement()
    {
        float move = Input.GetAxis("Horizontal");

        anim.SetFloat("Speed", Mathf.Abs(move));

        if (Input.GetKey(KeyCode.LeftShift))
        {
            anim.SetBool("Running", true);
            rigidBody2D.velocity = new Vector2(move * runningSpeed, rigidBody2D.velocity.y);
        }
        else
        {
            anim.SetBool("Running", false);
            rigidBody2D.velocity = new Vector2(move * speed, rigidBody2D.velocity.y);
        }

        if (move > 0 && !facingRight)
            Flip();
        if (move < 0 && facingRight)
            Flip();
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }


    void LadderClimb()
    {
        float climb = Input.GetAxis("Vertical");

        if (currentState == PlayerState.climbing)
        {
            this.rigidBody2D.gravityScale = 0;
            rigidBody2D.velocity = new Vector2(rigidBody2D.velocity.x, speed * climb);
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.name == "Ladder")
        {
            currentState = PlayerState.climbing;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name.Contains("Ladder"))
        {
            currentState = PlayerState.neutral;
            this.rigidBody2D.gravityScale = 6;
        }
    }
}
