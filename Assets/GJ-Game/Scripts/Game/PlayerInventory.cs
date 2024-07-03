using TMPro;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    // how many items to collect?
    public CollectibleSpawns collectibleManager;
    public int itemValueToCollect = 10;

    public GameObject victoryScreen;

    // Textfield to display collected items
    public TextMeshProUGUI collectedItemsLabel;

    // Already collected items
    public int collectedItemsValue { get; private set; }

    void Start()
    {
        collectedItemsValue = 0;
        // Anzahl der Items in der Szene suchen?
        // CollectedItemsValue = GameObject.FindObjectsOfType<Item>().Length;

        UpdateHUD();
    }

    public void ItemCollected(int itemValue) 
    {
        collectedItemsValue += itemValue;
        UpdateHUD();
    }

    private void UpdateHUD() 
    {
        collectedItemsLabel.text = collectedItemsValue + "/" + collectibleManager.anzahlSchmuck;
        if(collectedItemsValue == collectibleManager.anzahlSchmuck)
        {
            victoryScreen.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}
