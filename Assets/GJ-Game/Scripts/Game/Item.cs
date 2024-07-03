using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    // How valuable the item is
    public int itemValue = 1;

    public float cheeseSizeIncrease;

    public bool isCheese;

    void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<PlayerInventory>() != null) 
        {
            other.GetComponent<PlayerInventory>().ItemCollected(itemValue);

            if (isCheese)
            {
                other.GetComponent<CheeseSize>().ChangeSize(cheeseSizeIncrease);
            }
            gameObject.GetComponent<AudioSource>().Play();
            StartCoroutine("DestroyDelay");
        }

    }

    IEnumerator DestroyDelay()
    {
        yield return new WaitForSeconds(gameObject.GetComponent<AudioSource>().clip.length);
        Destroy(gameObject);
    }

}
