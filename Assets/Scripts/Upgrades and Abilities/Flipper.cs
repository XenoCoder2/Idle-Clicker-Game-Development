using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Flipper : MonoBehaviour
{
    #region GameObject Variable
    public GameObject fish;
    #endregion
    #region Float Variable
    public static float flipRotate = 0f;
    #endregion
    #region Script Variable
    private GameManager gameMan;
    #endregion
    #region List of Transforms 
    public List<Transform> mFish;
    #endregion

    #region Start Method
    private void Start()
    {
        //Get the GameManager component.
        gameMan = GetComponent<GameManager>();
    }
    #endregion
    #region Update Method
    // Update is called once per frame
    void Update()
    {
        //Rotate the fish by flipRotate.
        fish.transform.Rotate(0, 0, flipRotate);

        //foreach transform in mFish
        foreach (Transform mTrout in mFish)
        {
            //Rotate the Midas Trout by 0.10f.
            mTrout.Rotate(0, 0, 0.10f);
        }
       
       
    }
    #endregion
    #region MidasFish Method
    public void MidasFish()
    {
        //For each value of fishPanels.length.
        for (int i = 0; i < gameMan.fishPanels.Length; i++)
        {
            //Foreach transform in fishPanels child transform components.
            foreach (Transform midasFish in gameMan.fishPanels[i].GetComponentsInChildren<Transform>())
            {
                //If the tag is MidasFish
                if (midasFish.CompareTag("MidasFish"))
                {
                    //Add the transform to the mFish list.
                    mFish.Add(midasFish.gameObject.transform);
                }
            }
        }
        


    }
    #endregion
    #region IncreaseFlipRate Method
    public void IncreaseFlipRate(float flipIncrease)
    {
        //Increase flipRotate by the flipIncrease multiplied by the flipRate
        flipRotate += flipIncrease * ButtonHandler.flipRate;
    }
    #endregion
}
