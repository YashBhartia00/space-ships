using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet_P : MonoBehaviour
{
    public static Vector2 direction;
    public string[] types = new string[2] { "Freeze", "Leech" };    
    float speed=6000;
    void Start()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        transform.gameObject.tag = types[0];
        rb.AddForce(direction * speed);
     
    }
    void Update()
    {
    }

}
