using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlsController : MonoBehaviour
{
    public KeyCode Pl1ForwardInput;
    public KeyCode Pl1BackInput;
    public KeyCode Pl1JumpInput;
    public KeyCode PL1AttackInput;
    public KeyCode Pl1BlockInput;

    public KeyCode Pl2ForwardInput;
    public KeyCode Pl2BackInput;
    public KeyCode Pl2JumpInput;
    public KeyCode Pl2AttackInput;
    public KeyCode Pl2BlockInput;
    

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
    string B1string;
    string J1string;
    string A1string;
    string BL1string;
    string F2string;
    string B2string;
    string J2string;
    string A2string;
    string BL2string;

    public Text F1text;
    public Text B1text;
    public Text J1text;
    public Text A1text;
    public Text BL1text;
    public Text F2text;
    public Text B2text;
    public Text J2text;
    public Text A2text;
    public Text BL2text;

    private int[] values;
    private KeyCode PlayerInput;

    void Awake()
    {
        values = (int[])System.Enum.GetValues(typeof(KeyCode));

        Toggle[] AllToggles = new Toggle[10] { ForwardPl1, BackPl1, JumpPl1, AttackPl1, BlockPl1, ForwardPl2, BackPl2, JumpPl2, AttackPl2, BlockPl2 };

        KeyCode Pl1ForwardInput = GlobalController.Instance.right1;
        KeyCode Pl1BackInput = GlobalController.Instance.left1;
        KeyCode Pl1JumpInput = GlobalController.Instance.jump1;
        KeyCode PL1AttackInput = GlobalController.Instance.attack1;
        KeyCode Pl1BlockInput = GlobalController.Instance.block1;

        KeyCode Pl2ForwardInput = GlobalController.Instance.right2;
        KeyCode Pl2BackInput = GlobalController.Instance.left2;
        KeyCode Pl2JumpInput = GlobalController.Instance.jump2;
        KeyCode Pl2AttackInput = GlobalController.Instance.attack2;
        KeyCode Pl2BlockInput = GlobalController.Instance.block2;

        KeyCode[] allInputs = new KeyCode[] { Pl1ForwardInput, Pl1BackInput, Pl1JumpInput, PL1AttackInput, Pl1BlockInput, Pl2ForwardInput, Pl2BackInput, Pl2JumpInput, Pl2AttackInput, Pl2BlockInput };
        Text[] allText = new Text[] { F1text, B1text, J1text, A1text, BL1text, F2text, B2text, J2text, A2text, BL2text };

        for (int i = 0; i < allInputs.Length; i++)
        {
            string theInput = allInputs[i].ToString();
            if (theInput.Length <= 5)
            {
                allText[i].fontSize = 60;
            }
            else if (theInput.Length > 5 && theInput.Length <= 9)

            {
                allText[i].fontSize = 40;
            }
            else
            {
                allText[i].fontSize = 38;
            }
            allText[i].text = theInput; 
        }

        ForwardPl1.onValueChanged.AddListener(delegate
        {
            ToggleChange(ForwardPl1,AllToggles);
        });
        BackPl1.onValueChanged.AddListener(delegate
        {
            ToggleChange(BackPl1,AllToggles);
        });
        JumpPl1.onValueChanged.AddListener(delegate
        {
            ToggleChange(JumpPl1,AllToggles);
        });
        AttackPl1.onValueChanged.AddListener(delegate
        {
            ToggleChange(AttackPl1,AllToggles);
        });
        BlockPl1.onValueChanged.AddListener(delegate
        {
            ToggleChange(BlockPl1,AllToggles);
        });
        ForwardPl2.onValueChanged.AddListener(delegate
        {
            ToggleChange(ForwardPl2,AllToggles);
        });
        BackPl2.onValueChanged.AddListener(delegate
        {
            ToggleChange(BackPl2,AllToggles);
        });
        JumpPl2.onValueChanged.AddListener(delegate
        {
            ToggleChange(JumpPl2,AllToggles);
        });
        AttackPl2.onValueChanged.AddListener(delegate
        {
            ToggleChange(AttackPl2,AllToggles);
        });
        BlockPl2.onValueChanged.AddListener(delegate
        {
            ToggleChange(BlockPl2,AllToggles);
        });
    }

    

    private void Update()
    {

        if (Input.GetKeyDown(Pl1ForwardInput))
        {
            Debug.Log("PL1 Forward Pressed");
        }
        if (Input.GetKeyDown(PL1AttackInput))
        {
            Debug.Log("PL1 Attack Pressed");
        }
        if (ForwardPl1.isOn == true)
        {
            foreach (KeyCode pInput in values)
            {
                if (Input.GetKey(pInput))
                {
                    Debug.Log("input recieved");
                    PlayerInput = pInput;
                    if (PlayerInput != KeyCode.Mouse0)
                    {
                        Debug.Log("input is not mouse");
                        F1string = PlayerInput.ToString();
                        if (F1string.Length <= 5 )
                        {
                            F1text.fontSize = 60;
                        }
                        else if (F1string.Length > 5 && F1string.Length <= 9)

                        {
                            F1text.fontSize = 40;
                        }
                        else
                        {
                            F1text.fontSize = 38;
                        }
                        F1text.text = F1string;
                        Debug.Log(pInput);
                        ForwardPl1.isOn = false;
                        Pl1ForwardInput = PlayerInput;

                    }
                }
            }
        }
        if (BackPl1.isOn == true)
        {
            foreach (KeyCode pInput in values)
            {
                if (Input.GetKey(pInput))
                {
                    PlayerInput = pInput;
                    if (PlayerInput != KeyCode.Mouse0)
                    {
                        B1string = PlayerInput.ToString();
                        if (B1string.Length <= 5)
                        {
                            B1text.fontSize = 60;
                        }
                        else if (B1string.Length > 5 && B1string.Length <= 9)

                        {
                            B1text.fontSize = 40;
                        }
                        else
                        {
                            B1text.fontSize = 38;
                        }
                        B1text.text = B1string;
                        Debug.Log(pInput);
                        BackPl1.isOn = false;
                        Pl1BackInput = PlayerInput;
                    }
                }
            }
        }
        if (JumpPl1.isOn == true)
        {
            foreach (KeyCode pInput in values)
            {
                if (Input.GetKey(pInput))
                {
                    PlayerInput = pInput;
                    if (PlayerInput != KeyCode.Mouse0)
                    {
                        J1string = PlayerInput.ToString();
                        if (J1string.Length <= 5)
                        {
                            J1text.fontSize = 60;
                        }
                        else if (J1string.Length > 5 && J1string.Length <= 9)

                        {
                            J1text.fontSize = 40;
                        }
                        else
                        {
                            J1text.fontSize = 38;
                        }
                        J1text.text = J1string;
                        Debug.Log(pInput);
                        JumpPl1.isOn = false;
                        Pl1JumpInput = PlayerInput;
                    }
                }
            }
        }
        if (AttackPl1.isOn == true)
        {
            foreach (KeyCode pInput in values)
            {
                if (Input.GetKey(pInput))
                {
                    PlayerInput = pInput;
                    if (PlayerInput != KeyCode.Mouse0)
                    {
                        A1string = PlayerInput.ToString();
                        if (A1string.Length <= 5)
                        {
                            A1text.fontSize = 60;
                        }
                        else if (A1string.Length > 5 && A1string.Length <= 9)

                        {
                            A1text.fontSize = 40;
                        }
                        else
                        {
                            A1text.fontSize = 38;
                        }
                        A1text.text = A1string;
                        Debug.Log(pInput);
                        AttackPl1.isOn = false;
                        PL1AttackInput = PlayerInput;
                    }
                }
            }
        }
        if (BlockPl1.isOn == true)
        {
            foreach (KeyCode pInput in values)
            {
                if (Input.GetKey(pInput))
                {
                    PlayerInput = pInput;
                    if (PlayerInput != KeyCode.Mouse0)
                    {
                        BL1string = PlayerInput.ToString();
                        if (BL1string.Length <= 5)
                        {
                            BL1text.fontSize = 60;
                        }
                        else if (BL1string.Length > 5 && BL1string.Length <= 9)

                        {
                            BL1text.fontSize = 40;
                        }
                        else
                        {
                            BL1text.fontSize = 38;
                        }
                        BL1text.text = BL1string;
                        Debug.Log(pInput);
                        BlockPl1.isOn = false;
                        Pl1BlockInput = PlayerInput;
                    }
                }
            }
        }
        if (ForwardPl2.isOn == true)
        {
            foreach (KeyCode pInput in values)
            {
                if (Input.GetKey(pInput))
                {
                    PlayerInput = pInput;
                    if (PlayerInput != KeyCode.Mouse0)
                    {
                        F2string = PlayerInput.ToString();
                        if (F2string.Length <= 5)
                        {
                            F2text.fontSize = 60;
                        }
                        else if (F2string.Length > 5 && F2string.Length <= 9)

                        {
                            F2text.fontSize = 40;
                        }
                        else
                        {
                            F2text.fontSize = 38;
                        }
                        F2text.text = F2string;
                        Debug.Log(pInput);
                        ForwardPl2.isOn = false;
                        Pl2ForwardInput = PlayerInput;
                    }
                }
            }
        }
        if (BackPl2.isOn == true)
        {
            foreach (KeyCode pInput in values)
            {
                if (Input.GetKey(pInput))
                {
                    PlayerInput = pInput;
                    if (PlayerInput != KeyCode.Mouse0)
                    {
                        B2string = PlayerInput.ToString();
                        if (B2string.Length <= 5)
                        {
                            B2text.fontSize = 60;
                        }
                        else if (B2string.Length > 5 && B2string.Length <= 9)

                        {
                            B2text.fontSize = 40;
                        }
                        else
                        {
                           B2text.fontSize = 38;
                        }
                        B2text.text = B2string;
                        Debug.Log(pInput);
                        BackPl2.isOn = false;
                        Pl2BackInput = PlayerInput;
                    }
                }
            }
        }
        if (JumpPl2.isOn == true)
        {
            foreach (KeyCode pInput in values)
            {
                if (Input.GetKey(pInput))
                {
                    PlayerInput = pInput;
                    if (PlayerInput != KeyCode.Mouse0)
                    {
                        J2string = PlayerInput.ToString();
                        if (J2string.Length <= 5)
                        {
                            J2text.fontSize = 60;
                        }
                        else if (J2string.Length > 5 && J2string.Length <= 9)

                        {
                            F2text.fontSize = 40;
                        }
                        else
                        {
                            J2text.fontSize = 38;
                        }
                        J2text.text = J2string;
                        Debug.Log(pInput);
                        JumpPl2.isOn = false;
                        Pl2JumpInput = PlayerInput;
                    }
                }
            }
        }
        if (AttackPl2.isOn == true)
        {
            foreach (KeyCode pInput in values)
            {
                if (Input.GetKey(pInput))
                {
                    PlayerInput = pInput;
                    if (PlayerInput != KeyCode.Mouse0)
                    {
                        A2string = PlayerInput.ToString();
                        if (A2string.Length <= 5)
                        {
                            A2text.fontSize = 60;
                        }
                        else if (A2string.Length > 5 && A2string.Length <= 9)

                        {
                            A2text.fontSize = 40;
                        }
                        else
                        {
                            A2text.fontSize = 38;
                        }
                        A2text.text = A2string;
                        Debug.Log(pInput);
                        AttackPl2.isOn = false;
                        Pl2AttackInput = PlayerInput;
                    }
                }
            }
        }
        if (BlockPl2.isOn == true)
        {
            foreach (KeyCode pInput in values)
            {
                if (Input.GetKey(pInput))
                {
                    PlayerInput = pInput;
                    if (PlayerInput != KeyCode.Mouse0)
                    {
                        BL2string = PlayerInput.ToString();
                        if (BL2string.Length <= 5)
                        {
                            BL2text.fontSize = 60;
                        }
                        else if (BL2string.Length > 5 && BL2string.Length <= 9)

                        {
                            BL2text.fontSize = 40;
                        }
                        else
                        {
                            BL2text.fontSize = 38;
                        }
                        BL2text.text = BL2string;
                        Debug.Log(pInput);
                        BlockPl2.isOn = false;
                        Pl2BlockInput = PlayerInput;
                    }
                }
            }
        }



    }

    void ToggleChange(Toggle change, Toggle[] alltoggles)
    {
        Debug.Log("toggle was toggled");
        for (int i = 0; i < alltoggles.Length; i++)
        {
            if (alltoggles[i] != change)
            {
                alltoggles[i].isOn = false;
            }
        }
        if (change.isOn == true)
        {
            change.image.color = Color.cyan;
        }
        else
        {
            change.image.color = Color.white;
        }
    }

    public void LeavingControls()
    {
        GlobalController.Instance.jump1 = Pl1JumpInput;
        GlobalController.Instance.left1 = Pl1BackInput;
        GlobalController.Instance.right1 = Pl1ForwardInput;
        GlobalController.Instance.attack1 = PL1AttackInput;
        GlobalController.Instance.block1 = Pl1BlockInput;
        GlobalController.Instance.jump2 = Pl2JumpInput;
        GlobalController.Instance.left2 = Pl2BackInput;
        GlobalController.Instance.right2 = Pl2ForwardInput;
        GlobalController.Instance.attack2 = Pl2AttackInput;
        GlobalController.Instance.block2 = Pl2BlockInput;

    }



}
