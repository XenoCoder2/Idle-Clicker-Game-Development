using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FightTransition : MonoBehaviour
{
    public GameObject warningPanel;
    public Button fishFlipper;
    public GameObject flashPanel;
    public GameObject combatPanel;
    public GameObject clickerPanel;
    public GameObject combatManager;
    public GameObject clickManager;
    public static bool inFight = false;

    public void StartTransition()
    {
        warningPanel.SetActive(true);
        fishFlipper.interactable = false;
    }

    private void Update()
    {
        if(inFight && !combatPanel.activeInHierarchy)
        {
            clickManager.SetActive(false);
            combatManager.SetActive(true);
            combatPanel.SetActive(true);
            clickerPanel.SetActive(false);
        }
        else if(!inFight && !clickerPanel.activeInHierarchy)
        {
            combatManager.SetActive(false);
            clickManager.SetActive(true);
            clickerPanel.SetActive(true);
            combatPanel.SetActive(false);
        }
    }


}
