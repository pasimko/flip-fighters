using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerColorController : MonoBehaviour
{
    public Color PL1color;
    public Color PL2color;


    public Button PL1ColorButton;
    public Button PL2ColorButton;

    

    void Start ()
    {
        PL1color = GlobalController.Instance.player1Color;
        PL2color = GlobalController.Instance.player2Color;
        PL1ColorButton.image.color = PL1color;
        PL2ColorButton.image.color = PL2color;
    }


    public void PL1ColorChange ()
    {
        if (PL1color == Color.white)
        {
            PL1color = Color.green;
        }
        else if (PL1color == Color.green)
        {
            PL1color = Color.red;
        }
        else if (PL1color == Color.red)
        {
            PL1color = Color.blue;
        }
        else if (PL1color == Color.blue)
        {
            PL1color = Color.black;
        }
        else if (PL1color == Color.black)
        {
            PL1color = Color.white;
        }
        PL1ColorButton.image.color = PL1color;
    }

    public void PL2ColorChange()
    {
        if (PL2color == Color.white)
        {
            PL2color = Color.green;
        }
        else if (PL2color == Color.green)
        {
            PL2color = Color.red;
        }
        else if (PL2color == Color.red)
        {
            PL2color = Color.blue;
        }
        else if (PL2color == Color.blue)
        {
            PL2color = Color.black;
        }
        else if (PL2color == Color.black)
        {
            PL2color = Color.white;
        }
        PL2ColorButton.image.color = PL2color;
    }

    public void LeavingSettings()
    {
        GlobalController.Instance.player1Color = PL1color;
        GlobalController.Instance.player2Color = PL2color;
    }


}
