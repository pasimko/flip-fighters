using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour {

    private void Awake()
    {
        SceneManager.LoadScene(sceneName: "menu");
    }

    public void startGame ()
    {
        SceneManager.LoadScene(sceneName: "mainScene");
    }

}
