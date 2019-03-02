using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    public float speed;
    public float lifetime;
    private GameObject target;

    void Start()
    {
        target = GameObject.FindWithTag("Player");
        var direction = target.transform.position - transform.position;
        GetComponent<Rigidbody2D>().velocity = direction * speed;
        Destroy(gameObject, lifetime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals(target.tag))
        {
            target.GetComponent<PlayerController>().HitByEnemy();
            Destroy(gameObject);
        }
    }
}
