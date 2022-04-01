using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    #region Script Variables
    public GameManager manage;
    public FightTransition fightTransition;
    public GameStateManager gameStateManage;
    #endregion
    #region Game Over Reset Method
    public void GameOverReset()
    {
        //Reset all values of the game to their defaults.
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
        //Set the gameState to PreGame.
        GameStateManager.gameState = GameStates.PreGame;
        //Reload the Scene.
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);   
    }
    #endregion
}
