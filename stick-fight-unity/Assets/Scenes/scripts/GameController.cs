using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public List<Transform> stickPlayerList = new List<Transform>();
    public Transform player1;
    public Transform player2;


    void Awake()
    {
    }
    void newMap()
    {
        SceneManager.LoadScene(sceneName: "level1");
    }
}
