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
    public static int playerHealthRegen = 0;
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
    bool _startFight = false;
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

            if (playerHealthRegen >= 1)
            {
                StartCoroutine(HealthRegen());
            }
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

    IEnumerator HealthRegen()
    {
        if (playerHealth < 100)
        {
            playerHealth += playerHealthRegen;
            playerHealthText.text = playerHealth.ToString() + " / 100";
        }
        
        yield return null;
    }

    public void Fill()
    {
        
        fillImage.fillAmount = Mathf.Clamp01(totalFlips / spinMax);
        fillImage.color = fillGradient.Evaluate(fillImage.fillAmount);

        float flipStatement = ((totalFlips / spinMax) * 100) / 10;
        int newsStatement = Mathf.RoundToInt(flipStatement) * 10;

        switch (newsStatement)
        {
            case 0:
                NewsEvents.news = NewsStates.Calm;
                break;
            case 10:
                NewsEvents.news = NewsStates.Curious;
                break;
            case 20:
                NewsEvents.news = NewsStates.RandomFact1;
                break;
            case 30:
                NewsEvents.news = NewsStates.Scientific;
                break;
            case 40:
                NewsEvents.news = NewsStates.Foreboding;
                break;
            case 50:
                NewsEvents.news = NewsStates.WeatherReport;
                break;
            case 60:
                NewsEvents.news = NewsStates.RandomFact2;
                break;
            case 70:
                NewsEvents.news = NewsStates.Fishy;
                break;
            case 80:
                NewsEvents.news = NewsStates.Fishmageddon;
                break;
            case 90:
                NewsEvents.news = NewsStates.ItHasEmerged;
                break;
            default:
                break;
        }

        if (totalFlips >= spinMax && _startFight == false)
        {
            fightTransition.StartTransition();
            _startFight = true;
        }

    }

    public void resetStart()
    {
        _startFight = false;
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
            midasFlips += 12;
        }
        else
        {
            midasFlips += 4;
        }
    }

}
