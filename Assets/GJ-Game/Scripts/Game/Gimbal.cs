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
        transform.position = playerTransform.position;
        Debug.Log(playerTransform.localEulerAngles.y);
        transform.eulerAngles = new Vector3(0 ,playerTransform.localEulerAngles.y ,0);
    }
}
