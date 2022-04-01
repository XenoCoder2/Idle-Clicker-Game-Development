using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FightTransition : MonoBehaviour
{
    #region GameObject Variables
    public GameObject warningPanel;
    public GameObject flashPanel;
    public GameObject combatPanel;
    public GameObject clickerPanel;
    public GameObject combatManager;
    public GameObject clickManager;
    #endregion
    #region Button Variable
    public Button fishFlipper;
    #endregion
    #region Bool Variable
    public static bool inFight = false;
    #endregion

    #region StartTransition Method.
    public void StartTransition()
    {
        //Set the warningPanel to active.
        warningPanel.SetActive(true);
        //Disable the fishFlipper buttons interactivity.
        fishFlipper.interactable = false;
    }
    #endregion
    #region Update Method
    private void Update()
    {
        //If inFight is true and the combatPanel is not active in the hierarchy..
        if(inFight && !combatPanel.activeInHierarchy)
        {
            //Disable the clickManager.
            clickManager.SetActive(false);
            //Activate the combatManager.
            combatManager.SetActive(true);
            //Activate the combatPanel.
            combatPanel.SetActive(true);
            //Disable the clickerPanel.
            clickerPanel.SetActive(false);
        }
        //Else if inFight is false and the clickerPanel is not active in the hierarchy..
        else if(!inFight && !clickerPanel.activeInHierarchy)
        {
            //Disable the combatManager.
            combatManager.SetActive(false);
            //Activate the clickManager.
            clickManager.SetActive(true);
            //Activate the clickerPanel.
            clickerPanel.SetActive(true);
            //Disable the combatPanel.
            combatPanel.SetActive(false);
        }
    }
    #endregion

}
