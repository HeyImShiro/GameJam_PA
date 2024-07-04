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
        // Rotate...
        if(rotateY)
        {
            // ...around Y-Axis if bool is true
            transform.Rotate(Vector3.up * Time.deltaTime * rotationSpeed);
        }
        else
        {
            // ...around Z-Axis if bool is false
            transform.Rotate(Vector3.forward * Time.deltaTime * rotationSpeed);
        }
    }
}
