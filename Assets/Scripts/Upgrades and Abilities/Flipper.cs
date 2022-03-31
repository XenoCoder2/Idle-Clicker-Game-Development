using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Flipper : MonoBehaviour
{
    public GameObject fish;
    public static float flipRotate = 0f;
    private GameManager gameMan;
    public List<Transform> mFish;
    private void Start()
    {
        gameMan = GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        fish.transform.Rotate(0, 0, flipRotate);

        foreach (Transform mTrout in mFish)
        {
            mTrout.Rotate(0, 0, 0.10f);
        }
       
       
    } 

    public void MidasFish()
    {
        for (int i = 0; i < gameMan.fishPanels.Length; i++)
        {
            foreach (Transform midasFish in gameMan.fishPanels[i].GetComponentsInChildren<Transform>())
            {
                if (midasFish.tag == "MidasFish")
                {
                    mFish.Add(midasFish.gameObject.transform);
                }
            }
        }
        


    }

    public void IncreaseFlipRate(float flipIncrease)
    {
        flipRotate += flipIncrease * ButtonHandler.flipRate;
    }

}
