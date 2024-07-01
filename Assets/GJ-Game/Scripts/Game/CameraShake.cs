using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraShake : MonoBehaviour
{

    private CinemachineFreeLook cinemachineFreeLook;

        
    private float shakeIntensity = 1f;
    private float shakeTime = 0.2f;

    private float timer;
    private CinemachineBasicMultiChannelPerlin cbmcp;

    void Awake()
    {
        cinemachineFreeLook = GetComponent<CinemachineFreeLook>();
    }

    // Start is called before the first frame update
    void Start()
    {
        StopShake(); 
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            ShakeCamera();
        }

        if(timer > 0)
        {
            timer -= Time.deltaTime;

            if(timer <= 0 )
            {
                StopShake();
            }
        }
    }

    public void ShakeCamera()
    {
        CinemachineBasicMultiChannelPerlin cbmcp = cinemachineFreeLook.GetComponent<CinemachineBasicMultiChannelPerlin>();
        cbmcp.m_AmplitudeGain = shakeIntensity;

        timer = shakeTime;
    }

    void StopShake()
    {
        CinemachineBasicMultiChannelPerlin cbmcp = cinemachineFreeLook.GetComponent<CinemachineBasicMultiChannelPerlin>();
        cbmcp.m_AmplitudeGain = 0f;
        timer = 0;
    }

        

}
