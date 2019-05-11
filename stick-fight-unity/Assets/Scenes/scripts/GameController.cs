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

    string[] maps = { "level1", "japan", "islands", "mountain" };
    
    //Cheat code variables
    private string[] cheatCode;
    private int index;

    public GameObject secret;


    void Awake()
    {
        //These layers are for 
        Time.timeScale = 1.0f;
        Physics2D.IgnoreLayerCollision(12, 10, true);
        Physics2D.IgnoreLayerCollision(13, 11, true);
        Physics2D.IgnoreLayerCollision(12, 12, true);
        Physics2D.IgnoreLayerCollision(13, 13, true);
    }
    void Start() {
        // Code is "stick", player needs to input this in the right order
        cheatCode = new string[] { "s", "t", "i", "c", "k" };
        index = 0;    
    }
    void newMap(string level)
    {
        SceneManager.LoadScene(sceneName: level);
        UpdateControls();
    }
    private void Update()
    {
        player1.GetComponent<PlayerController>().paused = gameObject.GetComponent<PauseScript>().paused;
        player2.GetComponent<PlayerController>().paused = gameObject.GetComponent<PauseScript>().paused;

        if (CheckForWin())
        {
            CheckForWin().GetComponent<PlayerController>().won = true;
            StartCoroutine(LoadLevelAfterDelay(5, maps[Random.Range(0, maps.Length)]));
        }
        // Check if any key is pressed
        if (Input.anyKeyDown) {
            // Check if the next key in the code is pressed
            if (Input.GetKeyDown(cheatCode[index])) {
                // Add 1 to index to check the next key in the code
                index++;
            }
            // Wrong key entered, we reset code typing
            else {
                index = 0;    
            }
        }
        
        // If index reaches the length of the cheatCode string, 
        // the entire code was correctly entered
        if (index == cheatCode.Length) {
            Instantiate(secret);
            index = 0;
        }
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

    Transform CheckForWin()
    {
        if (player1.GetComponent<PlayerController>().head.position.y < -15 || player1.GetComponent<PlayerController>().health <= 0)
        {
            return player2;
        }
        else if (player2.GetComponent<PlayerController>().head.position.y < -15 || player2.GetComponent<PlayerController>().health <= 0)
        {
            return player1;
        }
        else
        {
            return null;
        }
    }

    IEnumerator LoadLevelAfterDelay(float delay, string level)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneName: level);
    }
}