using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheeseDropScript : MonoBehaviour
{
    public GameObject cheesePiece;
    public float upStrength = 50;

    private float delay;


    // Start is called before the first frame update
    void Start()
    {
        //Random direction
        Vector3 throwVector = new Vector3(Random.insideUnitCircle.x, 1, Random.insideUnitCircle.y);
        throwVector = throwVector * upStrength;
        //throw
        gameObject.GetComponent<Rigidbody>().AddForce(throwVector);

        try
        {
            delay = gameObject.GetComponent<TrailRenderer>().time;
        }
        catch
        {
            
        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Initiate Self destructs
        StartCoroutine("WaitTilDestruct");
        //Create Cheese
        Instantiate(cheesePiece, collision.contacts[0].point, Quaternion.identity);

    }

    IEnumerator WaitTilDestruct()
    {
        yield return new WaitForSeconds(delay);
        Destroy(gameObject);
    }
}
