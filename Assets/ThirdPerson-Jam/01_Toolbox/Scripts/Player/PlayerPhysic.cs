using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPhysic : MonoBehaviour
{
    public float GroundcheckDistance = 0.1f;
    public float GravityMultiplier = 5f;
    public float ForceStrength = 100;
    private float _ySpeed;

    private Animator _animator;
    private CharacterController _characterController;

    private Vector3 _velocity;

    void Start()
    {
        _animator = GetComponent<Animator>();
        _characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (IsGrounded()) 
        {
            _ySpeed = 0;
        }
        else
        {
            _ySpeed = _ySpeed + Physics.gravity.y * GravityMultiplier * Time.deltaTime;
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

            rigidbody.AddForceAtPosition(direction * ForceStrength * _velocity.magnitude, transform.position, ForceMode.Impulse);
        }
    }

    void OnAnimatorMove()
    {
        _animator.ApplyBuiltinRootMotion();

        _velocity = _animator.deltaPosition;
        _velocity.y = _ySpeed;

        _characterController.Move(_velocity * Time.deltaTime);
    }

    private bool IsGrounded() 
    {
        return Physics.Raycast(transform.position + new Vector3(0, GroundcheckDistance * 0.5f, 0), Vector3.down, GroundcheckDistance);
    }

    private void OnDrawGizmos()
    {
        Debug.DrawRay(transform.position + new Vector3(0, GroundcheckDistance * 0.5f, 0), Vector3.down * GroundcheckDistance, IsGrounded() ? Color.green : Color.red);
    }
}
