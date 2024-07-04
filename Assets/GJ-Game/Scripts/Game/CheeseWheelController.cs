using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheeseWheelController : MonoBehaviour
{
    public float speed;
    public float speedBoostMultiplier;
    public float rotationSpeed;
    public float jumpStrength;
    public float kickStrength;
    public float kickSizeReduction;

    public Transform gimbal;

    public GameObject impactEffect;
    public GameObject cheeseDrop;
    public AudioClip kickAudio;

    public TrailRenderer boostTrail;

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


        // Character Movement
        if(Input.GetAxis("Horizontal") > 0)
        {

            gimbal.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
        }
        else if (Input.GetAxis("Horizontal") < 0)
        {
            gimbal.Rotate(Vector3.up, -rotationSpeed * Time.deltaTime);
        }

        if (Input.GetAxis("Vertical") > 0)
        {
            rb.AddForce(gimbal.right * speed * Time.deltaTime);
        }
        else if (Input.GetAxis("Vertical") < 0)
        {
            rb.AddForce(-gimbal.right * speed * Time.deltaTime);
        }

        // Jump
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpStrength);
            isGrounded = false;
        }

        // Speedboost on Shift
        if(Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift))
        {
            speed *= speedBoostMultiplier;
            boostTrail.emitting = true;

        }

        if(Input.GetKeyUp(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift))
        {
            speed /= speedBoostMultiplier;
            boostTrail.emitting = false;
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
            Instantiate(impactEffect, transform.position - new Vector3(0, sphereCol.radius * transform.localScale.x, 0), Quaternion.identity);
        }

        // NPC Kick
        if (collision.gameObject.CompareTag("NPC") && collision.gameObject.GetComponent<Animator>().GetBool("isWalking") )
        {
            //Reduce Size
            gameObject.GetComponent<CheeseSize>().ChangeSize(kickSizeReduction);
            //Kick
            rb.AddForce((transform.position - collision.transform.position).normalized * kickStrength);
            //Play Kick Audio
            gameObject.GetComponent<AudioSource>().PlayOneShot(kickAudio);
            //Spawn Cheese Part
            Instantiate(cheeseDrop, transform.position, Quaternion.identity);
        }


    }



}
