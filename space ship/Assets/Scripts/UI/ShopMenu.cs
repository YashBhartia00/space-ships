using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopMenu : MonoBehaviour
{
    public void shopFreeze()
    {
        player.BulletType = 1;
    }
    public void shopLeech()
    {
        player.BulletType = 2;
    }
    public void shopFollow()
    {
        player.BulletType = 3;
    }
}
