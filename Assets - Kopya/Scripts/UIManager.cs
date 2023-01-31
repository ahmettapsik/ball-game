using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class UIManager : MonoBehaviour
{
    public CanvasGroup mainMenuG;
    public CanvasGroup pauseMenuG;
    public CanvasGroup endMenuG;


    public TextMeshPro scoreTextOne;
    public TextMeshPro scoreTextTwo;
    public TextMeshPro goaltext;
    public Text endMenutext;

    public static UIManager instance;

    private void Start()
    {
        if (instance == null)
            instance = this;
    }

    public void StartGame()
    {
        StartCoroutine(CloseCanvas(mainMenuG));
        StartCoroutine(CloseCanvas(endMenuG));
        Time.timeScale = 1f;
        Timer.instance.time = 300;
        Timer.instance.isTimerOn = true;

        scoreTextOne.text = "0 \n / \n 5";
        scoreTextTwo.text = "0 \n / \n 5";

        GameManager.instance.balls[1].GetComponent<PlayerController>().canMove = true;
        GameManager.instance.balls[2].GetComponent<PlayerController>().canMove = true;
        GameManager.instance.playerOneGoalAmount = 0;
        GameManager.instance.playerTwoGoalAmount = 0;
    }

    public void CloseGame()
    {
        Application.Quit();
    }

    

    public void ResumeGame()
    {
        StartCoroutine(CloseCanvas(pauseMenuG));
        Time.timeScale = 1f;
    }

    public void PauseGame()
    {
        StartCoroutine(OpenCanvas(pauseMenuG));
        Time.timeScale = 0f;
    }

    public void StopGame()
    {
        StartCoroutine(CloseCanvas(pauseMenuG));
        StartCoroutine(OpenCanvas(mainMenuG));
        Time.timeScale = 1f;
        Timer.instance.isTimerOn = false;
        Timer.instance.timerText.text = "Timer";

        GameManager.instance.ResetGame();
        scoreTextOne.text = "0 \n / \n 5";
        scoreTextTwo.text = "0 \n / \n 5";

        GameManager.instance.balls[1].GetComponent<PlayerController>().canMove = false;
        GameManager.instance.balls[2].GetComponent<PlayerController>().canMove = false;
        
    }

    public IEnumerator OpenCanvas(CanvasGroup canvasG)
    {
        canvasG.gameObject.SetActive(true);
        while (canvasG.alpha < 1)
        {
            canvasG.alpha += Time.unscaledDeltaTime * 5f;
            yield return null;
        }
    }

    public IEnumerator CloseCanvas(CanvasGroup canvasG)
    {
        while (canvasG.alpha > 0)
        {
            canvasG.alpha -= Time.unscaledDeltaTime * 5f;
            yield return null;
        }
        canvasG.gameObject.SetActive(false);
    }

    public void UpdateScore(bool playerOne, int score)
    {
        if(playerOne)
            scoreTextOne.text = score.ToString() + "\n / \n 5";
        else
            scoreTextTwo.text = score.ToString() + "\n / \n 5";
    }

    public IEnumerator GoalText(bool isPlayerOne)
    {
        while (goaltext.color.a < 1)
        {
            if(isPlayerOne)
                goaltext.color = Color.Lerp(new Color(0f, 0f, 0f, 0f), Color.yellow, Time.deltaTime  + goaltext.color.a);
            else
                goaltext.color = Color.Lerp(new Color(0f, 0f, 0f, 0f), new Color(0f, 0.8307626f, 1f, 1f), Time.deltaTime + goaltext.color.a);
            yield return null;
        }
        yield return new WaitForSecondsRealtime(2f);
        GameManager.instance.ResetGame();
        while (goaltext.color.a > 0)
        {
            goaltext.color = Color.Lerp(goaltext.color, new Color(0f,0f, 0f, 0f), Time.deltaTime + goaltext.color.a);
            yield return null;
        }
    }

    public void OpenEndMenu(bool isPlayerOne)
    {
        StartCoroutine(OpenCanvas(endMenuG));
        if (isPlayerOne)
        {
            endMenutext.color = Color.yellow;
            endMenutext.text = "Player One Wins!";
        }
        else
        {
            endMenutext.color = new Color(0f, 0.8307626f, 1f, 1f);
            endMenutext.text = "Player Two Wins!";
        }
    }
}
