using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{

  
    public void startGame()
    {
        SceneManager.LoadScene(sceneName: "level1");
    }

    public void goControls()
    {
        SceneManager.LoadScene(sceneName: "controls");
    }

    public void backToMenu()
    {
        SceneManager.LoadScene(sceneName: "menu");
    }

    public void goSettings()
    {
        SceneManager.LoadScene(sceneName: "settings");
    }

}


