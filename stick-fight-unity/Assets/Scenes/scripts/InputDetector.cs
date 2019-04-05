using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputDetector : MonoBehaviour
{
    string pl1ForwardKey = "d";
    string pl1BackKey = "a";
    string pl1JumpKey = "w";
    string pl1AttackKey = "space";
    string pl1BlockKey = "b";

    string pl2ForwardKey = "right";
    string pl2BackKey = "left";
    string pl2JumpKey = "up";
    string pl2AttackKey = "right ctrl";
    string pl2BlockKey = "right shift";

    void Update()
    {

        if (Input.GetKeyDown(pl1ForwardKey))
        {
            Debug.Log("Pl1 pressed forward");
        }
        if (Input.GetKeyDown(pl1BackKey))
        {
            Debug.Log("Pl1 pressed back");
        }
        if (Input.GetKeyDown(pl1JumpKey))
        {
            Debug.Log("Pl1 pressed jump");
        }
        if (Input.GetKeyDown(pl1AttackKey))
        {
            Debug.Log("Pl1 pressed attack");
        }
        if (Input.GetKeyDown(pl1BlockKey))
        {
            Debug.Log("Pl1 pressed block");
        }

        if (Input.GetKeyDown(pl2ForwardKey))
        {
            Debug.Log("Pl2 pressed forward");
        }
        if (Input.GetKeyDown(pl2BackKey))
        {
            Debug.Log("Pl2 pressed back");
        }
        if (Input.GetKeyDown(pl2JumpKey))
        {
            Debug.Log("Pl2 pressed jump");
        }
        if (Input.GetKeyDown(pl2AttackKey))
        {
            Debug.Log("Pl2 pressed attack");
        }
        if (Input.GetKeyDown(pl2BlockKey))
        {
            Debug.Log("Pl2 pressed block");
        }
    }
}
