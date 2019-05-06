using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseScript : MonoBehaviour
{

    public GameObject pauseMenu;



    public bool paused = false;


    void Start()
    {
        pauseMenu.SetActive(false);
    }

    /*(public void openMainMenu ()
    {
        SceneManager.LoadScene("Menu");
    }
   public void showControlPanel()
    {
        SceneManager.LoadScene("controls");
    }

    public void showSettingsPanel()
    {
        SceneManager.LoadScene("settings");
    }

    public void nextMap()
    {
        SceneManager.LoadScene("level1");
    }*/
   
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (paused == true)
            {
                Time.timeScale = 1.0f;
                pauseMenu.SetActive(false);
                paused = false;
                //Time.deltaTime = 1.0f;
            }
            else
            {
                Time.timeScale = 0.0f;
                //Time.deltaTime = 0.0f;
                pauseMenu.SetActive(true);
                paused = true;
            }
        }
    }
}



