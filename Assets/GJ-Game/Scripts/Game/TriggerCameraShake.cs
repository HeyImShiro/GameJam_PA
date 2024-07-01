using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCameraShake : MonoBehaviour
{
    void OnTriggerStay(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            CinemachineShake.Instance.ShakeCamera(5f, .1f);
        }
    }
 }
