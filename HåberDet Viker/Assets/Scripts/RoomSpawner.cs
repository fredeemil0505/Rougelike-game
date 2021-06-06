using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour
{
    public int openingDirection;
    // 1 --> need bottom door
    // 2 --> need top door
    // 3 --> need left door
    // 4 --> need right door

    private RoomTemplates templates;
    private LootSpawnAndDroptables lootSpawnAndDroptables;
    private int rand;
    private bool spawned = false;

    public float waitTime = 4f;
    void Start()
    {
        Destroy(gameObject, waitTime);
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
        lootSpawnAndDroptables = GameObject.FindGameObjectWithTag("LootSpawn&Droptables").GetComponent<LootSpawnAndDroptables>();
        Invoke("Spawn", 0.2f);
    }

    void Spawn()
    {
      
        if (spawned == false)
        {
            if (openingDirection == 1)
            {
                //Need to Spawn a room with a BOTTOM door.
                rand = Random.Range(0, templates.botomRooms.Length);
                Instantiate(templates.botomRooms[rand], transform.position, Quaternion.identity);
                lootSpawnAndDroptables.RoomLootSpawner(transform);
                lootSpawnAndDroptables.EnemySpawner(transform);
            }
            else if (openingDirection == 2)
            {
                //Need to Spawn a room with a TOP door.
                rand = Random.Range(0, templates.topRooms.Length);
                Instantiate(templates.topRooms[rand], transform.position, Quaternion.identity);
               lootSpawnAndDroptables.RoomLootSpawner(transform);
                lootSpawnAndDroptables.EnemySpawner(transform);
            }
            else if (openingDirection == 3)
            {
                //Need to Spawn a room with a LEFT door.
                rand = Random.Range(0, templates.leftRooms.Length);
                Instantiate(templates.leftRooms[rand], transform.position, Quaternion.identity);
               lootSpawnAndDroptables.RoomLootSpawner(transform);
                lootSpawnAndDroptables.EnemySpawner(transform);
            }
            else if (openingDirection == 4)
            {
                //Need to Spawn a room with a RIGHT door.
                rand = Random.Range(0, templates.rightRooms.Length);
                Instantiate(templates.rightRooms[rand], transform.position, Quaternion.identity);
               lootSpawnAndDroptables.RoomLootSpawner(transform);
                lootSpawnAndDroptables.EnemySpawner(transform);
            }
            spawned = true;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
       
        if (collision.CompareTag("SpawnPoint"))
        {
            if (collision.GetComponent<RoomSpawner>().spawned == false && spawned == false)
            {
                Instantiate(templates.closedRoom, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
            spawned = true;

                //Destroy(gameObject);
        }
        // if (collision.GetComponent<RoomSpawner>().spawned == false && spawned == false)
        //{
        //    Instantiate(templates.TRBL, transform.position, Quaternion.identity);
        //}
    }
}
