using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlsController : MonoBehaviour
{


    Toggle ForwardPl1;
    Toggle BackPl1;
    Toggle JumpPl1;
    Toggle AttackPl1;
    Toggle BlockPl1;
    Toggle ForwardPl2;
    Toggle BackPl2;
    Toggle JumpPl2;
    Toggle AttackPl2;
    Toggle BlockPl2;

    bool ForwatdPl1on = false;
    bool BackPl1on = false;
    bool JumpPl1on = false;
    bool AttackPl1on = false;
    bool BlockPl1on = false;
    bool ForwardPl2on = false;
    bool BackPl2on = false;
    bool JumpPl2on = false;
    bool AttackPL2on = false;
    bool BlockPl2on = false;

    private int[] values;

    void Awake()
    {
        values = (int[])System.Enum.GetValues(typeof(KeyCode));
        ForwardPl1 = GetComponent<Toggle>();
        BackPl1 = GetComponent<Toggle>();
        JumpPl1 = GetComponent<Toggle>();
        AttackPl1 = GetComponent<Toggle>();
        BlockPl1 = GetComponent<Toggle>();
        ForwardPl2 = GetComponent<Toggle>();
        BackPl2 = GetComponent<Toggle>();
        JumpPl2 = GetComponent<Toggle>();
        AttackPl2 = GetComponent<Toggle>();
        BlockPl2 = GetComponent<Toggle>();


    }

    

    

}
