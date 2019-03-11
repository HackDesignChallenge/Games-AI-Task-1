using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float shootingFrequency;
    public GameObject enemyProjectile;
    public GameObject enemyExplosion;

    void Start()
    {
        InvokeRepeating("ShootAtPlayer", 1.0f, Random.Range(shootingFrequency - 0.5f, shootingFrequency + 0.5f));
    }

    public void HitByPlayer()
    {
        Instantiate(enemyExplosion, transform.position, transform.rotation);
        Destroy(gameObject);
    }

    private void ShootAtPlayer()
    {
        Instantiate(enemyProjectile, transform.position, transform.rotation);
    }
}
