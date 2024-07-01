using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CinemachineShake : MonoBehaviour
{
    public static CinemachineShake Instance { get; private set; }

    private CinemachineFreeLook cinemachineFreeLook;
    private float shakeTimer;

    private void Awake()
    {
        Instance = this;
        cinemachineFreeLook = GetComponent<CinemachineFreeLook>();
    }

    public void ShakeCamera(float intensity, float time)
    {
        CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin = cinemachineFreeLook.GetComponent<CinemachineBasicMultiChannelPerlin>();


        cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = intensity;
        shakeTimer = time;
    }

    private void Update()
    {
        if (shakeTimer > 0 )
        {
            shakeTimer -= Time.deltaTime;
            if(shakeTimer <= 0f)
            {
                //Time over!
                CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin = cinemachineFreeLook.GetComponent<CinemachineBasicMultiChannelPerlin>();

                cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = 0f;
            }

        }
    }

}
