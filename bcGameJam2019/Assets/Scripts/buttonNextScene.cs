using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonNextScene : MonoBehaviour
{

    public void nextLevel()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainLevel");
    }
    public void titleScreen()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("titleScene");
    }


}
