using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseScript : MonoBehaviour
{

    public GameObject pauseMenu;
    private GameObject controlsPanel;


    public bool paused = false;


    void Start()
    {
        controlsPanel = GameObject.Find("ControlsPanel");
        pauseMenu.SetActive(false);
        controlsPanel.SetActive(false);
    }

    public void openMainMenu ()
    {
        SceneManager.LoadScene("Menu");
    }

    public void openControlsPanel()
    {
        controlsPanel.SetActive(true);
        pauseMenu.SetActive(false);
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (controlsPanel.activeInHierarchy == true)
            {
                controlsPanel.SetActive(false);
                pauseMenu.SetActive(true);
            }
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



