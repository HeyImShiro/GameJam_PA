using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPhysic : MonoBehaviour
{
    public float groundcheckDistance = 0.1f;
    public float gravityMultiplier = 5f;
    public float forceStrength = 100;

    private float ySpeed;

    private Animator animator;
    private CharacterController characterController;

    private Vector3 velocity;

    void Start()
    {
        animator = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (IsGrounded()) 
        {
            ySpeed = 0;
        }
        else
        {
            ySpeed = ySpeed + Physics.gravity.y * gravityMultiplier * Time.deltaTime;
        }
    }

    /// <summary>
    /// Wird aufgerufen wenn der Charakter mit einem Collider in Berührung kommt
    /// </summary>
    /// <param name="hit"></param>
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Rigidbody rigidbody = hit.collider.attachedRigidbody;

        if(rigidbody != null) 
        {
            Vector3 direction = hit.gameObject.transform.position - transform.position;
            direction.y = 0;
            direction.Normalize();

            rigidbody.AddForceAtPosition(direction * forceStrength * velocity.magnitude, transform.position, ForceMode.Impulse);
        }
    }

    void OnAnimatorMove()
    {
        animator.ApplyBuiltinRootMotion();

        velocity = animator.deltaPosition;
        velocity.y = ySpeed;

        characterController.Move(velocity * Time.deltaTime);
    }

    private bool IsGrounded() 
    {
        return Physics.Raycast(transform.position + new Vector3(0, groundcheckDistance * 0.5f, 0), Vector3.down, groundcheckDistance);
    }

    private void OnDrawGizmos()
    {
        Debug.DrawRay(transform.position + new Vector3(0, groundcheckDistance * 0.5f, 0), Vector3.down * groundcheckDistance, IsGrounded() ? Color.green : Color.red);
    }
}
