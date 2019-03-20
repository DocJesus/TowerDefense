using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    public Color hoverColor;
    public Color notEnoughMoneyColor;

    public GameObject turret;
    public Vector3 positionOffset;

    private Color baseColor;
    private Renderer render;

    private BuildManager manager;

    private void Start()
    {
        manager = BuildManager.instance;
        render = GetComponent<Renderer>();
        baseColor = render.material.color;
    }

    //quand on click avec la souris
    private void OnMouseDown()
    {
        //condition pour enpécher la souris de slectionner une tourelle et de construire en meme temps
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if (!manager.canBuild)
            return;

        //si il y a déjà une tourelle sur la node on peut pas construire
        if (turret != null)
        {
            Debug.Log("impossible de construire");
            return;
        }

        //construction d'une tourelle
        manager.BuildTurretOn(this);
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
}
