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
    float respawnTimer;
    //float originalYPosition;

    void Start()
    {
        //originalYPosition = transform.position.y;

        int facing = Random.Range(1, 3);

        FindNewSpeed();

        if (facing >= 2)
        {
            transform.Rotate(0, 180, 0);
            speed *= -1;
        }
    }
    void OnBecameInvisible()
    {
        if (respawnTimer <= 0)
        {

            //int newPosition = Random.Range(1, 2);

            ////Just change direction and find new Y-position

            //if (newPosition == 1)
            //{
            //    transform.Rotate(0, 0, 0);
            //    FindNewSpeed();
            //}

            ////Appear at other edge with random Y-position

            //else
            //{
            //    transform.position = new Vector3(transform.position.x, Random.Range(0, (int)Camera.main.transform.position.y));
            //    FindNewSpeed();
            //}
        }
        else
            respawnTimer += Time.deltaTime;
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
            transform.position = new Vector3(transform.position.x, transform.position.y + Random.Range(minRandYPos, maxRandYPos));
    }
}
