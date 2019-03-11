using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
    public Transform stickPlayer;
    public List<Transform> stickPlayerList = new List<Transform>();

    void Awake()
    {
        for (int i = 0; i < 2; i++)
        {
            GameObject tempPlayerObj = new GameObject();
            Transform tempPlayerTransform = tempPlayerObj.transform;
            Vector2 stickPlayerPos = new Vector2(Random.Range(-5, 5), 0);
            tempPlayerTransform = Instantiate(stickPlayer, stickPlayerPos, Quaternion.identity);
            stickPlayerList.Add(tempPlayerTransform);
        }
    }
    void newMap()
    {
         SceneManager.LoadScene(sceneName: "level1");
    }
}
