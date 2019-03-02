using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy;
    public int waveCount;
    public float enemyWaveFrequency;

    private void Start()
    {
        InvokeRepeating("SpawnEnemyWave", 2.0f, enemyWaveFrequency);
    }

    private void SpawnEnemyWave()
    {
        waveCount++;
        for (int i = 0; i < waveCount * 2; i++)
        {
            SpawnSingleEnemy();
        }

    }

    private void SpawnSingleEnemy()
    {
        float xCoord = Random.Range(-9f, 9f);
        float yCoord = Random.Range(3f, 4f);
        Instantiate(enemy, new Vector3(xCoord, yCoord, 0f), transform.rotation);
    }
}
