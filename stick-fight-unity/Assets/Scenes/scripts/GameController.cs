using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Transform stickPlayer;
    public List<Transform> stickPlayerList = new List<Transform>();
    PlayerController player1;
    PlayerController player2;
    public HealthBar player1Bar, player2Bar;

    
    void Awake()
    {
        Time.timeScale = 1.0f;
        player1 = new PlayerController();
        player2 = new PlayerController();

        player1.Initialize(stickPlayer, new Vector3(Random.Range(-16, -3), 6, 10));
        player2.Initialize(stickPlayer, new Vector3(Random.Range(3, 16), 6, 10));
        



    }
    void newMap()
    {
        SceneManager.LoadScene(sceneName: "level1");
    }

    
}