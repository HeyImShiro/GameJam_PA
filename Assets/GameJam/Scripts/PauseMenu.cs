using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject PauseMenuOverlay;

    public void Pause()
    {
        PauseMenuOverlay.SetActive(true);
        Time.timeScale = 0;
    }

    public void Resume()
    {
        PauseMenuOverlay.SetActive(false);
        Time.timeScale = 1;
    }

}
