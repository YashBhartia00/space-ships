using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    Vector3 homeLoc;
    public float startTime, stayTime = 300, speed = 5f, DPS = 2, health = 3;
    public static float spawnInterval = 1;
    public bool follow = true,frozen, freeze, leech ;
    public int hitNums = 5;

    //SpriteRenderer sr = new SpriteRenderer();


    //colors: make new script
    Color freezeblue,attackorange,leechedpurple;
    
    

    void Start()
    {   //colors: make new script
        ColorUtility.TryParseHtmlString("#50B7D1", out freezeblue);
        ColorUtility.TryParseHtmlString("#FF764C", out attackorange);
        ColorUtility.TryParseHtmlString("#AB799F", out leechedpurple);
        //SpriteRenderer sr = gameObject.GetComponent<SpriteRenderer>();
        homeLoc = transform.position;
        startTime = Time.time;
        
    }

    void FixedUpdate()
    {
        CheckFreeze(freeze,findSprite());
        if (!frozen){
            MoveTowardsPl(speed);
            Destroy();
        } 
        if(transform.position == homeLoc) {follow = true; }

    }
    private void Update()
    {
        leechAction(findSprite());
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {   if(collision.gameObject.tag == "Player") { hitNums -= 1; if (hitNums <= 0) { Destroy(gameObject); } }
        if(collision.gameObject.tag == "Freeze"){freeze = true; Destroy(collision.gameObject); }
        if(collision.gameObject.tag == "Leech") { StartCoroutine(leechAction(findSprite())); Destroy(collision.gameObject); }
    }
   

    public void MoveTowardsPl(float EFspeed)
    {
        if (Vector3.Distance(player.PlayerPos, homeLoc)<2 && follow)
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
    public void Destroy()
    {
        if(((Time.time - startTime) > stayTime && transform.position == homeLoc)|| health<=0)
        {
            Destroy(gameObject);
        }
    }
    public SpriteRenderer findSprite()
    {
        return gameObject.GetComponent<SpriteRenderer>();
    }


    public void CheckFreeze(bool Freeze,SpriteRenderer sr)
    {
        if (Freeze && !frozen)
        {
            //Invoke("UnFreeze", 5);
            StartCoroutine(UnFreeze(sr));
            
            sr.color = freezeblue;
            frozen = true;
            freeze = false;
        }

    }    //make script to derive this as enemy behaviours
    IEnumerator UnFreeze(SpriteRenderer sr)
    {   
        yield return new WaitForSeconds(5);
        frozen = false;
        sr.color = attackorange;
    }

    IEnumerator leechAction(SpriteRenderer sr)
    {
        //health -= 1;
        // change to leech amount
        while (true)
        {
            sr.color = Color.Lerp(attackorange, leechedpurple, Mathf.PingPong(Time.time * 5, 1.0f));
            health -= 0.01f;
            GameObject pl = GameObject.FindGameObjectWithTag("Player");
            player pla = pl.gameObject.GetComponent<player>();
            pla.health += 0.005f;

            //print(health);
            yield return null;
        }
    }
    

}
