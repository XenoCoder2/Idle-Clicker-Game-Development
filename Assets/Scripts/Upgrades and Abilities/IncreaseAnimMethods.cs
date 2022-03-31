using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseAnimMethods : MonoBehaviour
{
    public FishUpgrade fishUpgrade;
    public GameManager gameManage;

    public void AnchovyIncrease()
    {
        CombatManager.clickForce += fishUpgrade.ownership[2];
        fishUpgrade.clickForceText.text = CombatManager.clickForce.ToString();
    }

    public void AnchovyDisable()
    {
        gameObject.SetActive(false);
    }

    public void HerringIncrease()
    {
        GameManager.playerHealth += GameManager.playerHealthRegen;
        gameManage.playerHealthText.text = GameManager.playerHealth.ToString() + " / 100";
    }

    public void HerringDisable()
    {
        gameObject.SetActive(false);
    }
}
