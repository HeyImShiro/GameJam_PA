using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FogController : MonoBehaviour
{
    // Script written by Heiko Liebel

    /*
       WHAT IT DOES:
       This Script can control the Fog that can be accessed under Lighting -> Environment
       It can be used to make fog appear/disappear gradually once the player touches a TriggerCollider with this script

       HOW TO USE:
       Put this Script on a (empty)GameObject with a Collider that is set to "Is Trigger"
       Adjust the Collider and Variables according to your needs
       Make sure the Player Character is tagged as "Player"
    */

    // How far is the fog / how much can the Player see
    public float fogEndDistance;

    // How fast does the fog go away
    public float fogClearSpeed;

    // The max distance at which the fog gets turned off
    public float fogClearDistance;


    void Start()
    {
        RenderSettings.fog = true;
        RenderSettings.fogEndDistance = fogEndDistance;
    }
    

    // When Object tagged as "Player" is inside the TriggerZone...
     void OnTriggerStay(Collider other)
    { 
        // ... gradually increase FogEndDistance
        if (other.CompareTag("Player") && fogEndDistance <= fogClearDistance)
        {
            for (int i = 0; i < 200; i++)
            {
                RenderSettings.fogEndDistance = fogEndDistance += Time.deltaTime * fogClearSpeed;
            }
        }
        // ... and then delete the TriggerZone and turn fog off when FogEndDistance is greater than fogClearDistance
        else if (other.CompareTag("Player") && fogEndDistance >= fogClearDistance)
        {
            RenderSettings.fog = false;
            Destroy(gameObject);
        }
    }

}
