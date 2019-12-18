using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;
using UnityEngine.UI;

public class player : MonoBehaviour
{ 
    public  static Vector3 PlayerPos, vectorfoo= new Vector3(1,1,1);
    public Transform shipPos,shipF,shipBU,shipBD;
    Vector3 shipFace;
    public float fuel=100, speedM = 2;
    public int health = 100;
    
    

    void Start()
    { 
    }

    void FixedUpdate()
    {
        PlayerPos = transform.position;
        moveTowardsMouse();
        bullet_P.direction = getShipFace();
        if (Time.timeSinceLevelLoad >= 5)
        {
           Camera.main.transform.position = Vector3.MoveTowards(Camera.main.transform.position, transform.position + new Vector3(0, 0, -10), Time.deltaTime * (float)(0.6)); 
        }
   
     
     }
    public Vector2 getShipFace()
    {
        //print(shipPos);
        return new Vector2(shipF.position.x - shipPos.position.x, shipF.position.y - shipPos.position.y);
    }
    void moveTowardsMouse(){
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) + new Vector3(0,0,10);
        //move
         if(Input.GetMouseButton(0)){
             transform.position = 
             Vector3.MoveTowards(transform.position,mousePosition , Time.deltaTime * speedM);
        }
        //rotate
        transform.right =new Vector2(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y); 
    }
    public static void reduceHealth() { }
}