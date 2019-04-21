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
    public Image p1HealthBar;
    public Image p2HealthBar;


    void Awake()
    {

      

        player1 = new PlayerController();
        player2 = new PlayerController();

        player1.Initialize(stickPlayer, new Vector3(Random.Range(-16, -3), 6, 10));
        player2.Initialize(stickPlayer, new Vector3(Random.Range(3, 16), 6, 10));




        p1HealthBar.fillAmount = 0.5f;
        p2HealthBar.fillAmount = 0.17f;



    }
    void newMap()
    {
        SceneManager.LoadScene(sceneName: "level1");
    }
}
