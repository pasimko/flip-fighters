using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
    public Transform stickPlayer1;
    public Transform stickPlayer2;


    void Awake()
    {
        
            GameObject tempPlayer1Obj = new GameObject();
            Transform tempPlayer1Transform = tempPlayer1Obj.transform;
            Vector3 stickPlayer1Pos = new Vector3(Random.Range(-16, -3), 6, 10);
            tempPlayer1Transform = Instantiate(stickPlayer1, stickPlayer1Pos, Quaternion.identity);

            GameObject tempPlayer2Obj = new GameObject();
            Transform tempPlayer2Transform = tempPlayer2Obj.transform;
            Vector3 stickPlayer2Pos = new Vector3(Random.Range(0, 9), 6, 10);
            tempPlayer2Transform = Instantiate(stickPlayer2, stickPlayer2Pos, Quaternion.identity);

    }
    void newMap()
    {
         SceneManager.LoadScene(sceneName: "level1");
    }
}
