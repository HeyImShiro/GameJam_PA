using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class SimplePlayerController : MonoBehaviour
{
    // how fast the character can move
    public float maxMovementSpeed;

    // how fast the character can turn
    public float rotationSpeed;

    // How far in m the distance check work
    public float groundCheckDistance = 0.1f;

    // Influence the gravity 
    public float gravityMultiplier = 1f;

    // Is character audible (moving fast)
    public bool isAudible { get; private set; }

    // Component to move character
    private CharacterController characterController;

    // Cache the camera transform
    private Transform cameraTransform;    

    // How fast the charakter moves to the ground (gravity speed)
    private float ySpeed;

    // Start is called before the first frame update
    void Start()
    {
        ySpeed = 0;
        cameraTransform = Camera.main.transform;

        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        // Stores inputs
        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");

        // Create Vector from inputs
        Vector3 movementDirection = new Vector3(horizontalInput, 0, verticalInput);
        float inputMagnitude = Mathf.Clamp01(movementDirection.magnitude);

        // Should walk? (left or right shift held)
        bool shouldWalk = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);

        // Set speed to half of input when charakter should walk
        // otherwise use horizontal input
        float speed = shouldWalk ? inputMagnitude * 0.333f : inputMagnitude;        

        // Make movement direction depend on camera rotation
        movementDirection = Quaternion.AngleAxis(cameraTransform.rotation.eulerAngles.y, Vector3.up)
            * movementDirection;
        
        // Rotate the character to movement direction
        if (movementDirection != Vector3.zero)
        {
            Quaternion targetCharacterRotation = Quaternion.LookRotation(movementDirection, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetCharacterRotation, rotationSpeed * Time.deltaTime);
        }

        // Calculate gravity
        ySpeed = IsGrounded() ? ySpeed = 0 : ySpeed += Physics.gravity.y * gravityMultiplier * Time.deltaTime;
        movementDirection.y = ySpeed;

        // Move the character        
        characterController.Move(movementDirection * speed * maxMovementSpeed * Time.deltaTime);

        // Character is audible, when moving fast
        isAudible = speed >= 0.5f;
    }

    /// <summary>
    /// Check if the chracter is on ground (Perform a raycast)
    /// </summary>
    /// <returns>True if the raycasts hit smthg. in distance</returns>
    private bool IsGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, characterController.height * 0.5f + groundCheckDistance);
    }

    /// <summary>
    /// Visualize the raycast for testing purposes
    /// </summary>
    private void OnDrawGizmos()
    {
        if(characterController!=null)
        {
            Debug.DrawRay(transform.position, Vector3.down * (characterController.height * 0.5f + groundCheckDistance), IsGrounded() ? Color.cyan : Color.red);
        }        
    }
}
