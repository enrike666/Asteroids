using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float spawnDelay;
    public GameObject Item;

    void Start()
    {
        InvokeRepeating("Spawn", spawnDelay, spawnDelay);
    }

    void Spawn()
    {
        float xPos = Random.Range(-30f, 30f);
        Vector3 spawnPos = new Vector3(xPos, 70f, 0);     
        Instantiate(Item, spawnPos, transform.rotation);
    }
}
