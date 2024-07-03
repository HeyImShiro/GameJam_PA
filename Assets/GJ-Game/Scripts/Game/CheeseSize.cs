using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheeseSize : MonoBehaviour
{
    public float minSize;
    public float maxSize;

    public float shrinkIntervall;
    public float shrinkAmount;

    public GameObject gameOverScreen;

    [SerializeField] private bool indicatorActive;
    private Material shader;

    private float timer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        shader = GetComponentInChildren<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        // Shrink
        timer += Time.deltaTime;
        if(timer >= shrinkIntervall && transform.localScale.x >= minSize)
        {
            transform.localScale *= shrinkAmount;
            timer = 0f;
        }

        // Lose Condition
        if(transform.localScale.x <= minSize)
        {
            gameOverScreen.SetActive(true); 
            Time.timeScale = 0f;
            PauseScript.gameIsPaused = true;
            Cursor.lockState = CursorLockMode.None;
        }


        //Activate Indicator when too small
        if(transform.localScale.x <= minSize + ((maxSize - minSize) * 0.2) && !indicatorActive)
        {
            // Activate Indicator Effect
            shader.SetFloat("_BlinkActive", 1);
            indicatorActive = true;
        }

        //Deactivate Indicator when not too small
        if(transform.localScale.x >= minSize + ((maxSize - minSize) * 0.2) && indicatorActive)
        {
            // Deactivate IndicatorEffect
            shader.SetFloat("_BlinkActive", 0);
            indicatorActive = false;
        }
    }

    public void ChangeSize(float change)
    {
        float changedSize = transform.localScale.x + ((maxSize - minSize) * change);
        changedSize = Mathf.Clamp(changedSize, minSize, maxSize);
        transform.localScale = new Vector3(changedSize, changedSize, changedSize);
    }
}
