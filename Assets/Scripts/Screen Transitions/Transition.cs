using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transition : MonoBehaviour
{
    #region GameObject Variables
    public GameObject warningPanel;
    public GameObject flashPanel;
    #endregion
    #region Script Variables
    public FightTransition fightTransition;
    public FightEnder fightEnd;
    public CombatManager combatManage;
    public GameManager gameManage;
    #endregion

    #region WarningFinish Method
    public void WarningFinish()
    {
        //Enable the flashPanel.
        flashPanel.SetActive(true);
        //Disable the warningPanel.
        warningPanel.SetActive(false);
        //Run the ResetFightValues method from the FightEnder Script.
        fightEnd.ResetFightValues();
    }
    #endregion
    #region ScreenTransition Method
    public void ScreenTransition()
    {
        //If the gameState is not equal to GameOver.
        if (GameStateManager.gameState != GameStates.GameOver)
        {
            //If inFight is false.
            if (!FightTransition.inFight)
            {
                //Create a new int that is a range from 0 to the max length of the enemyFishSprites array.
                int enemyType = Random.Range(0, combatManage.enemyFishSprites.Length);
                //Set the sprite of the enemyFish to the sprite associated with the number picked in enemyType.
                combatManage.enemyFish.sprite = combatManage.enemyFishSprites[enemyType];
                //Set the name of the fish to the associated enemyName.
                combatManage.enemyFishName.text = combatManage.enemyNames[enemyType];
                //Set inFight to true.
                FightTransition.inFight = true;
            }
            //Else
            else
            {
                //Set inFight to false.
                FightTransition.inFight = false;
            }
        }
       
    }
    #endregion
    #region FlashFinish
    public void FlashFinish()
    {
        //Disable the flashPanel.
        flashPanel.SetActive(false);
        //Reset the bool values for the player and enemy animators.
        combatManage.eAnim.SetBool("Defeated", false);
        combatManage.pAnim.SetBool("IsVictorious", false);
        combatManage.pAnim.SetBool("Defeated", false);
        combatManage.eAnim.SetBool("IsVictorious", false);
    }
    #endregion
}
