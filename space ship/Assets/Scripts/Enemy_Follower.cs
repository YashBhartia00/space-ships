using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Follower : MonoBehaviour
{
    Vector3 homeLoc;
    public float startTime, stayTime = 100, speed = 5f;
    public static float spawnInterval = 1;
    void Start()
    {
        homeLoc = transform.position;
        startTime = Time.time;
    }

    void FixedUpdate()
    {
        MoveTowardsPl(speed);
        GoAway();
    }
    public void MoveTowardsPl(float EFspeed)
    {
        if (Vector3.Distance(player.PlayerPos, homeLoc)<0.7)
        {
            transform.position =
             Vector3.MoveTowards(transform.position, player.PlayerPos, Time.deltaTime * EFspeed);
        }
        else
        {
            transform.position =
             Vector3.MoveTowards(transform.position, homeLoc, Time.deltaTime * EFspeed);
        }
    }
    public void GoAway()
    {
        if((Time.time - startTime) > stayTime && transform.position == homeLoc)
        {
            Destroy(gameObject);
        }
    }
}
