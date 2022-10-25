using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIBehaviour : PlayerBehaviour
{
    [SerializeField] private GameObject ball;
    Vector2 ballPosition;
    float speed = 3.5f;

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
                transform.position += new Vector3(0, speed, 0);
            }
            else if (ballPosition.y < transform.position.y - size / 2)
            {
                transform.position += new Vector3(0, -speed, 0);
            }
        }
    }
    

    /**
    private void RecognizeBall()
    {
        Vector3 position = transform.localPosition;
        ballPosition = ball.transform.position;

        if (position.y + speed <= limit && position.y + speed >= -limit)
            {

                if (ballPosition.y > transform.position.y)
                {
                    transform.position += new Vector3(0, speed, 0);
                }
                else if (ballPosition.y < transform.position.y)
                {
                    transform.position += new Vector3(0, -speed, 0);
                }
            }
            else if (position.y + speed > limit)
                transform.localPosition = new Vector3(position.x, limit - speed, position.z);

            else if (position.y + speed < -limit)
                transform.localPosition = new Vector3(position.x, -limit + 1, position.z);
        

    }    
    **/


    /**
    private void RecognizeBall()
    {
        Vector3 position = transform.localPosition;
        ballPosition = ball.transform.position;

        if (ballPosition.y > transform.position.y)
        {
            transform.localPosition = new Vector3(position.x, Math.Min(position.y + speed,limit), 0);
        }
        else if (ballPosition.y < transform.position.y)
        {
            transform.localPosition = new Vector3(position.x, Math.Max(position.y - speed, -limit), 0);
        }
        

    }
    **/
}
