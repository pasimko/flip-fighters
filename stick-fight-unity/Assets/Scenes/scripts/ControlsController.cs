using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlsController : MonoBehaviour
{
    KeyCode Pl1ForwardInput = KeyCode.D;
    KeyCode Pl1BackInput = KeyCode.A;
    KeyCode Pl1JumpInput = KeyCode.W;
    KeyCode PL1AttackInput = KeyCode.Space;
    KeyCode Pl1BlockInput = KeyCode.B;

    KeyCode Pl2ForwardInput = KeyCode.RightArrow;
    KeyCode Pl2BackInput = KeyCode.LeftArrow;
    KeyCode Pl2JumpInput = KeyCode.UpArrow;
    KeyCode Pl2AttackInput = KeyCode.RightControl;
    KeyCode Pl2BlockInput = KeyCode.RightShift;
    

    public Toggle ForwardPl1;
    public Toggle BackPl1;
    public Toggle JumpPl1;
    public Toggle AttackPl1;
    public Toggle BlockPl1;
    public Toggle ForwardPl2;
    public Toggle BackPl2;
    public Toggle JumpPl2;
    public Toggle AttackPl2;
    public Toggle BlockPl2;

    string F1string;

    public Text F1text;

    private int[] values;
    private KeyCode PlayerInput;

    void Awake()
    {
        values = (int[])System.Enum.GetValues(typeof(KeyCode));

        ForwardPl1.onValueChanged.AddListener(delegate
        {
            ToggleChange(ForwardPl1);
        });
        BackPl1.onValueChanged.AddListener(delegate
        {
            ToggleChange(BackPl1);
        });
        JumpPl1.onValueChanged.AddListener(delegate
        {
            ToggleChange(JumpPl1);
        });
        AttackPl1.onValueChanged.AddListener(delegate
        {
            ToggleChange(AttackPl1);
        });
        BlockPl1.onValueChanged.AddListener(delegate
        {
            ToggleChange(BlockPl1);
        });
        ForwardPl2.onValueChanged.AddListener(delegate
        {
            ToggleChange(ForwardPl2);
        });
        BackPl2.onValueChanged.AddListener(delegate
        {
            ToggleChange(BackPl2);
        });
        JumpPl2.onValueChanged.AddListener(delegate
        {
            ToggleChange(JumpPl2);
        });
        AttackPl2.onValueChanged.AddListener(delegate
        {
            ToggleChange(AttackPl2);
        });
        BlockPl2.onValueChanged.AddListener(delegate
        {
            ToggleChange(BlockPl2);
        });
    }

    private void Update()
    {
        if (ForwardPl1.isOn == true)
        {
            foreach (KeyCode pInput in values)
            {
                if (Input.GetKey(pInput))
                {
                    PlayerInput = pInput;
                    if (PlayerInput != KeyCode.Mouse0 )
                    {
                        F1string = PlayerInput.ToString();
                        F1text.text = F1string;
                        Debug.Log(pInput);
                        ForwardPl1.isOn = false;
                    }
                }
            }
        }
        
    }

    void ToggleChange(Toggle change)
    {
        Debug.Log("Hello The Toggle Changed");
        if (change.isOn == true)
        {
            change.image.color = Color.cyan;
        }
        else
        {
            change.image.color = Color.white;
        }
    }



}
