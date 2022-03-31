using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CombatManager : MonoBehaviour
{
    #region Variables
    public static int clickForce = 1;
    public static int opponentClickForce = 1;
    public static bool playerWin;
    public static int oldChumCount = 0;
    public int basePlayerClickForce;
    [SerializeField] public static int clickFight = 50;
    private float _enemyClickTimer = 0.5f;
    public float oldChumIncreaseTimer = 20f;
    public float startCountdown = 3f;
    public GameObject clickPanel;
    public bool hasStarted = false;
    public FightEnder fightEnd;
    public Text countdownText;
    public Text pClickforceText;
    public Text eClickforceText;
    [SerializeField] private Text _clickFightText;
    public Text infoText;
    public Image enemyFish;
    public Sprite[] enemyFishSprites;
    public string[] enemyNames;
    public Text enemyFishName;
    public GameObject oldChum;
    [SerializeField] private Slider slide;
    public Animator pAnim;
    public Animator eAnim;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        infoText.text = "Click anywhere Rapidly to beat the Anomalous Fish!";
        pClickforceText.text = "Clickforce: " + clickForce;
        eClickforceText.text = "Clickforce: " + opponentClickForce;
        hasStarted = false;
        startCountdown = 3f;
        clickFight = 50;
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasStarted && startCountdown > 0)
        {
            basePlayerClickForce = clickForce;
            startCountdown -= Time.deltaTime;
            countdownText.text = Mathf.RoundToInt(startCountdown).ToString();

        }
        else if (startCountdown <= 0)
        {
            countdownText.text = "FLIP!";
            clickPanel.SetActive(true);
            infoText.gameObject.SetActive(false);
            hasStarted = true;
        }

        if (hasStarted && clickFight != 0 && clickFight != 100)
        {
            _enemyClickTimer -= Time.deltaTime;

            if (_enemyClickTimer <= 0 && clickFight != 0 && clickFight != 100)
            {
                clickFight += opponentClickForce;
                if (clickFight > 100)
                {
                    clickFight = 100;
                }
                _enemyClickTimer = 0.5f;
            }
        }

        _clickFightText.text = clickFight.ToString();
        slide.value = clickFight;

        if (oldChumCount >= 1 && clickFight != 0 && clickFight != 100)
        {
            oldChumIncreaseTimer -= Time.deltaTime;

            if (oldChumIncreaseTimer <= 0)
            {
                oldChum.SetActive(true);
            }
        }


        if (clickFight >= 100)
        {
            clickPanel.SetActive(false);
            pAnim.SetBool("Defeated", true);
            eAnim.SetBool("IsVictorious", true);
            infoText.text = "You were voided! -50 HP";
            infoText.gameObject.SetActive(true);
            GameManager.playerHealth -= 50;
            playerWin = false;
            clickForce = basePlayerClickForce;
            fightEnd.ChangeClickValues();


        }
        else if (clickFight <= 0)
        {
            clickPanel.SetActive(false);
            eAnim.SetBool("Defeated", true);
            pAnim.SetBool("IsVictorious", true);
            infoText.text = "Anomaly Defeated!";
            infoText.gameObject.SetActive(true);
            playerWin = true;
            opponentClickForce += 3;
            clickForce = basePlayerClickForce;
            fightEnd.ChangeClickValues();

        }

    }

    public void CombatClick()
    {
        if (countdownText.gameObject.activeInHierarchy)
        {
            countdownText.gameObject.SetActive(false);
        }

        if (clickFight != 0 && clickFight != 100)
        {
            clickFight -= clickForce;
            if (clickFight < 0)
            {
                clickFight = 0;
            }
        }
    }

}
