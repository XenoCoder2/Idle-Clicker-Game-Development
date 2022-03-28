using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonHandler : MonoBehaviour
{
    public static int flipRate = 1;
    public GameManager manage;

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

    public void Click()
    {
        GameManager.flips += flipRate;
        GameManager.totalFlips += flipRate;
        Debug.Log(GameManager.flips);
        manage.Fill();
        
    }
    public void QuickPointsTestingOnly()
    {
        GameManager.flips += 500;
        GameManager.totalFlips += 500;
        manage.Fill();
    }

    public void ADClick()
    {
        //Opens the AD in the default browser | shhh. 
        Application.OpenURL("https://www.youtube.com/watch?v=dQw4w9WgXcQ");
    }

    public void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }
   
}
