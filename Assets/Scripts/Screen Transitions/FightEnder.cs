using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FightEnder : MonoBehaviour
{
    #region Script Variables
    public GameManager gameManage;
    public CombatManager combatManage;
    public FightTransition fightTransition;
    #endregion
    #region GameObject Variable
    public GameObject flashPanel;
    #endregion
    #region Button Variable
    public Button fishFlipper;
    #endregion

    #region StartTransition Method
    public void StartTransition()
    {
        //Enable the flashPanel.
        flashPanel.SetActive(true);
        //Set the player's healthText to their current health value.
        gameManage.playerHealthText.text = GameManager.playerHealth.ToString() + " / 100";
    }
    #endregion
    #region ResetFightValues Method
    public void ResetFightValues()
    {
        //Set clickFight back to 50.
        CombatManager.clickFight = 50;
        
        //Reset the infoText's text.
        combatManage.infoText.text = "Click anywhere Rapidly to beat the Anomalous Fish!";
        //If the player has an Old Chum upgrade.
        if (CombatManager.oldChumCount >= 1)
        {
            //Reset the oldChumIncreaseTimer to 20f.
            combatManage.oldChumIncreaseTimer = 20f;
        }
        //Set the player's clickforce text to their current clickforce value.
        combatManage.pClickforceText.text = "Clickforce: " + CombatManager.clickForce;
        //Set the enemy's clickforce text to its current clickforce value.
        combatManage.eClickforceText.text = "Clickforce: " + CombatManager.opponentClickForce;
        //Set hasStarted to false.
        combatManage.hasStarted = false;
        //Reset the startCountdown to 3f.
        combatManage.startCountdown = 3f;
        //Enable the countdownText.
        combatManage.countdownText.gameObject.SetActive(true);
        //Set playerWin to false.
        CombatManager.playerWin = false;
    }
    #endregion
    #region ChangeClickValues Method
    public void ChangeClickValues()
    {
        //If the player's health is below or equal to 0.
        if (GameManager.playerHealth <= 0)
        {
            //Set inFight to false.
            FightTransition.inFight = false;
            //Run the GameOver method from the GameManager script.
            gameManage.GameOver();
        }
        //Set newsNumber to a random number from 0-1 (2 is excluded).
        NewsEvents.newsNumber = Random.Range(0, 2);
        //Multiply the spinMax value by twice its current value.
        gameManage.spinMax *= 2;
        //Set fillFlips to 0.
        GameManager.fillFlips = 0;
        //Reset the flipRotate value to a small number.
        Flipper.flipRotate = 0.005f;
        //Run the Fill method from the GameManager script.
        gameManage.Fill();
        //Disable the combatManage gameObject.
        combatManage.gameObject.SetActive(false);
        //Make the fishFlipper button interactable.
        fishFlipper.interactable = true;
        //Run the ResetStart method from the GameManager script
        gameManage.ResetStart();
    }
    #endregion
}
