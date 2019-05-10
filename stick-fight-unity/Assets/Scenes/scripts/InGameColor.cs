using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameColor : MonoBehaviour
{
    public GameObject head1, body1, rightarm1, leftarm1, rightleg1, leftleg1;
    public GameObject head2, body2, rightarm2, leftarm2, rightleg2, leftleg2;

     public void Start()
    {
        GameObject[] player1 = new GameObject[] { head1, body1, rightarm1, leftarm1, rightleg1, leftleg1 };
        GameObject[] player2 = new GameObject[] { head2, body2, rightarm2, leftarm2, rightleg2, leftleg2 };
        for (int i = 0; i < player1.Length; i++)
        {
            Debug.Log("Coloring Character");
            player1[i].GetComponent<SpriteRenderer>().color = GlobalController.Instance.player1Color;
        }
        for (int i = 0; i < player2.Length; i++)
        {
            player2[i].GetComponent<SpriteRenderer>().color = GlobalController.Instance.player2Color;
        }
    }
}
