using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public TurretBlueprint standartTurret;
    public TurretBlueprint missileLauncher;
    public TurretBlueprint laserBeamerTurret;


    BuildManager manager;

    private void Start()
    {
        manager = BuildManager.instance;
    }

    public void SelectStandardTurret()
    {
        manager.SelectTurretToBuild(standartTurret);
    }

    public void SelectMissileTurret()
    {
        manager.SelectTurretToBuild(missileLauncher);
    }

    public void SelectLaserBeamer()
    {
        manager.SelectTurretToBuild(laserBeamerTurret);
    }

}
