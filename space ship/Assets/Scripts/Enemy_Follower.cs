using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Follower : MonoBehaviour
{
    Vector3 homeLoc;
    public float startTime, stayTime = 100, speed = 5f, DPS = 2;
    public static float spawnInterval = 1;
    public bool follow = true,frozen = false, freeze = false ;


    //colors: make new script
    Color freezeblue,leechpurple;
    
    

    void Start()
    {   //colors: make new script
        ColorUtility.TryParseHtmlString("#50B7D1", out freezeblue);
        ColorUtility.TryParseHtmlString("#641450", out leechpurple);

        homeLoc = transform.position;
        startTime = Time.time;
        
    }

    void FixedUpdate()
    {
        CheckFreeze(freeze);
        if (!frozen){
            MoveTowardsPl(speed);
            GoAway();
        } 
        if(transform.position == homeLoc) { follow = true; }

    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        print("FREEZZEE");
        if(collision.gameObject.tag == "Freeze")
        {
            freeze = true;
        }
    }
    public void MoveTowardsPl(float EFspeed)
    {
        if (Vector3.Distance(player.PlayerPos, homeLoc)<0.7 && follow)
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


    public void CheckFreeze(bool Freeze)
    {
        if (Freeze && !frozen)
        {
            Invoke("UnFreeze", 5);
            SpriteRenderer sr = gameObject.GetComponent<SpriteRenderer>();
            sr.color = freezeblue;
            frozen = true;
            freeze = false;
        }

    }    //make script to derive this as enemy behaviours
    public void UnFreeze()
    {
        frozen = false;
        SpriteRenderer sr = gameObject.GetComponent<SpriteRenderer>();
        sr.color = leechpurple;
    }
}
