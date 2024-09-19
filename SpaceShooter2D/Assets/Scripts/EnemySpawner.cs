using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject prefabEnemy;
    float maxSpawnRateInSeconds = 5f;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("SpawnEnemy", maxSpawnRateInSeconds);
        InvokeRepeating("SpawnEnemy", 0f, 30f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SpawnEnemy()
    {
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0,0));   
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1,1));   
        GameObject anEnemy = (GameObject)Instantiate(prefabEnemy);
        anEnemy.transform.position = new Vector2(Random.Range(min.x, max.x),max.y);
        // Schedule when to spawn next enemy
        ScheduleNextEnemySpawn();
    }
    void ScheduleNextEnemySpawn()
    {
        float spawnInSeconds;
        if(maxSpawnRateInSeconds > 1f)
        {
            spawnInSeconds = Random.Range(1f, maxSpawnRateInSeconds);
        }
        else
        {
            spawnInSeconds = 1f;
        }
        Invoke("SpawnEnemy", spawnInSeconds);
    }
    void IncreaseSpawnRate()
    {
        if(maxSpawnRateInSeconds > 1f)
        {
            maxSpawnRateInSeconds--;
        }
        if(maxSpawnRateInSeconds == 1f)
        {
            CancelInvoke("IncreaseSpawnRate");
        }
    }
}
