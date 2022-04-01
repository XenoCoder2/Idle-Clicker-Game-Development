using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OldChumAbility : MonoBehaviour
{
    #region Script Variable
    public CombatManager combatManage;
    #endregion
    #region OldChum Methods
    public void OldChumChange()
    {
        //Increase clickforce by the oldChumCount variable.
        CombatManager.clickForce += CombatManager.oldChumCount;
        //Set the oldChumIncreaseTimer to 20f.
        combatManage.oldChumIncreaseTimer = 20f;
        //Change the player's clickforce text to reflect the increase
        combatManage.pClickforceText.text = "Clickforce: " + CombatManager.clickForce.ToString();
    }

    public void EndChum()
    {
        //Disable the OldChum gameObject.
        gameObject.SetActive(false);
    }
    #endregion

}
