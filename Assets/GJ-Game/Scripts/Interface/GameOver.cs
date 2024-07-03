using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{ 

    public GameObject gameOverUI;


    private void OnEnable()
    {
        
    }

    public void retry()
    {
        PauseScript.gameIsPaused = false;
        SceneManager.LoadScene(1);

        Time.timeScale = 1f;
    }
    public void LoadMenu()
    {
        PauseScript.gameIsPaused = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        Debug.Log("Game Quit");
        Application.Quit();
    }
}
