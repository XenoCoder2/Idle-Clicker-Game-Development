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
    public static int playerHealth = 100;
    #endregion
    #region Float Variables
    public static float flipsPerSecond;
    float _flipsPerSecTimer = 1f;
    [Header("Timers")]
    [SerializeField] float _autoFlipTimer = 1f;
    [SerializeField] float _midasFlipTimer = 2f;
    float _startFlip;
    float _endFlip;
    public float spinMax = 5000;
    #endregion
    #region Bool Variables
    bool _initialMidas = false;
    #endregion
    #region Text Variables
    [Header("Text Variables")]
    public Text flipText;
    public Text overallText;
    public Text flipsPerSecondText;
    public Text dangerText;
    public Text playerHealthText;
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
    private Flipper _flipper;
    public FightTransition fightTransition;
    #endregion


    // Start is called before the first frame update
    void Start()
    {
        _flipper = GetComponent<Flipper>();
    }

    // Update is called once per frame
    void Update()
    {
        flipText.text = flips.ToString();
        overallText.text = totalFlips.ToString();

        if (_flipsPerSecTimer >= 0.95f)
        {
            StartCoroutine(FlipsPerSec());
        }
        else if (_flipsPerSecTimer <= 0f)
        {
            _flipsPerSecTimer = 1f;
        }

        _flipsPerSecTimer -= Time.deltaTime;

        if (autoFlips >= 1)
        {
            _autoFlipTimer -= Time.deltaTime;

            if (_autoFlipTimer <= 0)
            {
                StartCoroutine(AutoFlip());
            }
        }

        if (midasFlips >= 1)
        {
            _midasFlipTimer -= Time.deltaTime;

            if (_midasFlipTimer <= 0)
            {
                StartCoroutine(MidasAutoFlips());
            }
        }


    }

    IEnumerator FlipsPerSec()
    {
        _startFlip = totalFlips;

        while (_flipsPerSecTimer > 0)
        {
            flipsPerSecondText.text = flipsPerSecond.ToString();

            yield return null;
        }

        _endFlip = totalFlips;

        flipsPerSecond = _endFlip - _startFlip;

        yield return null;
    }

    IEnumerator AutoFlip()
    {
        flips += autoFlips;
        Fill();
        totalFlips += autoFlips;
        _autoFlipTimer = 1f;
        yield return null;
    }

    IEnumerator MidasAutoFlips()
    {
        flips += midasFlips;
        totalFlips += midasFlips;
        _midasFlipTimer = 2f;
        yield return null;
    }    

    public void Fill()
    {
        fillImage.fillAmount = Mathf.Clamp01(totalFlips / spinMax);
        fillImage.color = fillGradient.Evaluate(fillImage.fillAmount);

        if (totalFlips >= spinMax)
        {
            fightTransition.StartTransition();
        }

    }

    public void MidasUpgrade()
    {
        
        if (!_initialMidas)
        {
            for (int i = 0; i < fishPanels.Length; i++)
            {
                for (int a = 0; a < midasFish.Count; a++)
                {
                    Instantiate(midasFish[a].gameObject, fishPanels[i].transform);
                }
                
            }

            _flipper.MidasFish();
            _initialMidas = true;
            midasFlips += 4;
        }
        else
        {
            midasFlips += 4;
        }
    }

}
