using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int playerOneGoalAmount;
    public int playerTwoGoalAmount;

    public static GameManager instance;

    public GameObject[] balls;
    public Transform[] firstLocations;

    private void Start()
    {
        if (instance == null)
            instance = this;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            UIManager.instance.PauseGame();
    }

    public void Goal(bool isPlayerOne)
    {
        if (isPlayerOne)
        {
            playerOneGoalAmount++;
            UIManager.instance.UpdateScore(isPlayerOne, playerOneGoalAmount);
        }
        else
        {
            playerTwoGoalAmount++;
            UIManager.instance.UpdateScore(isPlayerOne, playerTwoGoalAmount);
        }

        if (playerOneGoalAmount == 5 || playerTwoGoalAmount == 5)
            EndGame(isPlayerOne);

        StartCoroutine(UIManager.instance.GoalText(isPlayerOne));
        SoundManager.instance.PlaySound(SoundManager.instance.goalSound);
    }

    public void ResetGame()
    {
        for (int i = 0; i < balls.Length; i++)
        {
            balls[i].transform.position = firstLocations[i].position;
            balls[i].transform.rotation = new Quaternion(0f,0f,0f,0f);
            balls[i].GetComponent<Rigidbody>().velocity = Vector3.zero;
            balls[i].GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        }
    }

    public void EndGame(bool isPlayerOne)
    {
        UIManager.instance.OpenEndMenu(isPlayerOne);
        balls[1].GetComponent<PlayerController>().canMove = false;
        balls[2].GetComponent<PlayerController>().canMove = false;
        Timer.instance.isTimerOn = false;


    }
}
