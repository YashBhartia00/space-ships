using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leech : MonoBehaviour
{
    public float leechAmount = 2;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            player script = collision.gameObject.GetComponent<player>();
            script.health -= (int)leechAmount;
            Enemy_Follower leechBOI = gameObject.GetComponent<Enemy_Follower>();
            leechBOI.follow = false;
            print("Health = " + script.health);

        }
    }
}

