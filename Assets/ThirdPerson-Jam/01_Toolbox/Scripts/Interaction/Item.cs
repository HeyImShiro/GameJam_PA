using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    // How valuable the item is
    public int ItemValue = 1;

    void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<PlayerInventory>() != null) 
        {
            other.GetComponent<PlayerInventory>().ItemCollected(ItemValue);
            Destroy(gameObject);
        }

    }
}
