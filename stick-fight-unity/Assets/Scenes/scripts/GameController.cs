using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public Transform stickPlayer;
    public List<Transform> stickPlayerList = new List<Transform>();
    public PlayerController player1;
    public PlayerController player2;

    void Awake()
    {
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
