using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

/**
 * Script that controls the game
 **/
public class GameManager : MonoBehaviour
{
    //Points of the human player.
    public int scoreHuman = 0;

    //Points of the A.I.
    public int scoreAI = 0;

    //Indicates if the players started the game.
    public bool isPlaying = false;

    //Indicates if a goal is done.
    public bool goal = false;

    //If a player touched the ball recently.
    public bool touchedRecently = false;

    //Variable that allows to count the seconds.
    float currentTime = 0.0f;

    //Indicates if somebody won.
    bool finished = false;
    
    
    //Ball of the game.
    [SerializeField] public GameObject ball;

    //Playable object that the human controls.
    [SerializeField] GameObject humanPlayer;

    //Playable object controlled by the A.I.
    [SerializeField] GameObject AIPlayer;

    //Text that indicates the number of points of the human.
    [SerializeField] TextMeshProUGUI humanPoints;

    //Text that indicates the number of points of the A.I.
    [SerializeField] TextMeshProUGUI AIPoints;

    //Final panel of the game.
    [SerializeField] GameObject winnerObj;

    //Text that indicates who won the game.
    [SerializeField] TextMeshProUGUI winnerInfo;


    /**
     * Recognizes when the given key is pressed and restarts the game.
     * Recognizes if the ball was disable after a goal, to activate it again.
     * If the game is active, recognizes how much has passed since a player touched the ball. This is made to avoid bugs/game crashing. E.g. The ball starts moving vertically and it is not possible for player to touched it.
     **/
    private void Update()
    {
        if(Input.GetKey(KeyCode.R) && !isPlaying && finished)
        {
            Restart();
        }
        if(goal)
        {
            goal = false;
            ball.SetActive(true);
        }
        if(isPlaying)
        {
            if (touchedRecently)
            {
                currentTime = 0.0f;
                touchedRecently = false;
            }
            else
            {
                currentTime += 1 * Time.deltaTime;
                //Time between touches is 4 approx. So, if the time exceeds by much this value, it is possible that the ball entered on a loop. 
                //In that case, the game should be restarted.
                if (currentTime > 15)
                {
                    ResetGame();
                }
            }
        }
        
    }

    /**
     * Indicates that the game has started.
     **/
    public void InitGame()
    {
        isPlaying = true;
        finished = false;
    }


    /**
     * Change the text in the UI with the proper score.
     **/
    public void RefreshPoints()
    {
        humanPoints.text = scoreHuman.ToString();
        AIPoints.text = scoreAI.ToString();
    }

    /**
     * Changes the positions of the elements of the game to start a new round
     **/
    public void ResetPositions()
    {
        ball.transform.localPosition = new Vector3(0, 0, 0);
        humanPlayer.transform.localPosition = new Vector3(humanPlayer.transform.localPosition.x, 0, 0);
        AIPlayer.transform.localPosition = new Vector3(AIPlayer.transform.localPosition.x, 0, 0);
    }

    /**
     * Starts a new round.
     * Reset the positions of the objects, shows the points in the UI and throw the ball again.
     * When a goal is done, the gameobject is disable to start a new game.
     **/
    public void ResetGame()
    {
        currentTime = 0.0f;
        ResetPositions();
        RefreshPoints();

        if (isPlaying)
        {
            goal = true;
        }
        ball.SetActive(false);
    }

    /**
     * Indicates when the game is over and changes the text according to the winner.
     **/
    public void ShowWinner()
    {
        isPlaying = false;
        finished = true;

        winnerObj.SetActive(true);

        if (scoreHuman > scoreAI)
            winnerInfo.text = "You won!!!";
        else
            winnerInfo.text = "AI won!";
    }
        
    /**
     * Reloads the scene to start a new game
     **/
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
