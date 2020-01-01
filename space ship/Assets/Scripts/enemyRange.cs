using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyRange : MonoBehaviour
{
    Vector3 homeLoc;
    public float startTime,prog,stayTime = 700, speed = 1f, DPS = 3.5f, health = 9, timeBeforeAttack = 2;
    float dirx, diry;
    Color freezeblue, arrowteal, chargedgreen, leechedpurple;
    bool attacking,frozen, freeze;
    Rigidbody2D rb;
    Vector2 direction;
    public int hitNums = 5;

    public Transform spawnPoints;
    public GameObject blockPreFab;
    float a, timeTillNextBullet, bulletRate = 0.2f;
    //bulletRate lower means faster bullets

    void Start()
    {
        
        ColorUtility.TryParseHtmlString("#50B7D1", out freezeblue);
        ColorUtility.TryParseHtmlString("#AB799F", out leechedpurple);
        ColorUtility.TryParseHtmlString("#00FFDF", out arrowteal);
        ColorUtility.TryParseHtmlString("#3FD266", out chargedgreen);

        homeLoc = transform.position;
        startTime = Time.time;
        rb = GetComponent<Rigidbody2D>();
        //StartCoroutine(Movements());
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        CheckFreeze(freeze, findSprite());
        if (!frozen)
        {
            direction = new Vector2(player.PlayerPos.x - transform.position.x, player.PlayerPos.y - transform.position.y);
            transform.up = direction;
            Movements();
            Destroy();
        }
        
    }

    public void Movements()
    {
        prog += Time.deltaTime/2;
        
        if (Vector3.Distance(player.PlayerPos, transform.position) < 0.5f && !attacking)
            {
                attacking = true;
                attack(findSprite());
                StartCoroutine(attacks());
            }
            else if(!attacking)
            {
            //findSprite().color = Color.Lerp(arrowteal, chargedgreen, prog);
            rb.AddForce(direction * speed);
                //print("Moving");
            }
        
  
    }

    public void attack(SpriteRenderer sr)
    {
        
        dirx = direction.x;
        diry = direction.y;
        Vector3 blah = new Vector3(dirx * -3, diry * -3, transform.position.z);
        //print("attacking");
        EnemyBullet.direction = direction;
        Instantiate(blockPreFab, spawnPoints.position, Quaternion.identity);
        transform.position = Vector3.MoveTowards(transform.position,blah , 0.2f);
        //print(blah);
    }

   IEnumerator attacks()
    {
        //sr.color = Color.Lerp(arrowteal, chargedgreen, 5);
        yield return new WaitForSeconds(2);
        attacking = false;
    }




    //from the other enemy & no modifications ake anohter script PLEASE
    public SpriteRenderer findSprite()
    {
        return gameObject.GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player") { hitNums -= 1 ; if (hitNums <= 0) { Destroy(gameObject); } }
        if (collision.gameObject.tag == "Freeze") { freeze = true; Destroy(collision.gameObject); }
        if (collision.gameObject.tag == "Leech") { StartCoroutine(leechAction(findSprite())); Destroy(collision.gameObject); }
    }
    public void Destroy()
    {
        if (((Time.time - startTime) > stayTime && transform.position == homeLoc) || health <= 0)
        {
            Destroy(gameObject);
        }
    }
    public void CheckFreeze(bool Freeze, SpriteRenderer sr)
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
        sr.color = arrowteal;
    }
    IEnumerator leechAction(SpriteRenderer sr)
    {
        //health -= 1;
        // change to leech amount
        while (true)
        {
            sr.color = Color.Lerp(arrowteal, leechedpurple, Mathf.PingPong(Time.time * 5, 1.0f));
            health -= 0.01f;
            GameObject pl = GameObject.FindGameObjectWithTag("Player");
            player pla = pl.gameObject.GetComponent<player>();
            pla.health += 0.005f;

            //print(health);
            yield return null;
        }
    }















}
