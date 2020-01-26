using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopMenu : MonoBehaviour
{
    int HS;
    public GameObject[] lockeds;
    private void Update()
    {
        HS = PlayerPrefs.GetInt("HighScore");
        if (HS > 20) { lockeds[0].SetActive(false); }
        if (HS > 30) { lockeds[1].SetActive(false); }
        if (HS > 40) { lockeds[2].SetActive(false); }
    }


    public void shopFreeze()
    {
        if (HS > 20)
        { player.BulletType = 1; }
    }
    public void shopLeech()
    {
        if (HS > 30)
        { player.BulletType = 2; }
    }
    public void shopFollow()
    {
        if (HS > 40)
        { player.BulletType = 3; }
    }
}
