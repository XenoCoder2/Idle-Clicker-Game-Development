using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FishUpgrade : MonoBehaviour
{
    public Text[] upgradeCostText;
    public Text[] ownershipText;
    private int[] _ownership = new int[5];
    public GameManager gameManage;
    #region Upgrade Costs
    public int[] upgradeCosts;
    #endregion
    public Text clickForceText;
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

                    int ownerShip = ButtonHandler.flipRate - 1;
                    ownershipText[0].text = "Owned: " + ownerShip.ToString();
                    upgradeCostText[0].text = "Quantum Fish Flipper - " + upgradeCosts[0] + " Flips";
                }

                break;
            case Upgrades.NanoFlipper:
                if (GameManager.flips >= upgradeCosts[1])
                {
                    GameManager.flips -= upgradeCosts[1];
                    GameManager.autoFlips += 2;
                    _ownership[0]++;

                    ownershipText[1].text = "Owned: " + _ownership[0].ToString();
                    upgradeCosts[1] *= 2;
                    upgradeCostText[1].text = "NanoFlipper - " + upgradeCosts[1] + " Flips";
                }
                break;
            case Upgrades.MidasTrout:
                if (GameManager.flips >= upgradeCosts[2])
                {
                    GameManager.flips -= upgradeCosts[2];
                    gameManage.MidasUpgrade();
                    _ownership[1]++;

                    ownershipText[2].text = "Owned: " + _ownership[1].ToString();
                    upgradeCosts[2] *= 2;
                    upgradeCostText[2].text = "Midas Trout - " + upgradeCosts[2] + " Flips";
                }
                break;
            case Upgrades.AnchovyArson:
                if (GameManager.flips >= upgradeCosts[3])
                {
                    GameManager.flips -= upgradeCosts[3];
                    CombatManager.clickForce++;
                    _ownership[2]++;

                    clickForceText.text = CombatManager.clickForce.ToString();

                    ownershipText[3].text = "Owned: " + _ownership[2].ToString();

                    upgradeCosts[3] *= 2;
                    upgradeCostText[3].text = "Anchovy Arson - " + upgradeCosts[3] + " Flips";
                }
                break;
            case Upgrades.HerringWaterfall:
                if (GameManager.flips >= upgradeCosts[4])
                {
                    GameManager.flips -= upgradeCosts[4];
                    GameManager.playerHealthRegen++;
                    _ownership[3]++;

                    ownershipText[4].text = "Owned: " + _ownership[3].ToString();

                    upgradeCosts[4] *= 2;
                    upgradeCostText[4].text = "Herring Waterfall - " + upgradeCosts[4] + " Flips";
                }
                break;
            case Upgrades.TheOldChum:
                if (GameManager.flips >= upgradeCosts[5])
                {
                    GameManager.flips -= upgradeCosts[5];
                    CombatManager.oldChumCount++;
                    _ownership[4]++;

                    ownershipText[5].text = "Owned: " + _ownership[4].ToString();


                    upgradeCosts[5] *= 2;
                    upgradeCostText[5].text = "The Old Chum - " + upgradeCosts[5] + " Flips";
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
                fishUpgrade = Upgrades.MidasTrout;
                break;
            case 3:
                fishUpgrade = Upgrades.AnchovyArson;
                break;
            case 4:
                fishUpgrade = Upgrades.HerringWaterfall;
                break;
            case 5:
                fishUpgrade = Upgrades.TheOldChum;
                break;
        }
    }

}
public enum Upgrades
{
    QuantumFishFlipper,
    NanoFlipper,
    MidasTrout,
    AnchovyArson,
    HerringWaterfall,
    TheOldChum
}