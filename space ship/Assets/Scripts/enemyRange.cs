using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemyRange : MonoBehaviour
{
    Vector3 homeLoc;
    public float startTime,prog,stayTime = 1500, speed = 1f, DPS = 3.5f, health = 3, timeBeforeAttack = 2;
    float dirx, diry;
    Color freezeblue, arrowteal, chargedgreen, leechedpurple;
    bool attacking,frozen, freeze;
    Rigidbody2D rb;
    Vector2 direction;
    public int hitNums = 5;

    public score score;


    public Transform spawnPoints;
    public GameObject blockPreFab, deatheffect;
    float a, timeTillNextBullet, bulletRate = 0.2f;
    //bulletRate lower means faster bullets

    void Start()
    {
        
        ColorUtility.TryParseHtmlString("#50B7D1", out freezeblue);
        ColorUtility.TryParseHtmlString("#AB799F", out leechedpurple);
        ColorUtility.TryParseHtmlString("#00FFDF", out arrowteal);
        ColorUtility.TryParseHtmlString("#3FD266", out chargedgreen);

        score = GameObject.FindGameObjectsWithTag("Score")[0].GetComponent<score>();
        

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
        
        dirx = direction.x / Vector2.SqrMagnitude(direction);
        diry = direction.y / Vector2.SqrMagnitude(direction);
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




    //from the other enemy & no modifications ake another script PLEASE
    public SpriteRenderer findSprite()
    {
        return gameObject.GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player") { hitNums -= 1; if (hitNums <= 0) { Destroy(gameObject); score.scoreNum += 1; } }
        else if (collision.gameObject.tag == "Freeze") { freeze = true; health -= 2; Destroy(collision.gameObject); }
        else if (collision.gameObject.tag == "Leech") { StartCoroutine(leechAction(findSprite())); Destroy(collision.gameObject); }
        else if (collision.gameObject.tag == "Enemy") { }
        else { health -= 1; Destroy(collision.gameObject); }
    }

    private void OnDestroy()
    {
        Instantiate(deatheffect, transform.position, Quaternion.identity);
        
    }
    public void Destroy()
    {
        if (((Time.time - startTime) > stayTime) || health <= 0)
        {
            if (health <= 0) { score.scoreNum += 2; }
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
            health -= 0.005f;
            GameObject pl = GameObject.FindGameObjectWithTag("Player");
            player pla = pl.gameObject.GetComponent<player>();
            pla.health += 0.005f;

            //print(health);
            yield return null;
        }
    }

















}
