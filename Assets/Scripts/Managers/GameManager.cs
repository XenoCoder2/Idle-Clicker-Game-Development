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
    public static int fillFlips;
    #endregion
    #region Float Variables
    public static float flipsPerSecond;
    float _flipsPerSecTimer = 1f;
    [Header("Timers")]
    [SerializeField] float _autoFlipTimer = 1f;
    [SerializeField] float _midasFlipTimer = 2f;
    float _healTimer = 20f;
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
    #region GameObject Variables
    [Header("GameObjects")]
    public GameObject herringWaterfall;
    public GameObject anchovyArson;
    #endregion
    #region Image Variables
    [Header("Spin-O-Meter")]
    public Gradient fillGradient;
    public Image fillImage;
    [Header("Other")]
    public Image midasTrout;
    #endregion
    #region Panel Variables
    [Header("Panels")]
    public GameObject[] fishPanels;
    public List<GameObject> midasFish;
    #endregion
    #region Script Variables
    private Flipper _flipper;
    [Header("Scripts")]
    public FightTransition fightTransition;
    public GameStateManager gameStateManage;
    #endregion

    #region Start Method
    // Start is called before the first frame update
    void Start()
    {
        //Get the flipper component on the gameObject.
        _flipper = GetComponent<Flipper>();
        //Set the newsNumber to 0 to display the first news event.
        NewsEvents.newsNumber = 0;
    }
    #endregion
    #region Update Method
    // Update is called once per frame
    void Update()
    {
        //Set the flipText's text to the current value of flips.
        flipText.text = flips.ToString();
        //Set the overallTexts text to the total amount of flips.
        overallText.text = totalFlips.ToString();
        //If the _flipsPerSectimer is less than or equal to 0.95f..
        if (_flipsPerSecTimer >= 0.95f)
        {
            //Start the FlipsPerSec coroutine.
            StartCoroutine(FlipsPerSec());
        }
        //Else if the _flipsPerSecTimer is less than or equal to 0f.
        else if (_flipsPerSecTimer <= 0f)
        {
            //Set the _flipsPerSecTimer to 1f.
            _flipsPerSecTimer = 1f;

        }

        //Countdown the _flipsPerSecTimer.
        _flipsPerSecTimer -= Time.deltaTime;

        //If the player has an autoFlips upgrade.
        if (autoFlips >= 1)
        {
            //Countdown the _autoFlipTimer.
            _autoFlipTimer -= Time.deltaTime;

            //If the _autoFlipTimer is less than or equal to 0.
            if (_autoFlipTimer <= 0)
            {
                //Start the AutoFlip coroutine.
                StartCoroutine(AutoFlip());
            }
        }

        //If the player has a midasFlips upgrade.
        if (midasFlips >= 1)
        {
            //Countdown the _midasFlipTimer.
            _midasFlipTimer -= Time.deltaTime;

            //If the _midasFlipTimer is less than or equal to 0.
            if (_midasFlipTimer <= 0)
            {
                //Start the MidasAutoFlips coroutine.
                StartCoroutine(MidasAutoFlips());
            }
        }
        //If the player has a HerringWaterfall upgrade.
        if (playerHealthRegen >= 1)
        {
            //Countdown the _healTimer.
            _healTimer -= Time.deltaTime;
           
            //If the _healTimer is less than or equal to 0.
            if (_healTimer <= 0)
            {
                //Start the HealthRegen coroutine.
                StartCoroutine(HealthRegen());
                //Set the _healTimer's value to 20f.
                _healTimer = 20f;
            }
        }

    }
    #endregion
    #region Timer based IEnumerators
    IEnumerator FlipsPerSec()
    {
        //Set the _startFlip to the current totalFlips.
        _startFlip = totalFlips;

        //Whilst the _flipsPerSecTimer is greater than 0.
        while (_flipsPerSecTimer > 0)
        {
            //Set the flipsPerSecond text to flipsPerSecond.
            flipsPerSecondText.text = flipsPerSecond.ToString();

            //Return null.
            yield return null;
        }

        //Set the _endFlip to the totalFlips.
        _endFlip = totalFlips;

        //flipsPerSecond is equal to _endFlip - _startFlip.
        flipsPerSecond = _endFlip - _startFlip;

        //Return Null.
        yield return null;
    }

    IEnumerator AutoFlip()
    {
        //Increase flips by the autoFlips value.
        flips += autoFlips;
        //Increase fillFlips by the autoFlips value.
        fillFlips += autoFlips;
        //Increase totalFlips by the autoFlips value.
        totalFlips += autoFlips;
        //Run the Fill method.
        Fill();
        //Set the _autoFlipTimer to 1f.
        _autoFlipTimer = 1f;
        //Return null.
        yield return null;
    }

    IEnumerator MidasAutoFlips()
    {
        //Increase flips by the midasFlips value.
        flips += midasFlips;
        //Increase fillFlips by the midasFlips value.
        fillFlips += midasFlips;
        //Increase totalFlips by the midasFlips value.
        totalFlips += midasFlips;
        //Run the Fill method.
        Fill();
        //Set the _midasFlipTimer to 2f.
        _midasFlipTimer = 2f;
        //Return null.
        yield return null;
    }    

    IEnumerator HealthRegen()
    {
        //If playerHealth is less than 100.
        if (playerHealth < 100)
        {
            //Activate the herringWaterfall gameObject.
            herringWaterfall.SetActive(true);
        }
        
        //Return null.
        yield return null;
    }
    #endregion
    #region Fill Method
    public void Fill()
    {
        //The fillAmount of fillImage is equal to a clamped 0-1 value that divides fillFlips by the spinMax variable.
        fillImage.fillAmount = Mathf.Clamp01(fillFlips / spinMax);
        //Set the fillImage colour to the evaluation of fillImage.fillAmount.
        fillImage.color = fillGradient.Evaluate(fillImage.fillAmount);

        //Create a new float flipStatement that is equal to fillFlips divided by spinMax and multiplied by 100 before being divided by 10.
        float flipStatement = ((fillFlips / spinMax) * 100) / 10;
        //Create a new int newsStatement that is the rounded int value of flipStatement multiplied by 10.
        int newsStatement = Mathf.RoundToInt(flipStatement) * 10;

        //Switch between the cases of newsStatement.
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
        //If fillFlips is greater than or equal to the spinMax and _startFight is equal to false..
        if (fillFlips >= spinMax && _startFight == false)
        {
            //Run the StartTransition method from the FightTransition script.
            fightTransition.StartTransition();
            //Set _startFight to true.
            _startFight = true;
        }

    }
    #endregion
    #region GameOver and Reset Methods
    public void GameOver()
    {
        //Set the current gameState to GameOver.
        GameStateManager.gameState = GameStates.GameOver;
        //Run the SwitchStates method from the GameStateManager script.
        gameStateManage.SwitchStates();

    }

    public void ResetStart()
    {
        //Set _startFight to false.
        _startFight = false;
    }
    #endregion
    #region MidasUpgrade method
    public void MidasUpgrade()
    {
        //If the Midas Trout upgrade hasn't been initialised yet.
        if (!_initialMidas)
        {
            //For each panel in fishPanels.
            for (int i = 0; i < fishPanels.Length; i++)
            {
                //For each Image in midasFish.
                for (int a = 0; a < midasFish.Count; a++)
                {
                    //Instantiate two midasFish gameObjects in both fishPanels.
                    Instantiate(midasFish[a].gameObject, fishPanels[i].transform);
                }
                
            }

            //Run the MidasFish method in the Flipper script.
            _flipper.MidasFish();
            //Set _initialMidas to true.
            _initialMidas = true;
            //Increase midasFlips by 12.
            midasFlips += 12;
        }
        //Else
        else
        {
            //Increase midasFlips by 12.
            midasFlips += 12;
        }
    }
    #endregion
}
