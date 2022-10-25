using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Class that contains data of the players.
 **/
public class PlayerBehaviour : MonoBehaviour
{
    //Object that is used as reference to establish the limits of the board.
    [SerializeField] private GameObject UpWall;

    //Given player.
    [SerializeField] private GameObject player;

    //Reference to the script that controls the game. It can be accessed by the classed that inherit from this one.
    protected GameManager manager;

    //Defines the min and max limit that the player can move in the board.
    protected float limit;

    //Size of the player object.
    protected float size;

    /**
     * Establish the limit for the given player.
     **/
    private void Start()
    {
        manager = FindObjectOfType<GameManager>();

        float upLimit = UpWall.transform.localPosition.y;
        size = player.GetComponent<RectTransform>().rect.height;

        limit = upLimit - size / 2;
    }
}
