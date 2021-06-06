using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public List<GameObject> Enemies = new List<GameObject>();
    public float spawnRate;

    private float x, y;
    private Vector3 spawnPosition;
    void Start()
    {
        StartCoroutine(SpawnTestEnemy());
    }

    IEnumerator SpawnTestEnemy()
    {
        x = Random.Range(-1, 1);
        y = Random.Range(-1, 1);
        spawnPosition = Vector3.zero;
        spawnPosition = transform.position;
        spawnPosition.x += x;
        spawnPosition.y += y;
        Instantiate(Enemies[0], spawnPosition, Quaternion.identity);
        yield return new WaitForSeconds(spawnRate);
        StartCoroutine(SpawnTestEnemy());
    }
}
