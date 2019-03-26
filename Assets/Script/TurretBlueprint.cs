
using UnityEngine;

//permet de dire qu'il fat afficher la classe dans l'inspector
[System.Serializable]
public class TurretBlueprint
{
    public string name;
    public GameObject prefab;
    public GameObject upgradePrefab;
    public int cost;
    public int upGradeCost;
    public int sellCost;
}
