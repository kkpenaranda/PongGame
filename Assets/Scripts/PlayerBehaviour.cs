using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject UpWall;
    [SerializeField] private GameObject player;

    protected float limit;
    protected float size;

    private void Start()
    {
        float upLimit = UpWall.transform.localPosition.y;
        size = player.GetComponent<RectTransform>().rect.height;

        limit = upLimit - size / 2;
    }
}
