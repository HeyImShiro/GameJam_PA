using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gimbal : MonoBehaviour
{
    

    public Transform playerTransform;

    private void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Set Transform equal to Parents transform
        transform.position = playerTransform.position;
    }
}
