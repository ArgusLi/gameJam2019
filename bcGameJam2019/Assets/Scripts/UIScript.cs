using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIScript : MonoBehaviour
{


    public void nextLevel()
    {
        Constants.setEnergy(false);
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainLevel");
    }
    public void titleScreen()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("titleScene");
    }
    public void quitGame()
    {
        Application.Quit();
    }


}
