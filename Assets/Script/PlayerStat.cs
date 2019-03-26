using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStat : MonoBehaviour
{
    public static int money;
    public int startMoney = 40;

    public static int lives;
    public int startlives;

    public static int rounds;

    private void Start()
    {
        money = startMoney;
        lives = startlives;
        rounds = 0;
    }

}
