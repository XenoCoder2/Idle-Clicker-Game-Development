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
    public static int midasFlips = 0;
    #endregion
    #region Float Variables
    public static float flipsPerSecond;
    float flipsPerSecTimer = 1f;
    [Header("Timers")]
    [SerializeField] float autoFlipTimer = 1f;
    [SerializeField] float midasFlipTimer = 2f;
    float startFlip;
    float endFlip;
    float spinMax = 5000;
    #endregion
    #region Bool Variables
    bool initialMidas = false;
    #endregion
    #region Text Variables
    [Header("Text Variables")]
    public Text flipText;
    public Text overallText;
    public Text flipsPerSecondText;
    public Text dangerText; 
    #endregion
    #region Image Variables
    [Header("Spin-O-Meter")]
    public Gradient fillGradient;
    public Image fillImage;
    [Header("Other")]
    public Image midasTrout;
    #endregion
    #region Panel Variables
    public GameObject[] fishPanels;
    public List<GameObject> midasFish;
    #endregion
    #region Script Variables
    private Flipper flipper;
    #endregion


    // Start is called before the first frame update
    void Start()
    {
        flipper = GetComponent<Flipper>();
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

        if (midasFlips >= 1)
        {
            midasFlipTimer -= Time.deltaTime;

            if (midasFlipTimer <= 0)
            {
                StartCoroutine(MidasAutoFlips());
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
        Fill();
        totalFlips += autoFlips;
        autoFlipTimer = 1f;
        yield return null;
    }

    IEnumerator MidasAutoFlips()
    {
        flips += midasFlips;
        totalFlips += midasFlips;
        midasFlipTimer = 2f;
        yield return null;
    }    

    public void Fill()
    {
        fillImage.fillAmount = Mathf.Clamp01(totalFlips / spinMax);
        fillImage.color = fillGradient.Evaluate(fillImage.fillAmount);
    }

    public void MidasUpgrade()
    {
        
        if (!initialMidas)
        {
            for (int i = 0; i < fishPanels.Length; i++)
            {
                for (int a = 0; a < midasFish.Count; a++)
                {
                    Instantiate(midasFish[a].gameObject, fishPanels[i].transform);
                }
                
            }

            flipper.MidasFish();
            initialMidas = true;
            midasFlips += 4;
        }
        else
        {
            midasFlips += 4;
        }
    }

}
