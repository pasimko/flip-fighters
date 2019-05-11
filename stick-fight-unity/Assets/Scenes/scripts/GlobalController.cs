using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;

public class GlobalController : MonoBehaviour
{
    public static GlobalController Instance;

    public Color player1Color;
    public Color player2Color;

    public KeyCode jump1, left1, right1, attack1, block1;
    public KeyCode jump2, left2, right2;
    public KeyCode attack2 = KeyCode.RightControl;
    public KeyCode block2 = KeyCode.RightShift;

    bool fightingScene;

    float player1Health, player2Health;
    Image healthBar1, healthBar2;
    Image[] theImages;

    public AudioMixerSnapshot part1,part2,part3,part4;

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded (Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "developers" || scene.name == "islands" || scene.name == "japan" || scene.name == "level1" || scene.name == "mountain")
        {
            fightingScene = true;
           
        }
        else
        {
            fightingScene = false;
        }
        part1.TransitionTo(1f);

 
    }


    void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (fightingScene == true)
        {
            theImages = FindObjectsOfType<Image>();

            healthBar1 = theImages[1];
            healthBar2 = theImages[0];
            
            player1Health = healthBar1.fillAmount * 100;
            player2Health = healthBar2.fillAmount * 100;
            Debug.Log("Player 1 health" + player1Health);
            Debug.Log("Player 2 health" + player2Health);

            if (player1Health <= 75 && player1Health > 50)
            {
                part2.TransitionTo(1f);
            }
            else if (player2Health <= 75 && player2Health > 50)
            {
                part2.TransitionTo(1f);
            }
            else if (player1Health <= 50 && player1Health > 25)
            {
                part3.TransitionTo(1f);
            }
            else if (player2Health <= 50 && player2Health > 25)
            {
                part3.TransitionTo(1f);
            }
            else if (player1Health <= 25 || player2Health <= 25)
            {
                part4.TransitionTo(1f);
            }
        }
    }
}
