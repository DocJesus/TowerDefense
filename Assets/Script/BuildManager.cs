using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    private TurretBlueprint turretToBuild;

    public bool canBuild
    {
        get { return turretToBuild != null; }
    }

    public void SelectTurretToBuild(TurretBlueprint _turret)
    {
        turretToBuild = _turret;
    }

    public void BuildTurretOn(Node node)
    {

        //si le joueur a moins d'argent que le cout de la tourelle
        if (PlayerStat.money < turretToBuild.cost)
        {
            Debug.Log("pas assez d'argent pour acheter cela");
            return;
        }

        PlayerStat.money -= turretToBuild.cost;
        Debug.Log("objet acheter il vous reste " + PlayerStat.money);

        GameObject turret = (GameObject)Instantiate(turretToBuild.prefab, node.transform.position + node.positionOffset, Quaternion.identity);
        node.turret = turret;
    }

    #region singletone
    //singletone
    public static BuildManager instance;
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("double manager");
            return;
        }
        instance = this;
    }
    #endregion
}
