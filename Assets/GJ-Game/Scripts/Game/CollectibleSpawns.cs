using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleSpawns : MonoBehaviour
{
    public int anzahlSchmuck;
    public GameObject jewelrySpawnParent;
    private List<Transform> jewelrySpawnListe = new List<Transform>();
    public List<GameObject> jewelryPrefabs;

    public int anzahlCheese;
    public GameObject cheeseSpawnParent;
    private List<Transform> cheeseSpawnListe = new List<Transform>();
    public List<GameObject> cheesePrefabs;



    // Start is called before the first frame update
    void Start()
    {
        Transform[] jewelryTransforms = jewelrySpawnParent.GetComponentsInChildren<Transform>();
        Transform[] cheeseTransforms = cheeseSpawnParent.GetComponentsInChildren<Transform>();

        foreach (Transform item in jewelryTransforms)
        {
            jewelrySpawnListe.Add(item);
        }
        foreach (Transform item in cheeseTransforms)
        {
            cheeseSpawnListe.Add(item);
        }

        for (int i = 0; i < anzahlSchmuck; i++)
        {
            int spawnLocationIndex = Random.Range(0, jewelrySpawnListe.Count);
            Instantiate(jewelryPrefabs[Random.Range(0, jewelryPrefabs.Count)], jewelrySpawnListe[spawnLocationIndex].position, jewelrySpawnListe[spawnLocationIndex].rotation);
            jewelrySpawnListe.RemoveAt(spawnLocationIndex);
        }

        for (int i = 0; i < anzahlCheese; i++)
        {
            int spawnLocationIndex = Random.Range(0, cheeseSpawnListe.Count);
            Instantiate(cheesePrefabs[Random.Range(0, jewelryPrefabs.Count)], cheeseSpawnListe[spawnLocationIndex].position, jewelrySpawnListe[spawnLocationIndex].rotation);
            cheeseSpawnListe.RemoveAt(spawnLocationIndex);
        }
    }

}
