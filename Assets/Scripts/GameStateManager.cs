using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    public static GameStates gameState;
    public GameObject mainMenuPanel;
    public GameObject gamePanel;
    public GameObject gameOverPanel;
   
    // Start is called before the first frame update
    void Start()
    {
        gameState = GameStates.PreGame;
    }

    public void SwitchStates()
    {
        switch (gameState)
        {
            case GameStates.PreGame:
                mainMenuPanel.SetActive(true);
                gamePanel.SetActive(false);
                gameOverPanel.SetActive(false);
                break;
            case GameStates.MainGame:
                gamePanel.SetActive(true);
                mainMenuPanel.SetActive(false);
                gameOverPanel.SetActive(false);
                break;
            case GameStates.GameOver:
                gameOverPanel.SetActive(true);
                gamePanel.SetActive(false);
                mainMenuPanel.SetActive(false);
                break;
            default:
                break;
        }
    }
}

public enum GameStates
{
    PreGame,
    MainGame,
    GameOver
}