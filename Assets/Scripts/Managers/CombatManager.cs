using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CombatManager : MonoBehaviour
{
    #region Int Variables
    public static int clickForce = 1;
    public static int opponentClickForce = 1;
    public static int oldChumCount = 0;
    public static bool playerWin;
    public static int clickFight = 50;
    public int basePlayerClickForce;
    #endregion
    #region Float Variables
    private float _enemyClickTimer = 0.5f;
    public float oldChumIncreaseTimer = 20f;
    public float startCountdown = 3f;
    #endregion
    #region Bool Variable
    public bool hasStarted = false;
    #endregion
    #region String Variable
    public string[] enemyNames;
    #endregion
    #region GameObject Variables
    public GameObject clickPanel;
    public GameObject oldChum;
    #endregion
    #region Text Variables
    public Text countdownText;
    public Text pClickforceText;
    public Text eClickforceText;
    [SerializeField] private Text _clickFightText;
    public Text infoText;
    public Text enemyFishName;
    #endregion
    #region Image Variable
    public Image enemyFish;
    #endregion
    #region Sprite Variable
    public Sprite[] enemyFishSprites;
    #endregion
    #region Slider Variable
    [SerializeField] private Slider slide;
    #endregion
    #region Animator Variables
    public Animator pAnim;
    public Animator eAnim;
    #endregion
    #region Script Variables
    public FightEnder fightEnd;
    #endregion

    #region Start Method
    // Start is called before the first frame update
    void Start()
    {
        //Set the initial text for the info text.
        infoText.text = "Click anywhere Rapidly to beat the Anomalous Fish!";
        //Set the clickforce text to the player's clickforce value.
        pClickforceText.text = "Clickforce: " + clickForce;
        //Set the clickforce text to the enemy's clickforce value.
        eClickforceText.text = "Clickforce: " + opponentClickForce;
        //Set the hasStarted bool to false (this determines if the fight has started yet).
        hasStarted = false;
        //Set the startCountdown to 3f.
        startCountdown = 3f;
        //Set clickFight to 50, the default value in the middle of the slider.
        clickFight = 50;
    }
    #endregion
    #region Update Method
    // Update is called once per frame
    void Update()
    {
        #region Start of Fight
        //If hasStarted is false and 
        if (!hasStarted && startCountdown > 0)
        {
            //Set the basePlayerClickforce to the players clickforce (used later for the Old Chum powerup).
            basePlayerClickForce = clickForce;
            //Countdown from startCountdown's value.
            startCountdown -= Time.deltaTime;
            //Set the countdownText's text to a rounded int of the startCountdown variable.
            countdownText.text = Mathf.RoundToInt(startCountdown).ToString();

        }
        //If startCountdown is less than or equal to 0.
        else if (startCountdown <= 0)
        {
            //Set the countddownText to FLIP!, this will indicate that the player can begin the fight.
            countdownText.text = "FLIP!";
            //Activate the clickPanel, which is the button for the player to click to fight.
            clickPanel.SetActive(true);
            //Disable the infoText at the top of the screen.
            infoText.gameObject.SetActive(false);
            //Set hasStarted to true.
            hasStarted = true;
        }
        #endregion
        #region Enemy Combat
        //If hasStarted is true and clickFight is neither 0 or 100 (the values for either a player win or an enemy win).
        if (hasStarted && clickFight != 0 && clickFight != 100)
        {
            //Countdown the _enemyClickTimer (0.5 second).
            _enemyClickTimer -= Time.deltaTime;

            //if _enemyClickTimer is less than 0 and the player has not won or lost the match yet.
            if (_enemyClickTimer <= 0 && clickFight != 0 && clickFight != 100)
            {
                //Increase clickFight by the opponents clickforce.
                clickFight += opponentClickForce;
                //If clickFight is greater than 100..
                if (clickFight > 100)
                {
                    //Set clickFight to 100 (In case it goes over).
                    clickFight = 100;
                }
                //Reset the _enemyClickTimer to 0.5f.
                _enemyClickTimer = 0.5f;
            }
        }
        #endregion
        #region Visual Indicators of Match
        //Set the _clickFightText to the current clickFight value.
        _clickFightText.text = clickFight.ToString();
        //Change the slider's value to reflect clickFight from 0 - 100.
        slide.value = clickFight;
        #endregion
        #region Old Chum Powerup
        //If the player has an Old Chum power up and the player has not won or lost the match yet.
        if (oldChumCount >= 1 && clickFight != 0 && clickFight != 100)
        {
            //Countdown the oldChumIncreaseTimer (20 seconds).
            oldChumIncreaseTimer -= Time.deltaTime;

            //If the oldChumIncreaseTimer is less than 0.
            if (oldChumIncreaseTimer <= 0)
            {
                //Activate the oldChum gameObject.
                oldChum.SetActive(true);
            }
        }
        #endregion
        #region End Match Conditions
        //If clickFight is equal to or greater than 100.
        if (clickFight >= 100)
        {
            //Disable the countdownText in case the player did not click during the match.
            countdownText.gameObject.SetActive(false);
            //Disable the clickPanel so the player cannot click on the scene.
            clickPanel.SetActive(false);
            //Play the player's Defeated animation.
            pAnim.SetBool("Defeated", true);
            //Play the enemy's Victory animation.
            eAnim.SetBool("IsVictorious", true);
            //Change the infoText's text to a defeat message.
            infoText.text = "You were voided! -50 HP";
            //Enable infoText.
            infoText.gameObject.SetActive(true);
            //Take away 50 HP from the player's health.
            GameManager.playerHealth -= 50;
            //Change the playerWin bool to false to show they lost the match.
            playerWin = false;
            //Set the clickforce back to the basePlayerClickForce (Used to remove the effects of the Old Chum powerup).
            clickForce = basePlayerClickForce;
            //Run the ChangeClickValues method from the FightEnder script.
            fightEnd.ChangeClickValues();


        }
        //If clickFight is less than or equal to 0
        else if (clickFight <= 0)
        {
            //Disable the clickPanel so the player cannot click on the scene.
            clickPanel.SetActive(false);
            //Play the enemy's Defeated animation.
            eAnim.SetBool("Defeated", true);
            //Play the player's Victory animation.
            pAnim.SetBool("IsVictorious", true);
            //Change the infoText's text to a victory message.
            infoText.text = "Anomaly Defeated!";
            //Enable infoText.
            infoText.gameObject.SetActive(true);
            //Change the playerWin bool to true to show they won the match.
            playerWin = true;
            //Increase the opponent's clickforce for the next time to player is in combat.
            opponentClickForce += 2;
            //Set the clickforce back to the basePlayerClickForce (Used to remove the effects of the Old Chum powerup).
            clickForce = basePlayerClickForce;
            //Run the ChangeClickValues method from the FightEnder script.
            fightEnd.ChangeClickValues();

        }
        #endregion
    }
    #endregion
    #region Button Method
    public void CombatClick()
    {
        //If the countdownText gameObject is active in the hierarchy.
        if (countdownText.gameObject.activeInHierarchy)
        {
            //Disable it.
            countdownText.gameObject.SetActive(false);
        }
        //If clickFight is not equal to 0 or 100.
        if (clickFight != 0 && clickFight != 100)
        {
            //Subtract the player's clickforce from clickFight.
            clickFight -= clickForce;
            //If clickFight is less than 0.
            if (clickFight < 0)
            {
                //Set clickFight to 0 (in case it goes over).
                clickFight = 0;
            }
        }
    }
    #endregion
}
