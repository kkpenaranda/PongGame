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
     * Indicates when the game is over and changes the text according to the winner.
     **/
    public void showWinner()
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
