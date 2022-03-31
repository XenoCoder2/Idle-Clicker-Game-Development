using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OldChumAbility : MonoBehaviour
{
    public CombatManager combatManage;

    public void OldChumChange()
    {
        CombatManager.clickForce += CombatManager.oldChumCount;
        combatManage.oldChumIncreaseTimer = 20f;
        combatManage.pClickforceText.text = "Clickforce: " + CombatManager.clickForce.ToString();
    }

    public void EndChum()
    {
        gameObject.SetActive(false);
    }


}
