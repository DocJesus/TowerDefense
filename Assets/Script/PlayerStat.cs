using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStat : MonoBehaviour
{
    public static int money;
    public int startMoney = 40;

    public static int lives;
    public int startlives;

    private void Start()
    {
        money = startMoney;
        lives = startlives;
    }

}
