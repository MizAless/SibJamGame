using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public List<GameObject> EnemyPrefabs;
    public int EnemyCount = 20;
    public float SpawnCooldown = 3f;

    private float nextSpawnTime;
    // Start is called before the first frame update
    void Start()
    {
        nextSpawnTime = Time.time + 1f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextSpawnTime)
        {
            SpawnEnemy();
            nextSpawnTime = Time.time + SpawnCooldown;
        }
    }

    public void SpawnEnemy()
    {
        Instantiate(EnemyPrefabs[0], transform.position, Quaternion.identity);
        EnemyCount--;
        if (EnemyCount == 0)
        {
            Destroy(gameObject);
        }
    }
}
