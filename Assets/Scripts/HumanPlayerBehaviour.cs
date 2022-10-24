using UnityEngine;

public class HumanPlayerBehaviour : MonoBehaviour
{
    float speed = 1.5f;
    [SerializeField] private GameObject UpWall;

    float limit;

    private void Start()
    {
        float upLimit = UpWall.transform.localPosition.y;
        float size = GetComponent<RectTransform>().rect.height;

        limit = upLimit - size / 2;
    }

    void Update()
    {
        float movement = Input.GetAxisRaw("Vertical");
        float posY = transform.localPosition.y; 

        if(posY + movement * speed < limit && posY + movement * speed > -limit)
            transform.localPosition += new Vector3(0f, movement * speed, 0f);
    }
}
