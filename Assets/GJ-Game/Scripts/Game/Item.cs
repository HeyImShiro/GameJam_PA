using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    // How valuable the item is
    public int itemValue = 1;

    void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<PlayerInventory>() != null) 
        {
            other.GetComponent<PlayerInventory>().ItemCollected(itemValue);
            Destroy(gameObject);
        }

    }
}
