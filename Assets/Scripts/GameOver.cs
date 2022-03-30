using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameManager manage;
   
    public void GameOverReset()
    {
        
        GameManager.flips = 0;
        GameManager.fillFlips = 0;
        GameManager.totalFlips = 0;
        GameManager.midasFlips = 0;
        GameManager.playerHealth = 100;
        GameManager.autoFlips = 0;
        CombatManager.clickForce = 1;
        CombatManager.opponentClickForce = 1;
        CombatManager.oldChumCount = 0;
        ButtonHandler.flipRate = 1;
        manage.spinMax = 5000f;
        GameStateManager.gameState = GameStates.PreGame;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);   
    }
}
