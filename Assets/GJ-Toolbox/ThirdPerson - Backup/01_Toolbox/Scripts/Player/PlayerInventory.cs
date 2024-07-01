using TMPro;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    // how many items to collect?
    public int ItemValueToCollect = 10;

    // Textfield to display collected items
    public TextMeshProUGUI collectedItemsLabel;

    // Already collected items
    public int CollectedItemsValue { get; private set; }

    void Start()
    {
        CollectedItemsValue = 0;
        // Anzahl der Items in der Szene suchen?
        // CollectedItemsValue = GameObject.FindObjectsOfType<Item>().Length;

        UpdateHUD();
    }

    public void ItemCollected(int itemValue) 
    {
        CollectedItemsValue += itemValue;
        UpdateHUD();
    }

    private void UpdateHUD() 
    {
        collectedItemsLabel.text = CollectedItemsValue + "/" + ItemValueToCollect;
    }
}
