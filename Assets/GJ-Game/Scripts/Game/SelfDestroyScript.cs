using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestroyScript : MonoBehaviour
{
    private float duration;
    private float timer;
    private GameObject test;

    private void Start()
    {
        duration = gameObject.GetComponent<ParticleSystem>().main.duration;
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer > duration)
        {
            Destroy(gameObject);
        }
    }
    
}
