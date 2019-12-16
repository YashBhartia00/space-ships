using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_sp : MonoBehaviour
{

    public Transform spawnPoints;
    public GameObject blockPreFab;

    // Start is called before the first frame update
    void Start()
    {
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1)){
            Instantiate(blockPreFab, spawnPoints.position, Quaternion.identity);
        }
    }
}