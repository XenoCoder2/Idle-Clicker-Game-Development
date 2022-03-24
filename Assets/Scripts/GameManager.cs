using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    #region Int Variables
    public static int flips;
    public static int totalFlips;
    public static int autoFlips = 0;
    #endregion
    #region Float Variables
    public static float flipsPerSecond;
    float flipsPerSecTimer = 1f;
    float autoFlipTimer = 1f;
    float startFlip;
    float endFlip;
    #endregion
    #region Text Variables
    [Header("Text Variables")]
    public Text flipText;
    public Text overallText;
    public Text flipsPerSecondText;
    #endregion
   

    // Start is called before the first frame update
    void Start()
    {
  
    }

    // Update is called once per frame
    void Update()
    {
        flipText.text = flips.ToString();
        overallText.text = totalFlips.ToString();

        if (flipsPerSecTimer >= 0.95f)
        {
            StartCoroutine(FlipsPerSec());
        }
        else if (flipsPerSecTimer <= 0f)
        {
            flipsPerSecTimer = 1f;
        }

        flipsPerSecTimer -= Time.deltaTime;

        if (autoFlips >= 1)
        {
            autoFlipTimer -= Time.deltaTime;
            
            if (autoFlipTimer <= 0)
            {
                StartCoroutine(AutoFlip());
            }
        }
        

    }

    IEnumerator FlipsPerSec()
    {
        startFlip = totalFlips;

        while (flipsPerSecTimer > 0)
        {
            flipsPerSecondText.text = flipsPerSecond.ToString();

            yield return null;
        }

        endFlip = totalFlips;

        flipsPerSecond = endFlip - startFlip;

        yield return null;
    }
    
   IEnumerator AutoFlip()
    {
        flips += autoFlips;
        totalFlips += autoFlips;
        autoFlipTimer = 1f;
        yield return null;
    }
    

}
