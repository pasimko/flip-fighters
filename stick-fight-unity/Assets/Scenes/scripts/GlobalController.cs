using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalController : MonoBehaviour
{
    public static GlobalController Instance;

    public Color player1Color;
    public Color player2Color;

    public KeyCode jump1, left1, right1, attack1, block1;
    public KeyCode jump2, left2, right2;
    public KeyCode attack2 = KeyCode.RightControl;
    public KeyCode block2 = KeyCode.RightShift;

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
}
