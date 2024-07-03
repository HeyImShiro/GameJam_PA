using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleSpawns : MonoBehaviour
{
    public int anzahlSchmuck;
    public List<Vector3> schmuckSpawnListe;
    public List<GameObject> schmuckPrefabs;

    public int anzahlCheese;
    public List<Vector3> cheeseSpawnListe;
    public List<GameObject> cheesePrefabs;



    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < anzahlSchmuck; i++)
        {
            Instantiate(schmuckPrefabs[Random.Range(0, schmuckPrefabs.Count + 1)], schmuckSpawnListe[Random.Range(0, schmuckSpawnListe.Count + 1)], Quaternion.identity);
        }

        for (int i = 0; i < anzahlCheese; i++)
        {
            Instantiate(cheesePrefabs[Random.Range(0, schmuckPrefabs.Count + 1)], cheeseSpawnListe[Random.Range(0, schmuckSpawnListe.Count + 1)], Quaternion.identity);
        }
    }

}
