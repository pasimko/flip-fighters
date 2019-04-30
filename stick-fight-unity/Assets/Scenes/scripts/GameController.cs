using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public List<Transform> stickPlayerList = new List<Transform>();
    public HealthBar player1Bar, player2Bar;
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

    
}