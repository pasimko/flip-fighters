using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseScript : MonoBehaviour
{

    public GameObject pauseMenu;
    private bool paused = false;

    void Start()
    {
        pauseMenu.SetActive(false);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (paused == true)
            {
                Time.timeScale = 1.0f;
                pauseMenu.SetActive(false);
                paused = false;
            }
            else
            {
                Time.timeScale = 0.0f;
                pauseMenu.SetActive(true);
                paused = true;
            }
        }
    }
}



