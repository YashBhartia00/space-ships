using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;
using UnityEngine.UI;


public class Ship{
public int health, speedM;
public float fuel,speedR;
public Vector3 shipPos, shipF,shipBU, shipBD,shipFace;
public Ship(int health, float fuel, int speedM,float speedR){
    this.health=health;
    this.fuel = fuel;
    this.speedM = speedM;
    this.speedR = speedR;
    

    // one pixel is 0.01
}

 public bool IsAlive(){
     if( this.health<=0){
         return false;
     }
     else{
         return true;
     }
 }

 public int UpdateShipPos(Vector3 shipPos,Vector3 shipF,Vector3 shipBU,Vector3 shipBD){
    this.shipPos = shipPos;
    this.shipF = shipF;
    this.shipBU = shipBU;
    this.shipBD = shipBD;
    return 0;
 }

public Vector2 getShipFace(){
    //print(this.shipPos);
  return new Vector2(this.shipF.x - this.shipPos.x,this.shipF.y - this.shipPos.y);
}







public int GetHealth(){
 return this.health;
}
public float GetFuel(){
 return this.fuel;
}
public int GetSpeedM(){
 return this.speedM;
}
public Vector3 GetShipPos(){
 return this.shipPos;
}

}
public class Ship_P : MonoBehaviour
{
}
