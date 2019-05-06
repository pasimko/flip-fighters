using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Transform player1;
    public Transform player2;

    
    void Awake()
    {
        Time.timeScale = 1.0f;
    }
    void newMap()
    {
        SceneManager.LoadScene(sceneName: "level1");
    }
    private void Update()
    {
        player1.GetComponent<PlayerController>().paused = gameObject.GetComponent<PauseScript>().paused;
        player2.GetComponent<PlayerController>().paused = gameObject.GetComponent<PauseScript>().paused;
    }


}