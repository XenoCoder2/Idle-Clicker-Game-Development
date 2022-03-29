using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transition : MonoBehaviour
{
    public GameObject warningPanel;
    public GameObject flashPanel;
    public FightTransition fightTransition;

    public void WarningFinish()
    {
        flashPanel.SetActive(true);
        warningPanel.SetActive(false);
    }

    public void ScreenTransition()
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

    public void FlashFinish()
    {
        flashPanel.SetActive(false);
    }
}
