using UnityEngine;
using System.Collections;

public class Seagull : MonoBehaviour
{
    public int maxSpeed = 10;
    public int minSpeed = 5;
    public bool randomYPos = true;
    public int maxRandYPos = 3;
    public int minRandYPos = -2;

    float speed = 0.01f;
    float originalYPosition;
    bool facingLeft;

    void Start()
    {
        originalYPosition = transform.position.y;

        //Find random direction and speed.
        int facing = Random.Range(1, 3);

        FindNewSpeed();

        if (facing >= 2)
        {
            transform.Rotate(0, 180, 0);
            facingLeft = true;
            speed *= -1;
        }
    }

    //When the object no longer is in camera view

    void OnBecameInvisible()
    {
        Debug.Log("hit");

        int newPosition = Random.Range(1, 3);

        //Reappear at left edge.

        if (newPosition == 1)
        {
            if (facingLeft)
            {
                transform.Rotate(0, 180, 0);
                facingLeft = false;
            }
            else
                transform.Rotate(0, 0, 0);

            transform.position = new Vector3(Camera.main.transform.position.x - 12, transform.position.y);

            FindNewSpeed();
            RandomYPosition();

            if (speed < 0)
                speed *= -1f;
        }

        ////Reappear at right edge;

        else
        {
            if (!facingLeft)
            {
                transform.Rotate(0, 180, 0);
                facingLeft = true;
            }
            else
                transform.Rotate(0, 0, 0);

            transform.position = new Vector3(Camera.main.transform.position.x + 12, transform.position.y);

            FindNewSpeed();
            RandomYPosition();

            if (speed > 0)
                speed *= -1f;
        }
    }
    void FixedUpdate()
    {
        Fly();
    }

    private void Fly()
    {
        transform.position += new Vector3(speed, 0);
    }

    //Find a new speed between 0.01 and 0.005
    private void FindNewSpeed()
    {
        speed = Random.Range(minSpeed, maxSpeed) / 1000f;
    }
    private void RandomYPosition()
    {
        if (randomYPos)
        {
            transform.position = new Vector3(transform.position.x, originalYPosition + Random.Range(minRandYPos, maxRandYPos));
            Debug.Log("hit");
        }
    }
}
