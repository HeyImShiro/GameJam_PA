using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public float rotationSpeed;
    public bool rotateY;

    // Update is called once per frame
    void Update()
    {
        // Rotate
        if(rotateY)
        {
            transform.Rotate(Vector3.up * Time.deltaTime * rotationSpeed);
        }
        else
        {
            transform.Rotate(Vector3.forward * Time.deltaTime * rotationSpeed);
        }
    }
}
