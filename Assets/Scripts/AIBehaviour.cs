using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Class that defines the movement of the object that controls the A.I.
 **/
public class AIBehaviour : PlayerBehaviour
{
    //Ball of the game.
    [SerializeField] private GameObject ball;

    //Position of the ball.
    Vector2 ballPosition;

    //Velocity of the object.
    float speed = 635f;

    /**
     * Defines what the object should do in every frame.
     **/
    private void Update()
    {
        RecognizeBall();
    }

    /**
     * If the game started, the A.I. recognizes if the ball is above or below the playable object. 
     * If the ball is above, the object moves up with the given speed, otherwise it goes down.
     * If the Y position is different but the object can touched the ball, the A.I. does not move.
     **/
    private void RecognizeBall()
    {
        if (manager.isPlaying)
        {
            //Established the bounderies according to the movement of the ball
            if (ball.transform.localPosition.y < 165 && ball.transform.localPosition.y > -165)
            {
                ballPosition = ball.transform.position;

                if (ballPosition.y > transform.position.y + size / 2)
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
}
