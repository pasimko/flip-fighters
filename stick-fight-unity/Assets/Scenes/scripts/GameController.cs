using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Transform player1;
    public Transform player2;

    public KeyCode p1jump, p1left, p1right, p1attack;
    public KeyCode p2jump, p2left, p2right, p2attack;


    void Awake()
    {
        Time.timeScale = 1.0f;
        Physics2D.IgnoreLayerCollision(12, 10, true);
        Physics2D.IgnoreLayerCollision(13, 11, true);
        Physics2D.IgnoreLayerCollision(12, 12, true);
        Physics2D.IgnoreLayerCollision(13, 13, true);
    }
    void newMap()
    {
        SceneManager.LoadScene(sceneName: "level1");
        UpdateControls();
    }
    private void Update()
    {
        player1.GetComponent<PlayerController>().paused = gameObject.GetComponent<PauseScript>().paused;
        player2.GetComponent<PlayerController>().paused = gameObject.GetComponent<PauseScript>().paused;
    }

    public void UpdateControls()
    {
        player1.GetComponent<PlayerController>().jump = p1jump;
        player1.GetComponent<PlayerController>().right = p1right;
        player1.GetComponent<PlayerController>().left = p1left;
        player1.GetComponent<PlayerController>().attack = p1attack;

        player2.GetComponent<PlayerController>().jump = p2jump;
        player2.GetComponent<PlayerController>().right = p2right;
        player2.GetComponent<PlayerController>().left = p2left;
        player2.GetComponent<PlayerController>().attack = p2attack;
    }

}