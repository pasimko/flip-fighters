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
            Vector3 stickPlayerPos = new Vector3(Random.Range(-5, 5), 6, 10);
            tempPlayerTransform = Instantiate(stickPlayer, stickPlayerPos, Quaternion.identity);
            stickPlayerList.Add(tempPlayerTransform);
        }
    }
    void newMap()
    {
         SceneManager.LoadScene(sceneName: "level1");
    }
}
