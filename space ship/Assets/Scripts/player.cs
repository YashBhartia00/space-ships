using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class player : MonoBehaviour
{ 
    public  static Vector3 PlayerPos, vectorfoo= new Vector3(1,1,1);
    public Transform shipPos,shipF,shipBU,shipBD;
    Vector3 shipFace;
    public float fuel=100, speedM = 2;
    public float health = 100;
    public GameObject healthBar,deatheffect;
    public Joystick movestick,rotatestick;
    public static int BulletType=0;   //{"Normal", "Freeze", "Leech","Follow" }


    void Start()
    {
        //joystick = FindObjectOfType<Joystick>();
    }

    void FixedUpdate()
    {
        PlayerPos = transform.position;
        moveJoystick();
        bullet_P.direction = getShipFace();

        Camera.main.transform.position = transform.position + new Vector3(0, 0, -10);
        reduceHealth();
     
     }
    public Vector2 getShipFace()
    {
        //print(shipPos);
        return new Vector2(shipF.position.x - shipPos.position.x, shipF.position.y - shipPos.position.y);
    }

    void moveJoystick()
    {
        var rigidbody = GetComponent<Rigidbody2D>();
        rigidbody.velocity = new Vector3(movestick.Horizontal * speedM, movestick.Vertical * speedM, 0);
        //print(movestick.Horizontal + " " + movestick.Vertical);
        transform.up = new Vector2(rotatestick.Horizontal,rotatestick.Vertical);
    }
    public void reduceHealth() {
        healthBar.transform.localScale = new Vector3 (health * 0.01f,1,1);
        healthBar.transform.localPosition = new Vector3(-50+health*0.5f, 0, 0);
        if (health <= 0)
        {
            Time.timeScale = 0.1f;
            StartCoroutine(restart());
            deatheffect.SetActive(true);
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            foreach (Transform child in transform)
            {
                if (child.gameObject.tag != "Effect")
                {
                    GameObject.Destroy(child.gameObject);
                }
            }
        }
    }
   /* private void OnDestroy()
    {
        //Instantiate(deatheffect, transform.position, Quaternion.identity);
        
        StartCoroutine(restart());
        //SceneManager.LoadScene("StartScreen");
    }*/


    IEnumerator restart()
    {
        yield return new WaitForSeconds(0.15f);
        SceneManager.LoadScene("StartScreen");
        Time.timeScale = 1f;
    }
}
