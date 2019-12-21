using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_sp : MonoBehaviour
{
    public Vector3 spawnPoint;
    public GameObject blockPreFab;
    public float lastSpawn;

    

    void Start(){
    }

    void Update()
    {
        if (TimeToSpawn(Enemy_Follower.spawnInterval))
        {
            spawnPoint = GenerateSp();
            //print(spawnPoint);
            Instantiate(blockPreFab, spawnPoint, Quaternion.identity);
        }
    }
    public Vector3 GenerateSp()
        {
            Vector3 sp = Camera.main.transform.position +new Vector3(0,0,10) + 
                new Vector3 (Random.Range(-0.21f, 0.21f), Random.Range(-0.21f, 0.21f), 0)* 5f;
            return sp;
        }
    public bool TimeToSpawn(float spawninterval)
    {
        if (spawninterval<Time.time - lastSpawn) {
            lastSpawn = Time.time;
                return true; }
        else { return false; }
    }
}

