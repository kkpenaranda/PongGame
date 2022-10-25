using UnityEngine;

/**
 * Class that defines the movement of the object that controls the human.
 **/
public class HumanBehaviour : PlayerBehaviour
{
    // Velocity of the object that controls the human.
    float speed = 150f;
    
    /**
     * Identifies the clicked button and changes the Y position of the object according to it.
     * The object moves according the axis and speed.
     * The object can not be moved outside the given limit.
     **/
    void Update()
    {
        float movement = Input.GetAxisRaw("Vertical");
        float posY = transform.localPosition.y;

        if (manager.isPlaying)
        {
            if (posY + movement * speed * Time.deltaTime < limit && posY + movement * speed * Time.deltaTime > -limit)
                transform.localPosition += new Vector3(0f, movement * speed * Time.deltaTime, 0f);
        }
    }
}
