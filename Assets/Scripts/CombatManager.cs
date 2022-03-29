using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CombatManager : MonoBehaviour
{
    public static int clickForce = 1;
    public static int opponentClickForce = 1;
    public static bool playerWin;
    [SerializeField] public static int clickFight = 50;
    private float _enemyClickTimer = 0.5f;
    public float startCountdown = 3f;
    public GameObject clickPanel;
    public bool hasStarted = false;
    public FightEnder fightEnd;
    public Text countdownText;
    public Text pClickforceText;
    public Text eClickforceText;
    [SerializeField] private Text _clickFightText;
     public Text infoText;
    [SerializeField] private Slider slide;
    public Animator pAnim;
    public Animator eAnim;

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
                _enemyClickTimer = 0.5f;
            }
        }

        _clickFightText.text = clickFight.ToString();
        slide.value = clickFight;
       

        if (clickFight >= 100)
        {
            pAnim.SetBool("Defeated", true);
            eAnim.SetBool("IsVictorious", true);
            infoText.text = "You were voided! -50 HP";
            infoText.gameObject.SetActive(true);
            GameManager.playerHealth -= 50;
            playerWin = false;
            
            fightEnd.ChangeClickValues();


        }
        else if (clickFight <= 0)
        {
            eAnim.SetBool("Defeated", true);
            pAnim.SetBool("IsVictorious", true);
            infoText.text = "Anomaly Defeated!";
            infoText.gameObject.SetActive(true);
            playerWin = true;
           
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
        }
    }
}
