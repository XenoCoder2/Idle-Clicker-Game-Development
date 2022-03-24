using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FishUpgrade : MonoBehaviour
{
    public Text[] upgradeCostText;

    #region Upgrade Costs
    public int[] upgradeCosts;
    #endregion
    public Button[] upgradeButtons;
    public Upgrades fishUpgrade;

    private void Update()
    {
        for (int i = 0; i < upgradeCosts.Length; i++)
        {
            if (GameManager.flips >= upgradeCosts[i])
            {
                upgradeButtons[i].interactable = true;
            }
            else
            {
                upgradeButtons[i].interactable = false;
            }
        }
    }

    public void PurchaseUpgrade()
    {
        switch (fishUpgrade)
        {
            case Upgrades.QuantumFishFlipper:

                if (GameManager.flips >= upgradeCosts[0])
                {
                    GameManager.flips -= upgradeCosts[0];
                    ButtonHandler.flipRate++;

                    upgradeCosts[0] *= 2;
                    upgradeCostText[0].text = "Quantum Fish Flipper - " + upgradeCosts[0] + " Flips";
                }

                break;
            case Upgrades.NanoFlipper:
                if (GameManager.flips >= upgradeCosts[1])
                {
                    GameManager.flips -= upgradeCosts[1];
                    GameManager.autoFlips++; 

                    upgradeCosts[1] *= 2;
                    upgradeCostText[1].text = "NanoFlipper - " + upgradeCosts[1] + " Flips";
                }
                break;
            case Upgrades.BigOlHaul:
                if (GameManager.flips >= upgradeCosts[2])
                {
                    GameManager.flips -= upgradeCosts[2];


                    upgradeCosts[2] *= 2;
                    upgradeCostText[2].text = "Big Ol' Haul - " + upgradeCosts[2] + " Flips";
                }
                break;
            case Upgrades.Codpocalypse:
                if (GameManager.flips >= upgradeCosts[3])
                {
                    GameManager.flips -= upgradeCosts[3];


                    upgradeCosts[3] *= 2;
                    upgradeCostText[3].text = "Big Ol' Haul - " + upgradeCosts[3] + " Flips";
                }
                break;
            case Upgrades.Troutmageddon:
                if (GameManager.flips >= upgradeCosts[4])
                {
                    GameManager.flips -= upgradeCosts[4];


                    upgradeCosts[4] *= 2;
                    upgradeCostText[4].text = "Big Ol' Haul - " + upgradeCosts[4] + " Flips";
                }
                break;
            case Upgrades.SwordfishTsunami:
                if (GameManager.flips >= upgradeCosts[5])
                {
                    GameManager.flips -= upgradeCosts[5];


                    upgradeCosts[5] *= 2;
                    upgradeCostText[5].text = "Big Ol' Haul - " + upgradeCosts[5] + " Flips";
                }
                break;
            case Upgrades.AnchovyArson:
                if (GameManager.flips >= upgradeCosts[6])
                {
                    GameManager.flips -= upgradeCosts[6];


                    upgradeCosts[6] *= 2;
                    upgradeCostText[6].text = "Big Ol' Haul - " + upgradeCosts[6] + " Flips";
                }
                break;
            case Upgrades.HerringWaterfall:
                if (GameManager.flips >= upgradeCosts[7])
                {
                    GameManager.flips -= upgradeCosts[7];


                    upgradeCosts[7] *= 2;
                    upgradeCostText[7].text = "Big Ol' Haul - " + upgradeCosts[7] + " Flips";
                }
                break;
            case Upgrades.SuperheatedClams:
                if (GameManager.flips >= upgradeCosts[8])
                {
                    GameManager.flips -= upgradeCosts[8];


                    upgradeCosts[8] *= 2;
                    upgradeCostText[8].text = "Big Ol' Haul - " + upgradeCosts[8] + " Flips";
                }
                break;
            case Upgrades.TheOldChum:
                if (GameManager.flips >= upgradeCosts[9])
                {
                    GameManager.flips -= upgradeCosts[9];


                    upgradeCosts[9] *= 2;
                    upgradeCostText[9].text = "Big Ol' Haul - " + upgradeCosts[9] + " Flips";
                }
                break;
            default:
                Debug.LogError("No item was selected");
                break;
        }

    }

    public void ChangeState(int buttonValue)
    {
        switch (buttonValue)
        {
            case 0:
                fishUpgrade = Upgrades.QuantumFishFlipper;
            break;
            case 1:
                fishUpgrade = Upgrades.NanoFlipper;
                break;
            case 2:
                fishUpgrade = Upgrades.BigOlHaul;
                break;
            case 3:
                fishUpgrade = Upgrades.Codpocalypse;
                break;
            case 4:
                fishUpgrade = Upgrades.Troutmageddon;
                break;
            case 5:
                fishUpgrade = Upgrades.SwordfishTsunami;
                break;
            case 6:
                fishUpgrade = Upgrades.AnchovyArson;
                break;
            case 7:
                fishUpgrade = Upgrades.HerringWaterfall;
                break;
            case 8:
                fishUpgrade = Upgrades.SuperheatedClams;
                break;
            case 9:
                fishUpgrade = Upgrades.TheOldChum;
                break;
            default:
                break;
        }
    }

}
public enum Upgrades
{
    QuantumFishFlipper,
    NanoFlipper,
    BigOlHaul,
    Codpocalypse,
    Troutmageddon,
    SwordfishTsunami,
    AnchovyArson,
    HerringWaterfall,
    SuperheatedClams,
    TheOldChum
}