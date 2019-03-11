using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy;
    public int waveCount;
    public float enemyWaveFrequency;
    public float xMinRange=-9f;
    public float xMaxRange=9f;
    public float yMinRange=3f;
    public float yMaxRange=4f;
    public float SpawnDelay = 2.0f;
    public bool ExponentialWave = true;
    public int nonExponentialWaveSpawned = 3;


    private void Start()
    {
        InvokeRepeating("SpawnEnemyWave", SpawnDelay, enemyWaveFrequency);
    }

    private void SpawnEnemyWave()
    {
        if (ExponentialWave)
        {
            waveCount++;
            for (int i = 0; i < waveCount * 2; i++)
            {
                SpawnSingleEnemy();
            }
        }
        else
        {
            for (int j = 0; j < nonExponentialWaveSpawned; j++)
            {
                SpawnSingleEnemy();
            }
        }

    }

    private void SpawnSingleEnemy()
    {
        float xCoord = Random.Range(xMinRange, xMaxRange);
        float yCoord = Random.Range(yMinRange, yMaxRange);
        Instantiate(enemy, new Vector3(xCoord, yCoord, 0f), transform.rotation);
    }
}
