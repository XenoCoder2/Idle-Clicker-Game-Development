using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseAnimMethods : MonoBehaviour
{
    #region Script Variables
    public FishUpgrade fishUpgrade;
    public GameManager gameManage;
    #endregion

    #region Anchovy Methods
    public void AnchovyIncrease()
    {
        //Increase clickforce by 1.
        CombatManager.clickForce++;
        //Update the clickForceText to reflect this change.
        fishUpgrade.clickForceText.text = CombatManager.clickForce.ToString();
    }

    public void AnchovyDisable()
    {
        //Disable the anchovyArson gameObject.
        gameObject.SetActive(false);
    }
    #endregion
    #region Herring Methods
    public void HerringIncrease()
    {
        //Increase the player's health by the playerHealthRegen value.
        GameManager.playerHealth += GameManager.playerHealthRegen;
        //Update the playerHealthText to reflect this change.
        gameManage.playerHealthText.text = GameManager.playerHealth.ToString() + " / 100";
    }

    public void HerringDisable()
    {
        //Disable the HerringWaterfall gameObject.
        gameObject.SetActive(false);
    }
    #endregion
}
