using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

/**
 * Class that controls the timer and starts the game.
 **/
public class CountdownTimer : MonoBehaviour
{
    //Time in seconds.
    float currentTime;

    //Time when the counter starts.
    float startTime = 5f;

    //Text in the UI where the current time is displayed.
    public TextMeshProUGUI textMeshComponent;

    //Reference to the script that controls the game.
    GameManager manager;


    /**
     * Initialize the current time and the manager.
     **/
    void Start()
    {
        currentTime = startTime;
        manager = FindObjectOfType<GameManager>();
    }

    /**
     * Start a countdown to zero.
     * Displays only the integer number in the screen.
     * Avoids to display the "0" and at this time the game is started.
     **/
    void Update()
    {
        currentTime -= 1 * Time.deltaTime;

        if(currentTime > 1) 
            textMeshComponent.text = currentTime.ToString("0");
        else
        {   currentTime = 0;            
            gameObject.SetActive(false);
            manager.InitGame();
            manager.ball.SetActive(true);
        }
    }
}
