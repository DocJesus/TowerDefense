using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    public Color hoverColor;
    public Color notEnoughMoneyColor;

    //la tourelle sur la node en question
    public GameObject turret;
    public Vector3 positionOffset;

    private Color baseColor;
    private Renderer render;

    private BuildManager manager;

    public TurretBlueprint _blueprint;
    public bool isUpgraded = false;

    private void Start()
    {
        manager = BuildManager.instance;
        render = GetComponent<Renderer>();
        baseColor = render.material.color;
    }

    private void Build(TurretBlueprint blueprint)
    {
        if (PlayerStat.money < blueprint.cost)
        {
            Debug.Log("pas assez d'argent pour acheter cela");
            return;
        }

        PlayerStat.money -= blueprint.cost;
        Debug.Log("objet acheter il vous reste " + PlayerStat.money);

        _blueprint = blueprint;

        GameObject effect = (GameObject)Instantiate(manager.spawnParticule, transform.position + positionOffset, Quaternion.identity);
        Destroy(effect, 2f);

        Vector3 y = Vector3.zero;
        if (blueprint.name != "laserbeam")
            y = positionOffset;

        GameObject _turret = (GameObject)Instantiate(blueprint.prefab, transform.position + y, Quaternion.identity);
        turret = _turret;
    }

    //quand on click avec la souris
    private void OnMouseDown()
    {
        //condition pour enpécher la souris de slectionner une tourelle et de construire en meme temps
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        //si il y a déjà une tourelle sur la node on peut pas construire
        //et enregistré la node pour faire des amèlioraton
        if (turret != null)
        {
            Debug.Log("impossible de construire");
            manager.SelectNode(this);
            return;
        }

        if (!manager.canBuild)
            return;

        //construction d'une tourelle
        Build(manager.getTurretToBUild());
    }

    //quand le souris entre en contact 
    private void OnMouseEnter()
    {
        //si notre souris est au dessus d'un game object
        //condition pour enpécher la souris de slectionner une tourelle et de construire en meme temps
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if (!manager.canBuild)
            return;

        //si on a assez de tune on color la case au dessus de laquelle on passe
        if (manager.hasMoney)
            render.material.color = hoverColor;
        else
            render.material.color = notEnoughMoneyColor;
    }

    //quand la souris sors du contact avec l'obj
    private void OnMouseExit()
    {
        render.material.color = baseColor;
    }

    public void SellTurret()
    {
        DestructionEffect();
        PlayerStat.money += _blueprint.sellCost;
    }

    public void SellUpgradedTurret()
    {
        DestructionEffect();
        PlayerStat.money += _blueprint.cost;
    }

    private void DestructionEffect()
    {
        Destroy(turret);
        GameObject effect = (GameObject)Instantiate(manager.spawnParticule, transform.position + positionOffset, Quaternion.identity);
        Destroy(effect, 2f);
    }

    public void UpgradeTurret()
    {
        if (PlayerStat.money < _blueprint.upGradeCost)
        {
            Debug.Log("pas assez d'argent pour acheter cela");
            return;
        }

        PlayerStat.money -= _blueprint.upGradeCost;
        Debug.Log("objet acheter il vous reste " + PlayerStat.money);


        //suppression de l'ancinne tourelle
        DestructionEffect();

        Vector3 y = Vector3.zero;
        if (_blueprint.name != "laserbeam")
            y = positionOffset;

        //création de la nouvelle tourelle
        GameObject _turret = (GameObject)Instantiate(_blueprint.upgradePrefab, transform.position + y, Quaternion.identity);
        turret = _turret;

        isUpgraded = true;
    }

}
