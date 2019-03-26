using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    private TurretBlueprint turretToBuild;
    public GameObject spawnParticule;
    private Node selectedNode;

    public NodeUI nodeUI;

    public bool canBuild
    {
        get { return turretToBuild != null; }
    }

    public bool hasMoney
    {
        get { return PlayerStat.money >= turretToBuild.cost; }
    }

    public void SelectTurretToBuild(TurretBlueprint _turret)
    {
        turretToBuild = _turret;
        DeselectNode();
    }

    public void SelectNode(Node _node)
    {
        turretToBuild = null;
        if (_node == selectedNode)
        {
            DeselectNode();
            return;
        }

        selectedNode = _node;
        nodeUI.SetTarget(_node);
    }

    public TurretBlueprint getTurretToBUild()
    {
        return turretToBuild;
    }

    public void DeselectNode()
    {
        selectedNode = null;
        nodeUI.Hide();
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
