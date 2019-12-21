using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_sp : MonoBehaviour
{

    public Transform spawnPoints;
    public GameObject blockPreFab;
    public float bulletRate = 0.3f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(bullets());
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        bullets();
    }

    IEnumerator bullets()
    {
        while (true)
        {
            Instantiate(blockPreFab, spawnPoints.position, Quaternion.identity);
            yield return new WaitForSeconds(bulletRate);
        }
    }
}