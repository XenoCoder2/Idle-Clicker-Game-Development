using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transition : MonoBehaviour
{
    public GameObject warningPanel;
    public GameObject flashPanel;
    public FightTransition fightTransition;
    public FightEnder fightEnd;
    public CombatManager combatManage;
    public GameManager gameManage;

    public void WarningFinish()
    {
        flashPanel.SetActive(true);
        warningPanel.SetActive(false);
        fightEnd.ResetFightValues();
    }

    public void ScreenTransition()
    {
        if (GameStateManager.gameState != GameStates.GameOver)
        {
            if (!FightTransition.inFight)
            {
                FightTransition.inFight = true;
            }
            else
            {
                FightTransition.inFight = false;
            }
        }
       
    }    

    public void FlashFinish()
    {
        flashPanel.SetActive(false);
        combatManage.eAnim.SetBool("Defeated", false);
        combatManage.pAnim.SetBool("IsVictorious", false);
        combatManage.pAnim.SetBool("Defeated", false);
        combatManage.eAnim.SetBool("IsVictorious", false);
    }
}
