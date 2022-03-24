using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Flipper : MonoBehaviour
{
    public GameObject fish;
    public static float flipRotate = 0f;

    // Update is called once per frame
    void Update()
    {
        fish.transform.Rotate(0, 0, flipRotate);
       
    } 

    public void IncreaseFlipRate(float flipIncrease)
    {
        flipRotate += flipIncrease * ButtonHandler.flipRate;
    }

}
