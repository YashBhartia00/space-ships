using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet_P : MonoBehaviour
{
    public static Vector2 direction;
    public string[] types = new string[4] {"Normal", "Freeze", "Leech","Follow" };    
    float a, speed=4000;
    void Start()
    {
       types = new string[4] { "Normal", "Freeze", "Leech", "Follow" };
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        //print(player.BulletType);
        transform.gameObject.tag = types[player.BulletType];
        rb.AddForce(direction * speed);
        a = Time.time;
        print(transform.gameObject.tag);
    }
    void Update()
    {
        if(Time.time- a >= 1)
        {
            Destroy(gameObject);
        }
    }

}
