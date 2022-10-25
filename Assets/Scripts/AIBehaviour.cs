using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIBehaviour : PlayerBehaviour
{
    [SerializeField] private GameObject ball;
    Vector2 ballPosition;
    float speed = 350f;

    private void Update()
    {
        RecognizeBall();
    }


    private void RecognizeBall()
    {
        if (ball.transform.localPosition.y < 165 && ball.transform.localPosition.y > - 165)
        {
            ballPosition = ball.transform.position;
            
            if (ballPosition.y > transform.position.y + size/2)
            {
                transform.position += new Vector3(0, speed * Time.deltaTime, 0);
            }
            else if (ballPosition.y < transform.position.y - size / 2)
            {
                transform.position += new Vector3(0, -speed * Time.deltaTime, 0);
            }
        }
    }
}
