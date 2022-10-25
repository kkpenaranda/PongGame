using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

/**
 * Class that defines the movement and logic related to the ball of the game.
 **/
public class BallBehaviour : MonoBehaviour
{
    //Given speed of the ball.
    float velocity = 450f;

    //Reference to the script that controls the game.
    GameManager manager;

    /**
     * Finds the GameManager in the scene and Starts the game by throwing the ball.
     **/
    void OnEnable()
    {
        manager = FindObjectOfType<GameManager>();
        StartCoroutine(ThrowBall());
    }

    /**
     * The ball is thrown diagonally to the left or right in a random way after a second.
     * The zero is ignored to avoid vector like (0,0),(0,1),(1,0) because the game would be affected.
     * At (0,0) the ball would not move. And (0,1),(1,0) would make the ball to be moving in a vertical way and could not be touched by the players.
     **/
    private IEnumerator ThrowBall()
    {
        if (manager.isPlaying)
        {
            yield return new WaitForSeconds(1f);
            int xDirection = Random.Range(-1, 2);
            if (xDirection == 0) xDirection = 1;

            int yDirection = Random.Range(-1, 2);
            if (yDirection == 0) yDirection = -1;

            Vector2 randomDirection = new Vector2(xDirection, yDirection);                      

            GetComponent<Rigidbody2D>().velocity = randomDirection * velocity;
        }
    }

    /**
     * Recognizes the collision for the goals.
     * Add points to the player that score the goal.
     * Restarts a round if nobody has reached the objective. If a player reaches 6 goals, the game is over and shows the winner.
     **/
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "HumanGoal")
        { 
            manager.scoreHuman++;
            if (manager.scoreHuman >= 6) manager.showWinner();
            ResetGame();
        }
        else if (collision.gameObject.tag == "AIGoal")
        {
            manager.scoreAI++;
            if (manager.scoreAI >= 6) manager.showWinner();
            ResetGame();
        }       
        
    }

    /**
     * Starts a new round.
     * Reset the positions of the objects, shows the points in the UI and throw the ball again.
     * When a goal is done, the gameobject is disable to start a new game.
     **/
    private void ResetGame()
    {
        manager.ResetPositions();
        manager.RefreshPoints();

        if (manager.isPlaying)
        { 
            manager.goal = true;            
        }
        gameObject.SetActive(false);
    }
    
}
