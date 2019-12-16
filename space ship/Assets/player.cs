using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;
using UnityEngine.UI;


public class player : MonoBehaviour
{ 
    public  static Vector3 vectorfoo= new Vector3(1,1,1);
    public Transform shipPos,shipF,shipBU,shipBD;
    Ship barry=new Ship(1,1,1,1);
    
    void Start()
    { 
        Ship barry = new Ship(100,100,1000,2);
        print(barry.GetHealth()+" "+barry.GetFuel()+" "+barry.GetSpeedM());
    }

    void Update()
    {
        moveTowardsMouse();
        barry.UpdateShipPos( shipPos.position,shipF.position,shipBU.position, shipBD.position);
        bullet_P.direction = barry.getShipFace();
        if (Time.timeSinceLevelLoad >= 5)
        {
           // Camera.main.transform.position = Vector3.MoveTowards(Camera.main.transform.position, transform.position + new Vector3(0, 0, -10), Time.deltaTime * (float)(0.6)); 
        }
        print(barry.getShipFace());

     
     }
    void moveTowardsMouse(){
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) + new Vector3(0,0,10);
        //move
         if(Input.GetMouseButton(0)){
             transform.position = 
             Vector3.MoveTowards(transform.position,mousePosition , Time.deltaTime * (float)barry.GetSpeedM());
        }
        //rotate
        transform.right =new Vector2(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y); 
    }
}