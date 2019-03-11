using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, yMin, yMax;
}

public class PlayerController : MonoBehaviour
{
    public Boundary boundary;
    public float speed;
    public float shotDelay;
    public int lifePoints;
    public GameObject projectile;

    private float nextFire;
    private new Rigidbody2D rigidbody;
    private GameManager gameManager;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        rigidbody.velocity = movement * speed;

        rigidbody.position = new Vector2
        (
            Mathf.Clamp(rigidbody.position.x, boundary.xMin, boundary.xMax),
            Mathf.Clamp(rigidbody.position.y, boundary.yMin, boundary.yMax)
        );
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > shotDelay)
        {
            nextFire = Time.time + shotDelay;
            Instantiate(projectile, transform.position, transform.rotation);
        }

    }

    public void HitByEnemy()
    {
        lifePoints--;
        if (lifePoints <= 0)
        {
            Camera.main.GetComponent<ReloadLevel>().ReloadLevelWithDelay();
            gameManager.GameOver();
            Destroy(gameObject);
        }
    }
}