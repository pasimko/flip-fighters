using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseScript : MonoBehaviour
{
    public GameObject pauseMenu;
    private GameObject settingsPanel;
    private GameObject controlsPanel;

    ControlsController Controls;
    PlayerController Player;

    public bool paused = false;


    void Start()
    {
        Controls = GetComponent<ControlsController>();
        controlsPanel = GameObject.Find("ControlsPanel");
        settingsPanel = GameObject.Find("SettingsPanel");
        pauseMenu.SetActive(false);
        controlsPanel.SetActive(false);
        settingsPanel.SetActive(false);
        
    }

    public void openMainMenu ()
    {
        SceneManager.LoadScene("Menu");
    }

    public void openSettingsPanel()
    {
        settingsPanel.SetActive(true);
        pauseMenu.SetActive(false);
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
            if (settingsPanel.activeInHierarchy == true)
            {
                settingsPanel.SetActive(false);
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
                Debug.Log("Pause Menu Opening");
                Time.timeScale = 0.0f;
                //Time.deltaTime = 0.0f;
                pauseMenu.SetActive(true);
                paused = true;
                
            }
        }
    }
}



