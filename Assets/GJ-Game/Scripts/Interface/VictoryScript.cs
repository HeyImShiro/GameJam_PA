using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryScript : MonoBehaviour
{
    

    public GameObject victoryUI;
   


    /*void Pause()
    {
        victoryUI.SetActive(true);
        Time.timeScale = 0f;
        PauseScript.gameIsPaused = true;
        //Cursor.lockState = CursorLockMode.None;
    }
    */
    public void playAgain()
    {
        PauseScript.gameIsPaused = false;
        SceneManager.LoadScene(1);
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
