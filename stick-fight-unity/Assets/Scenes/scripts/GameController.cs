using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
    private InitMap map;
    
    void Awake () {
        newMap();
    }
    void newMap() {
        map = GetComponent<InitMap>();
    }
}
