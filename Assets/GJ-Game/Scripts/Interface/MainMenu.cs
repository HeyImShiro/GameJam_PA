using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

	public GameObject introScreen;

    private void Start()
    {
		Time.timeScale = 1f;
    }
    public void PlayGame ()
	{
		Cursor.lockState = CursorLockMode.Locked;
		StartCoroutine("StartDialog");
	}

	public void QuitGame ()
	{
		Debug.Log ("Quit");
		Application.Quit();
	}

	IEnumerator StartDialog()
	{
		yield return new WaitForSeconds(15f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}