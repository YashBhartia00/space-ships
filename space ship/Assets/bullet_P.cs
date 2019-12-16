using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet{
float speed,screentime;
int pierce, damage;
Rigidbody2D bulletRb;
public Vector2 dir = new Vector2(1,1);

    public Bullet(float speed, float screentime, int pierce, int damage,Rigidbody2D bulletRb,Vector2 dir){
        this.speed = speed;
        //this.precision = precision;
        this.pierce = pierce;
        this.damage = damage;
        this.bulletRb = bulletRb;
        this.screentime = screentime;
        this.dir = dir;
    }
    public void bulletMove(){
        bulletRb.AddForce(dir * this.speed); 
    }
    public void bulletDestroy()
    {

    }
}

public class bullet_P : MonoBehaviour
{
    public static Vector2 direction;
    void Start()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        Bullet shot = new Bullet(6000,10, 3, 5, rb,direction);
        shot.bulletMove();
     
    }
    void Update()
    {
    }
}
