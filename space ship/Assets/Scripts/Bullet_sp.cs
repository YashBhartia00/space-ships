using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_sp : MonoBehaviour
{

    public Transform spawnPoints;
    public GameObject blockPreFab;
    float a, timeTillNextBullet, bulletRate = 0.2f;
        //bulletRate lower means faster bullets

    void Update()

    {
        if (Time.timeSinceLevelLoad >= timeTillNextBullet)
        {
            Instantiate(blockPreFab, spawnPoints.position, Quaternion.identity);
            timeTillNextBullet += bulletRate;
        }
    }
}