using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheeseSize : MonoBehaviour
{
    public float minSize;
    public float maxSize;

    private bool indicatorActive;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.localScale.x <= minSize + ((maxSize - minSize) * 0.2) && !indicatorActive)
        {
            //Activate Indicator Effect

            indicatorActive = true;
        }

        if(transform.localScale.x >= minSize + ((maxSize - minSize) * 0.2) && indicatorActive)
        {
            //Deactivate IndicatorEffect

            indicatorActive = false;
        }
    }

    public void ChangeSize(float change)
    {
        float changedSize = transform.localScale.x + ((maxSize - minSize) * (1 + change)) ;
        transform.localScale = new Vector3(changedSize, changedSize, changedSize);
    }
}
