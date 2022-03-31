using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FightEnder : MonoBehaviour
{
    public GameManager gameManage;
    public CombatManager combatManage;
    public GameObject flashPanel;
    public Button fishFlipper;

    public void StartTransition()
    {
        flashPanel.SetActive(true);
        gameManage.playerHealthText.text = GameManager.playerHealth.ToString() + " / 100";
    }

    public void ResetFightValues()
    {
        CombatManager.clickFight = 50;
        
        combatManage.infoText.text = "Click anywhere Rapidly to beat the Anomalous Fish!";
        if (CombatManager.oldChumCount >= 1)
        {
            combatManage.oldChumIncreaseTimer = 20f;
        }
        combatManage.pClickforceText.text = "Clickforce: " + CombatManager.clickForce;
        combatManage.eClickforceText.text = "Clickforce: " + CombatManager.opponentClickForce;
        combatManage.hasStarted = false;
        combatManage.startCountdown = 3f;
        combatManage.countdownText.gameObject.SetActive(true);
        CombatManager.playerWin = false;
    }

    public void ChangeClickValues()
    {
        if (GameManager.playerHealth <= 0)
        {
            gameManage.GameOver();
        }

        NewsEvents.newsNumber = Random.Range(0, 2);
        gameManage.spinMax *= 2;
        GameManager.fillFlips = 0;
        Flipper.flipRotate = 0.005f;
        gameManage.Fill();
        combatManage.gameObject.SetActive(false);
        fishFlipper.interactable = true;
        gameManage.ResetStart();
    }

}
