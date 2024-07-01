using UnityEngine;
using Cinemachine;

public class MovingPlatform : MonoBehaviour
{
    // Get nice curve in inspector to control animation
    public AnimationCurve animationCurve;

    // How long does it take to sample the curve
    public float duration = 3f;

    // Play form the beginning
    public bool playOnStart = true;

    // Elapse time
    private float progress;

    // Moves the platform via cinemachin
    private CinemachineDollyCart chart;

    // Update the position of the platform?
    private bool isMoving;

    // Start is called before the first frame update
    void Start()
    {
        chart = GetComponent<CinemachineDollyCart>();
        isMoving = playOnStart;
    }

    void FixedUpdate()
    {
        if (isMoving)
        {
            // Take the duration for sampling into account
            progress += Time.deltaTime / duration;

            // Normalize value for position (0 - 1)
            float position = animationCurve.Evaluate(progress) % duration;
            chart.m_Position = position;
        }
    }

    // Enter trigger > make player child of this transform
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            isMoving = true;
            other.transform.SetParent(transform);
        }        
    }

    // Exit trigger > unparent the player
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.SetParent(null);
        }
    }
}

