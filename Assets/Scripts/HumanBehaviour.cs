using UnityEngine;

public class HumanBehaviour : PlayerBehaviour
{
    float speed = 1.5f;
    
    void Update()
    {
        float movement = Input.GetAxisRaw("Vertical");
        float posY = transform.localPosition.y; 

        if(posY + movement * speed < limit && posY + movement * speed > -limit)
            transform.localPosition += new Vector3(0f, movement * speed, 0f);
    }
}
