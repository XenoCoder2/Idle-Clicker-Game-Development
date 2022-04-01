using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonHandler : MonoBehaviour
{
    #region Int Variable
    public static int flipRate = 1;
    #endregion
    #region Script Variables
    public GameManager manage;
    public GameStateManager gameStateManager;
    #endregion

    #region Commented Out Example
    /* Example Methods and Overflow
    private void Start()
    {
        Debug.Log(GreaterThanTen(Random.Range(0f, 16f)));
        Debug.Log(Addition(9f, 10f));
        Debug.Log(Addition(1f, 3f, 9f));
    }

    bool GreaterThanTen(float value)
    {
        if (value > 10)
        {
            return true;
        }
        else
        {
            return false;
        }
       
    }

    float Addition(float x, float y)
    {
        if (x == 9 && y == 10 || y == 9 && x == 10)
        {
            return 21;
        }

        return x + y; 
    }
    //Overflow
    float Addition(float x, float y, float z)
    {
        if (x == 9 && y == 10 || y == 9 && x == 10)
        {
            return 21;
        }

        return x + y + z;
    }
    */
    #endregion
    #region Click Method
    public void Click()
    {
        //Increase flips by the flipRate.
        GameManager.flips += flipRate;
        //Increase fillFlips by the flipRate.
        GameManager.fillFlips += flipRate;
        //Increase totalFlips by the flipRate.
        GameManager.totalFlips += flipRate;
        //Debug.Log the current amount of flips.
        Debug.Log(GameManager.flips);
        //Runt the Fill method on the GameManager script.
        manage.Fill();
        
    }
    #endregion
    #region Update Method
    private void Update()
    {
        //Use this only for testing
        if (Input.GetKeyDown(KeyCode.T))
        {
            //Increase values for easier testing of systems.
            GameManager.flips += 500;
            GameManager.fillFlips += 500;
            GameManager.totalFlips += 500;
            manage.Fill();
        }
    }
    #endregion
    #region ADClick method
    public void ADClick()
    {
        //Opens a really funny video in the default browser.
        Application.OpenURL("https://www.youtube.com/watch?v=dQw4w9WgXcQ");
    }
    #endregion
    #region Quit and Restart and Start Methods
    public void Quit()
    {
        //Quit the game.
        Application.Quit();
    }

    public void Restart()
    {
        //Reset each value of the game back to it's default value
        GameManager.flips = 0;
        GameManager.fillFlips = 0;
        GameManager.totalFlips = 0;
        GameManager.midasFlips = 0;
        GameManager.playerHealth = 100;
        GameManager.autoFlips = 0;
        CombatManager.clickForce = 1;
        CombatManager.opponentClickForce = 1;
        CombatManager.oldChumCount = 0;
        GameStateManager.gameState = GameStates.PreGame;
        flipRate = 1;
        manage.spinMax = 5000f;
        //Reload the scene.
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void StartGame()
    {
        //Set the current gameState to the Main Game.
        GameStateManager.gameState = GameStates.MainGame;
        //Run the SwitchStates method of the GameStateManager.
        gameStateManager.SwitchStates();
    }
    #endregion
}
