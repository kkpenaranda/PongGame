using UnityEngine;

public class HumanBehaviour : PlayerBehaviour
{
    float speed = 150f;
    
    void Update()
    {
        float movement = Input.GetAxisRaw("Vertical");
        float posY = transform.localPosition.y; 

        if(posY + movement * speed * Time.deltaTime < limit && posY + movement * speed * Time.deltaTime > -limit)
            transform.localPosition += new Vector3(0f, movement * speed * Time.deltaTime, 0f);
    }
}
