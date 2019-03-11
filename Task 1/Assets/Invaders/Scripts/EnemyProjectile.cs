using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    public float speed;
    public float lifetime;
    private GameObject target;
    public GameObject hitFX;
    public GameObject AsteroidhitFX;

    void Start()
    {
        target = GameObject.FindWithTag("Player");
        if (target == null) return;
        var direction = target.transform.position - transform.position;
        GetComponent<Rigidbody2D>().velocity = direction * speed;
        Destroy(gameObject, lifetime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //targetCollider = GameObject.FindWithTag("Asteroid");
        if (collision.gameObject.tag.Equals(target.tag))
        {
            target.GetComponent<PlayerController>().HitByEnemy();
            Instantiate(hitFX, transform.position, transform.rotation);
            Destroy(gameObject);
        }
        else if (collision.gameObject.tag.Equals("Asteroid"))
        {
            Instantiate(AsteroidhitFX, transform.position, transform.rotation);
            Destroy(gameObject);

        }


    }
    /*private void OnCollisionEnter2D(Collider2D collision)
    {
        //targetCollider = GameObject.FindWithTag("Asteroid");
        if (collision.gameObject.tag.Equals("Asteroid"))
        {
            Instantiate(AsteroidhitFX, transform.position, transform.rotation);
            Destroy(gameObject);

        }
        
    }*/
}

