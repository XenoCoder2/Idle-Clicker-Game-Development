using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    #region GameStates Variable
    public static GameStates gameState;
    #endregion
    #region GameObject Variables
    public GameObject mainMenuPanel;
    public GameObject gamePanel;
    public GameObject gameOverPanel;
    #endregion
    #region Start Method
    // Start is called before the first frame update
    void Start()
    {
        //Set the initial gameState to PreGame.
        gameState = GameStates.PreGame;
    }
    #endregion
    #region SwitchStates method.
    public void SwitchStates()
    {
        //Switch between the current gameState.
        switch (gameState)
        {
            case GameStates.PreGame:
                //Enable the mainMenuPanel.
                mainMenuPanel.SetActive(true);
                //Disable the gamePanel.
                gamePanel.SetActive(false);
                //Disable the gameOverPanel.
                gameOverPanel.SetActive(false);
                break;
            case GameStates.MainGame:
                //Enable the gamePanel.
                gamePanel.SetActive(true);
                //Disable the mainMenuPanel.
                mainMenuPanel.SetActive(false);
                //Disable the gameOverPanel.
                gameOverPanel.SetActive(false);
                break;
            case GameStates.GameOver:
                //Enable the gameOverPanel.
                gameOverPanel.SetActive(true);
                //Disable the gamePanel.
                gamePanel.SetActive(false);
                //Disable the mainMenuPanel.
                mainMenuPanel.SetActive(false);
                break;
            default:
                break;
        }

    }
    #endregion
}
//Enum for each Game State.
public enum GameStates
{
    PreGame,
    MainGame,
    GameOver
}