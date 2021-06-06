using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootSpawnAndDroptables : MonoBehaviour
{
    [SerializeField] public GameObject Chest;
    [SerializeField] public GameObject[] Spawnables;
    [SerializeField] public GameObject[] Loot;
    [SerializeField] public GameObject[] CurrencyDrops;
    [SerializeField] public GameObject Enemy;

    private float randomX;
    private float randomY;
    private int rand;
    private int Currency;
    
    public void RoomLootSpawner(Transform position)
    {

        randomX = Random.Range(-4, 4);
        randomY = Random.Range(-4, 4);
        rand = Random.Range(0, Spawnables.Length);
        Vector3 spawnPosition = new Vector3(position.position.x + randomX, position.position.y + randomY, position.position.z);
        Instantiate(Spawnables[rand], spawnPosition, Quaternion.identity);
           
    }
    public void EnemySpawner(Transform position)
    {
        randomX = Random.Range(-4, 4);
        randomY = Random.Range(-4, 4);
        Vector3 spawnPosition = new Vector3(position.position.x + randomX, position.position.y + randomY, position.position.z);
        Instantiate(Enemy, spawnPosition, Quaternion.identity);
    }

    public void Openchest(Transform transform)
    {
        rand = Random.Range(0, Loot.Length);
        Instantiate(Loot[rand], transform.position, Quaternion.identity);
        Currency = Random.Range(0, CurrencyDrops.Length);

        rand = Random.Range(0, 3);
        for (int i = 0; i < rand; i++)
        {
            Instantiate(CurrencyDrops[Currency], transform.position, Quaternion.identity);
        }
    }

   
}
