using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Parts of the prefab
    public Rigidbody2D head, body, leftLeg, rightLeg, leftArm, rightArm;
    public Transform rightToe, leftToe;

    // KeyCodes that when pressed will trigger this action
    public KeyCode right, left, jump, attack, block;

    public bool isGrounded = false;
    public bool isJumping = false;

    public Transform currentGun;

    public LayerMask groundLayer; // The map - Layer for checking collisions with any of the map

    private void Start()
    {
        Physics2D.IgnoreCollision(leftLeg.GetComponent<BoxCollider2D>(), leftArm.GetComponent<BoxCollider2D>());
        Physics2D.IgnoreCollision(rightLeg.GetComponent<BoxCollider2D>(), rightArm.GetComponent<BoxCollider2D>());
    }

    void Update()
    {
        isGrounded = (Physics2D.OverlapCircle(leftToe.position, 0.2f, groundLayer) || Physics2D.OverlapCircle(rightToe.position, 0.2f, groundLayer));
        standUp();
        HandleMovement();
    }

    void HandleMovement()
    {
        if (Input.GetKeyDown(jump) && isJumping == false)
        {
            head.AddForce(new Vector2(0, 2500));
            isJumping = true;
        }
        if (Input.GetKeyDown(left))
        {
            head.AddForce(new Vector2(-500, 0));
        }
        if (Input.GetKeyDown(right))
        {
            head.AddForce(new Vector2(500, 0));
        }
        if (Input.GetKeyDown(attack))
        {

        }
    }

    public void standUp()
    {
        if (isGrounded)
        {
            isJumping = false;
            head.AddForce(new Vector2(0, 90));
            rightLeg.AddForce(new Vector2(0, -40));
            leftLeg.AddForce(new Vector2(0, -40));
            body.AddTorque(-body.angularVelocity);
        }

    }
}