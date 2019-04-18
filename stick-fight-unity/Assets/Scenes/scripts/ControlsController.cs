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

    public Text F1text;

    private int[] values;

    void Awake()
    {
        values = (int[])System.Enum.GetValues(typeof(KeyCode));

        ForwardPl1.onValueChanged.AddListener(delegate
        {
            ForwardPl1Change(ForwardPl1);
        });
        F1text.text = "Initial Value" + ForwardPl1.isOn;

    }

    private void Update()
    {
       /* if (ForwardPl1.isOn == true)
        {
            foreach (KeyCode pInput in values)
            {
                if (Input.GetKey(pInput))
                {
                    Debug.Log(pInput);
                    ForwardPl1.image.color = Color.white;

                    //ForwardPl1.GetComponentInChildren<Text>().text = pInput;
                    ForwardPl1.isOn = false;
                }
            }
        }
        */
    }

    void ForwardPl1Change(Toggle change)
    {
        F1text.text = "New Value" + ForwardPl1.isOn;
    }



}
