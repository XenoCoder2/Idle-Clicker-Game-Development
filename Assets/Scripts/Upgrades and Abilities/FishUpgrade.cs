using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FishUpgrade : MonoBehaviour
{
    #region Text Variables
    [Header("Text")]
    public Text[] upgradeCostText;
    public Text[] ownershipText;
    public Text clickForceText;
    #endregion
    #region Int Variables
    [Header("Ownership int array")]
    public int[] ownership = new int[5];
    public int[] upgradeCosts;
    #endregion
    #region Script Variables
    public GameManager gameManage;
    #endregion
    #region Button Variables
    public Button[] upgradeButtons;
    #endregion
    #region GameObject Variables
    public GameObject anchovyArson;
    public GameObject nanoFlipper;
    #endregion
    #region Upgrades Variable
    public Upgrades fishUpgrade;
    #endregion

    #region Update
    private void Update()
    {
        //For every value of the upgradeCosts array.
        for (int i = 0; i < upgradeCosts.Length; i++)
        {
            //If flips is greater than its upgradeCost.
            if (GameManager.flips >= upgradeCosts[i])
            {
                //Enable the upgradeButtons interactivity.
                upgradeButtons[i].interactable = true;
            }
            //Else 
            else
            {
                //Disable the upgradeButtons interactivity.
                upgradeButtons[i].interactable = false;
            }
        }
    }
    #endregion
    #region PurchaseUpgrade Method
    public void PurchaseUpgrade()
    {
        //Switch between the fishUpgrade Upgrades enum.
        switch (fishUpgrade)
        {
            case Upgrades.QuantumFishFlipper:

                //If flips is greater than the upgrade cost.
                if (GameManager.flips >= upgradeCosts[0])
                {
                    //Take away the upgrade cost from flips.
                    GameManager.flips -= upgradeCosts[0];
                    //Increase the flip rate by 1.
                    ButtonHandler.flipRate++;
                    //Multiply the upgrade cost by 2.
                    upgradeCosts[0] *= 2;
                    //Create a bew int ownerShip that is equal to the flipRate - 1 (Which will equal the amount owned)
                    int ownerShip = ButtonHandler.flipRate - 1;
                    //Set the ownershipText to the ownerShip value.
                    ownershipText[0].text = "Owned: " + ownerShip.ToString();
                    //Show the increase in cost by setting the upgradeCostText to the new value.
                    upgradeCostText[0].text = "Quantum Fish Flipper - " + upgradeCosts[0] + " Flips";
                }

                break;
            case Upgrades.NanoFlipper:
                //If flips is greater than the upgrade cost.
                if (GameManager.flips >= upgradeCosts[1])
                {
                    //Take away the upgrade cost from flips.
                    GameManager.flips -= upgradeCosts[1];
                    //Increase autoFlips by 2.
                    GameManager.autoFlips += 2;
                    //Increase the appropriate ownership int value by 1.
                    ownership[0]++;
                    //Activate the nanoFlipper gameObject.
                    nanoFlipper.SetActive(true);
                    //Set the ownershipText to the ownerShip value.
                    ownershipText[1].text = "Owned: " + ownership[0].ToString();
                    //Multiply the upgrade cost by 2.
                    upgradeCosts[1] *= 2;
                    //Show the increase in cost by setting the upgradeCostText to the new value.
                    upgradeCostText[1].text = "NanoFlipper - " + upgradeCosts[1] + " Flips";
                }
                break;
            case Upgrades.MidasTrout:
                //If flips is greater than the upgrade cost.
                if (GameManager.flips >= upgradeCosts[2])
                {
                    //Take away the upgrade cost from flips.
                    GameManager.flips -= upgradeCosts[2];
                    //Run the MidasUpgrade method from the GameManager script.
                    gameManage.MidasUpgrade();
                    //Increase the appropriate ownership int value by 1.
                    ownership[1]++;
                    //Set the ownershipText to the ownerShip value.
                    ownershipText[2].text = "Owned: " + ownership[1].ToString();
                    //Multiply the upgrade cost by 2.
                    upgradeCosts[2] *= 2;
                    //Show the increase in cost by setting the upgradeCostText to the new value.
                    upgradeCostText[2].text = "Midas Trout - " + upgradeCosts[2] + " Flips";
                }
                break;
            case Upgrades.AnchovyArson:
                //If flips is greater than the upgrade cost.
                if (GameManager.flips >= upgradeCosts[3])
                {
                    //Take away the upgrade cost from flips.
                    GameManager.flips -= upgradeCosts[3];
                    //Increase the appropriate ownership int value by 1.
                    ownership[2]++;
                    //Activate the anchovyArson gameObject.
                    anchovyArson.SetActive(true);

                    //Set the ownershipText to the ownerShip value.
                    ownershipText[3].text = "Owned: " + ownership[2].ToString();
                    //Multiply the upgrade cost by 2.
                    upgradeCosts[3] *= 2;
                    //Show the increase in cost by setting the upgradeCostText to the new value.
                    upgradeCostText[3].text = "Anchovy Arson - " + upgradeCosts[3] + " Flips";
                }
                break;
            case Upgrades.HerringWaterfall:
                //If flips is greater than the upgrade cost.
                if (GameManager.flips >= upgradeCosts[4])
                {
                    //Take away the upgrade cost from flips.
                    GameManager.flips -= upgradeCosts[4];
                    //Increase playerHealthRegen by 1.
                    GameManager.playerHealthRegen++;
                    //Increase the appropriate ownership int value by 1.
                    ownership[3]++;
                    //Set the ownershipText to the ownerShip value.
                    ownershipText[4].text = "Owned: " + ownership[3].ToString();
                    //Multiply the upgrade cost by 2.
                    upgradeCosts[4] *= 2;
                    //Show the increase in cost by setting the upgradeCostText to the new value.
                    upgradeCostText[4].text = "Herring Waterfall - " + upgradeCosts[4] + " Flips";
                }
                break;
            case Upgrades.TheOldChum:
                //If flips is greater than the upgrade cost.
                if (GameManager.flips >= upgradeCosts[5])
                {
                    //Take away the upgrade cost from flips.
                    GameManager.flips -= upgradeCosts[5];
                    //Increase oldChumCount by 1.
                    CombatManager.oldChumCount++;
                    //Increase the appropriate ownership int value by 1.
                    ownership[4]++;
                    //Set the ownershipText to the ownerShip value.
                    ownershipText[5].text = "Owned: " + ownership[4].ToString();
                    //Multiply the upgrade cost by 2.
                    upgradeCosts[5] *= 2;
                    //Show the increase in cost by setting the upgradeCostText to the new value.
                    upgradeCostText[5].text = "The Old Chum - " + upgradeCosts[5] + " Flips";
                }
                break;
            default:
                //Log an error.
                Debug.LogError("No item was selected");
                break;
        }
       
    }
    #endregion

    #region ChangeState Method
    public void ChangeState(int buttonValue)
    {
        //Switch between the buttonValues.
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
    #endregion

}
//An Enum for the Upgrades available in the game.
public enum Upgrades
{
    QuantumFishFlipper,
    NanoFlipper,
    MidasTrout,
    AnchovyArson,
    HerringWaterfall,
    TheOldChum
}