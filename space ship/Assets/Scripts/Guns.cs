using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guns : MonoBehaviour
{
    public Sprite[] guns = new Sprite[4];
    void Start()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = guns[0];
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = guns[player.BulletType];
    }
}
