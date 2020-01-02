using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particleEffects : MonoBehaviour
{
    float a;
    void Start()
    {
        a = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time - a > 3)
        {
            Destroy(gameObject);
        }
    }
}
