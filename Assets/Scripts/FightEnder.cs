using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightEnder : MonoBehaviour
{
    public GameManager gameManage;
    public CombatManager combatManage;
    public GameObject flashPanel;

    public void StartTransition()
    {
        flashPanel.SetActive(true);
        gameManage.playerHealthText.text = GameManager.playerHealth.ToString() + " / 100";
    }

    

    public void ResetFightValues()
    {
        CombatManager.clickFight = 50;
        if (CombatManager.playerWin)
        {
            combatManage.eAnim.SetBool("Defeated", false);
            combatManage.pAnim.SetBool("IsVictorious", false);
        }
        else
        {
            combatManage.pAnim.SetBool("Defeated", false);
            combatManage.eAnim.SetBool("IsVictorious", false);
        }
        combatManage.infoText.text = "Click anywhere Rapidly to beat the Anomalous Fish!";


        combatManage.pClickforceText.text = "Clickforce: " + CombatManager.clickForce;
        combatManage.eClickforceText.text = "Clickforce: " + CombatManager.opponentClickForce;
        combatManage.hasStarted = false;
        combatManage.startCountdown = 3f;
        combatManage.countdownText.gameObject.SetActive(true);
        CombatManager.playerWin = false;
    }

    public void ChangeClickValues()
    {
        gameManage.spinMax *= 2;
        Flipper.flipRotate = 0.005f;
        gameManage.Fill();
        combatManage.gameObject.SetActive(false);
    }

}
