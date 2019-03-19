using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStat : MonoBehaviour
{
    public static int money;
    public int startMoney = 40;

    private void Start()
    {
        money = startMoney;
    }

}
