﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameHandler : MonoBehaviour
{

    public GameObject pauseMenu;
    public GameObject tutorialMenu;
    public float lifeTime;
    public static bool isPaused;
    public GameOverScreen GameOverScreen;

    public void GameOver()
    {
        Time.timeScale = 0f;
        GameOverScreen.Setup(Score.currentScore);
    }
    // Start is called before the first frame update
    void Start()
    {
        pauseMenu.SetActive(false);
        tutorialMenu.SetActive(true);
        StartCoroutine(WaitThenHide());
    }

    // Update is called once per frame
    void Update()
    {
        if (TetrisBlock.gameOver == true)
        {
            GameOver();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }
    IEnumerator WaitThenHide()
    {
        yield return new WaitForSeconds(lifeTime);
        tutorialMenu.SetActive(false);
    }
    public void PauseGame()
    {
        isPaused = true;
        tutorialMenu.SetActive(true);
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    public void ResumeGame()
    {
        isPaused = false;
        pauseMenu.SetActive(false);
        tutorialMenu.SetActive(false);
        Time.timeScale = 1f;
    }
    public void GoToMainMenu()
    {
        Time.timeScale = 1f;
        Score.currentScore = 0;
        SceneManager.LoadScene("Menu");
    }
    public void Quit()
    {
        Application.Quit();
        Debug.Log("Game has Quit");
    }
    public void RestartGame()
    {

        Time.timeScale = 1f;
        Score.currentScore = 0;
        SceneManager.LoadScene("Game");
    }


}
