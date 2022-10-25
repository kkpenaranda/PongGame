using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehaviour : MonoBehaviour
{
    float velocity = 400f;

    // Start is called before the first frame update
    void Start()
    {
        ThrowBall();
    }

    void ThrowBall()
    {
        int xDirection = Random.Range(-1, 2);
        if (xDirection == 0) xDirection = 1;

        int yDirection = Random.Range(-1, 2);
        if (yDirection == 0) yDirection = -1;

        Vector2 randomDirection = new Vector2(xDirection, yDirection);

        GetComponent<Rigidbody2D>().velocity = randomDirection * velocity;
    }

}
