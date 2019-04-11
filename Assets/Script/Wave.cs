using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//pour que unity le montre la classe dans l'inspec
//attention il n'a pas de monobehavior
[System.Serializable]
public class Wave
{
    public GameObject enemy;
    //le nb d'enemys
    public int count;
    //l'espace entre les enemys
    public float rate;

}
