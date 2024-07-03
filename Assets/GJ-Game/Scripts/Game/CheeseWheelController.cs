using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheeseWheelController : MonoBehaviour
{
    public float speed;
    public float rotationSpeed;
    public float jumpStrength;
    public float kickStrength;
    public float kickSizeReduction;

    public Transform gimbal;

    public GameObject impactEffect;

    private Rigidbody rb;
    private bool isGrounded = true;
    private SphereCollider sphereCol;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        sphereCol = gameObject.GetComponent<SphereCollider>();
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

        // Character Movement
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

        // Jump
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpStrength);
            isGrounded = false;
        }

    }

    private void LateUpdate()
    {
        // Prevent falling over
        transform.localEulerAngles = new Vector3(0, gimbal.localEulerAngles.y, transform.localEulerAngles.z);
    }

    private void OnCollisionEnter(Collision collision)
    {
        // IsGrounded Reset
        if (Physics.Raycast(gameObject.transform.position, Vector3.down))
        {
            isGrounded = true;
            Debug.Log("is Grounded reset");
            Instantiate(impactEffect, transform.position - new Vector3(0, sphereCol.radius, 0), Quaternion.identity);
        }

        // NPC Kick
        if (collision.gameObject.CompareTag("NPC") && collision.gameObject.GetComponent<Animator>().GetBool("isWalking") )
        {
            //Reduce Size
            gameObject.GetComponent<CheeseSize>().ChangeSize(kickSizeReduction);
            //Kick
            rb.AddForce((transform.position - collision.transform.position).normalized * kickStrength);
            //Spawn Cheese Part
        }


    }



}
