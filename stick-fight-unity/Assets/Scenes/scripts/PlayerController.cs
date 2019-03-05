using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D head;
    public Transform leftLeg, rightLeg;
    bool isGrounded = false;

    // Start is called before the first frame update
    void Start()
    {

    }
   
    public LayerMask groundLayer; // Insert the layer here.

    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(leftLeg.position, 0.3f, groundLayer); // checks if you are within 0.15 position in the Y of the ground
        Debug.Log(isGrounded);
    }
   
}