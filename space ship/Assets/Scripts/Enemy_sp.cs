﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_sp : MonoBehaviour
{
    public Vector3 spawnPoint;
    public GameObject[] blockPreFabs = new GameObject[2];
    public float lastSpawn;
    public int enemyRemain = 29,spawnInterval=2;
    public GameObject[] enemiesGO = new GameObject [30];
    //enemy[] enemyScripts = new enemy[30];
    
    

    void Start(){
    }

    void Update()
    {
        if (TimeToSpawn(spawnInterval))
        {
            spawnPoint = GenerateSp();
            if (enemyRemain >= 0)
            {
                enemiesGO[enemyRemain] = Instantiate(blockPreFabs[0], spawnPoint, Quaternion.identity);
                enemyRemain -= 1;
            }
            else
            {
                SPAWN(spawnPoint);

            }
        }

    }
    public Vector3 GenerateSp()
        {   
            
            Vector3 sp = Camera.main.transform.position +new Vector3(0,0,10) +  new Vector3 (Random.Range(-1.1f, 1.1f), Random.Range(-1.1f, 1.1f), 0)* 2f;
            while (Vector3.Distance(sp, Camera.main.transform.position) < 0.9) 
            {
                sp = Camera.main.transform.position + new Vector3(0, 0, 10) + new Vector3(Random.Range(-1.1f, 1.1f), Random.Range(-1.1f, 1.1f), 0) * 2f;
        }
            return sp;
        }
    public bool TimeToSpawn(float spawninterval)
    {   
        if (spawninterval<Time.time - lastSpawn) 
        {
            lastSpawn = Time.time;
            return true; 
        }
        else { return false; }
    }

    void SPAWN(Vector3 sp)
    {
        for(int i=0; i<enemiesGO.Length; i++)
        {
            if(enemiesGO[i] == null)
            {
                int enemyType = (int)Random.Range(0, 2);
                enemiesGO[i] = Instantiate(blockPreFabs[enemyType], sp, Quaternion.identity);
                break;
            }
        }
    }

    

}

