using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ItemSpawnerBehaviour : MonoBehaviour
{
    [SerializeField]
    private GameObject[] items;
    [SerializeField]
    private Transform spawnpoint;
    [SerializeField]
    private float spawnTime;
    private float currentSpawnTime;

    private void Start()
    {
        currentSpawnTime = spawnTime;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        currentSpawnTime -= Time.deltaTime;
        SpawnItem();
    }

    private void SpawnItem()
    {
        if (currentSpawnTime <= 0 && spawnpoint.childCount == 0) //Check if an item has already been spawned
        {
            Instantiate(items[Random.Range(0, (items.Length))], spawnpoint);
            currentSpawnTime = spawnTime;
        }
    }
}
