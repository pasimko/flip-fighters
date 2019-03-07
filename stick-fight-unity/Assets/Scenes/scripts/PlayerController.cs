using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D head;
    public Transform leftLeg, rightLeg, rightToe, leftToe;
    bool isGrounded = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }
   
    public LayerMask groundLayer; // Insert the layer here.

    void Update()
    {
        isGrounded = (Physics2D.OverlapCircle(leftToe.position, 0.2f, groundLayer) || Physics2D.OverlapCircle(rightToe.position, 0.2f, groundLayer));
        Debug.Log(isGrounded);
        if (isGrounded) {
            head.AddForce(new Vector2(0, 40));
        }
    }
   
}