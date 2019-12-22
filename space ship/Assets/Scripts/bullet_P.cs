using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet_P : MonoBehaviour
{
    public static Vector2 direction;
    public string[] types = new string[3] { "Freeze", "Leech","Follow" };    
    float speed=4000;
    void Start()
    {
        types = new string[3] { "Freeze", "Leech", "Follow" };
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        transform.gameObject.tag = types[1];
        rb.AddForce(direction * speed);

     
    }
    void Update()
    {
    }

}
