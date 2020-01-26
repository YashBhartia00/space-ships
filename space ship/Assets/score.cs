using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class score : MonoBehaviour
{
    public static int scoreNum;
    Text text;

    private void Start()
    {
        text = gameObject.GetComponent<Text>();
    }
    private void Update()
    {
        
        text.text = "Score: " + scoreNum;


        if (PlayerPrefs.GetInt("HighScore") < scoreNum)
        {
            PlayerPrefs.SetInt("HighScore", scoreNum);
        }
    }
}
