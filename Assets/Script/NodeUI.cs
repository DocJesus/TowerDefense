using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NodeUI : MonoBehaviour {

    private Node target;
    public GameObject UI;
    public Text textCost;
    public Button upgradeButton;
    public Text textSell;

    public void SetTarget(Node _target)
    {
        target = _target;

        transform.position = target.transform.position + target.positionOffset;

        if (!target.isUpgraded)
        {
            textCost.text = "-" + _target._blueprint.upGradeCost + "$";
            upgradeButton.interactable = true;
            textSell.text = "+" + _target._blueprint.sellCost + "$";
        }
        else
        {
            textCost.text = "Max";
            upgradeButton.interactable = false;

            //on vend la tourelle upgrade au meme prix que la construction de tourelle de base
            textSell.text = "+" + _target._blueprint.cost + "$";
        }
        UI.SetActive(true);
    }

    public void Hide()
    {
        UI.SetActive(false);
    }

    public void UpgradeTurret()
    {
        target.UpgradeTurret();
        BuildManager.instance.DeselectNode();
    }

    public void Sell()
    {
        Debug.Log("vendez tout");
        if (!target.isUpgraded)
            target.SellTurret();
        else
            target.SellUpgradedTurret();
        Hide();
        target.isUpgraded = false;
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
