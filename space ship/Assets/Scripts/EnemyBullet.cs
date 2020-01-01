using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    float speed = 100;
    public static Vector2 direction;
    public float damage = 3;
    void Start()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.AddForce(direction * speed);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            player script = collision.gameObject.GetComponent<player>();
            script.health -= (int)damage;
            print("Health = " + script.health);
            Destroy(gameObject);
        }
    }
}
