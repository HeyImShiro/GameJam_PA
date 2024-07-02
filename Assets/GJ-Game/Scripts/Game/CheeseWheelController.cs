using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheeseWheelController : MonoBehaviour
{
    public float speed;
    public float rotationSpeed;
    public float jumpStrength;

    public Transform gimbal;

    private Rigidbody rb;
    private bool isGrounded = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        // Store inputs
        
        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");
        /*
        rb.velocity = verticalInput * speed * Time.deltaTime * transform.right;
        rb.velocity = horizontalInput * speed * Time.deltaTime * transform.up;
        */

        if(Input.GetAxis("Horizontal") > 0)
        {
            //rb.AddForce(-transform.up * speed);
            //transform.rotation.eulerAngles += rotationSpeed * horizontalInput;
            //transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z - rotationSpeed * horizontalInput);
            //transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
            gimbal.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
        }
        else if (Input.GetAxis("Horizontal") < 0)
        {
            //rb.AddForce(transform.up * speed);
            //transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z - rotationSpeed * horizontalInput);
            //transform.Rotate(Vector3.up, -rotationSpeed * Time.deltaTime);
            gimbal.Rotate(Vector3.up, -rotationSpeed * Time.deltaTime);
        }

        if (Input.GetAxis("Vertical") > 0)
        {
            rb.AddForce(gimbal.right * speed);
        }
        else if (Input.GetAxis("Vertical") < 0)
        {
            rb.AddForce(-gimbal.right * speed);
        }


        if(Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(-transform.forward * jumpStrength);
            isGrounded = false;
        }


    }

    private void LateUpdate()
    {
        transform.localEulerAngles = new Vector3(0, gimbal.localEulerAngles.y, transform.localEulerAngles.z);
    }

    private void OnCollisionEnter(Collision collision)
    {
        
        if (Physics.Raycast(gameObject.transform.position, Vector3.down))
        {
            isGrounded = true;
            Debug.Log("is Grounded reset");
        }
    }
}
