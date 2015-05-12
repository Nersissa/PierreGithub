using UnityEngine;
using System.Collections;

// Initializes the different states the player is going to be in

public enum PlayerState
{
    neutral,
    climbing,
}

public class PlayerMovement : MonoBehaviour
{
    #region Variables

    // Sets the variables we will be using

    public AudioClip moveSound1;
    public AudioClip moveSound2;
    public float timeWalkSteps = 0.4f;
    public float timeRunSteps = 0.3f;
    public bool flipFromStart;

    PlayerState currentState;

    float speed = 2;
    float runningSpeed = 4;

    bool facingRight = true,
          isRunning = false,
          sfxPlaying = false;

    bool IsEnabled = true;
    float moveX, moveY;

    Rigidbody2D rigidBody2D;
    Animator animator;

    IEnumerator sfxCounter()
    {
        sfxPlaying = true;
        SoundManager.instance.RandomizeSfx(moveSound1, moveSound2);
        if (!isRunning)
            yield return new WaitForSeconds(timeWalkSteps);
        else
            yield return new WaitForSeconds(timeRunSteps);
        sfxPlaying = false;
    }

    void Start()
    {     
        // We need the rigidbody and animator of this GameObject

        this.rigidBody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        if (flipFromStart)
            Flip();

        // The playerstate starts as neutral

        currentState = PlayerState.neutral;
    }
    #endregion

    #region MovementManaging

    void Update()
    {
        // Handles Input

        if (moveX != 0)
        {
            //If moving, play step sounds

            if (!sfxPlaying)
                StartCoroutine(sfxCounter());
        }


        if (!IsEnabled)
            return;

        moveY = Input.GetAxis("Vertical");
        moveX = Input.GetAxis("Horizontal");

        if (Input.GetKey(KeyCode.LeftShift))
            isRunning = true;
        else
            isRunning = false;

    }

    public void Disable()
    {
        IsEnabled = false;
        moveX = 0;
        moveY = 0;
        isRunning = false;
    }

    public void Enable()
    {
        IsEnabled = true;
    }

    public void MoveHorizontal(float direction, bool running = false)
    {
        moveX = direction;
    }

    public void MoveVertical(float direction)
    {
        moveY = direction;
    }

    void FixedUpdate()
    {
        Movement();

        // Handles animation flips depending of direction

        if (moveX > 0 && !facingRight)
            Flip();
        if (moveX < 0 && facingRight)
            Flip();
    }

    private void Movement()
    {
        // Controlls the animator, depending on direction
        animator.SetFloat("Speed", Mathf.Abs(moveX));

        if (isRunning)
        {
            // Starts the running animation and doubles the speed
            animator.SetBool("Running", true);
            rigidBody2D.velocity = new Vector2(moveX * runningSpeed, rigidBody2D.velocity.y);
        }
        else
        {
            // If the player is not running, we are using the normal speed 
            // The animator stops the running animation

            animator.SetBool("Running", false);
            rigidBody2D.velocity = new Vector2(moveX * speed, rigidBody2D.velocity.y);
        }

        if (currentState == PlayerState.climbing)

            // If the player is in the climbing state, he can only move along the y-axis

            rigidBody2D.velocity = new Vector2(rigidBody2D.velocity.x, speed * moveY);
    }

    void Flip()
    {
        // Mirrors the animation image of you change direction

        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
    #endregion

    #region CollisionManager
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.name == "Ladder")
        {
            // If the player is colliding with a ladder, it actives the climbing state
            // And sets the gravity of the player to zero

            currentState = PlayerState.climbing;
            this.rigidBody2D.gravityScale = 0;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name.Contains("Ladder"))
        {
            // When the player exits the ladders hitbox, it actives the neutral state 
            // And resets the gravity of the player

            currentState = PlayerState.neutral;
            this.rigidBody2D.gravityScale = 6;
        }
    }
    #endregion
}
