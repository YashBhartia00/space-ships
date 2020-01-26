using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{
    Text texty;

    private void Start()
    {
        texty = gameObject.GetComponent<Text>();
        texty.text = "High Score: "+ PlayerPrefs.GetInt("HighScore");

    }
}
