﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D head, body, leftLeg, rightLeg;
    public Transform rightToe, leftToe;

    public KeyCode right, left, jump, attack, block;

    private bool isGrounded = false;
    public LayerMask groundLayer; // The map - Layer for checking collisions with any of the map

    ControlsController controls;

    bool jumpPressed = false;

    void Update()
    {
        isGrounded = (Physics2D.OverlapCircle(leftToe.position, 8f, groundLayer) || Physics2D.OverlapCircle(rightToe.position, 8f, groundLayer));
        standUp();
        Debug.Log(isGrounded);
    }

    void standUp()
    {

        if (Input.GetKeyDown(jump) && isGrounded)
        {
            head.AddForce(new Vector2(0, 2500));
        }
        if (Input.GetKeyDown(left))
        {
            head.AddForce(new Vector2(-500, 0));
        }
        if (Input.GetKeyDown(right))
        {
            head.AddForce(new Vector2(500, 0));
        }
        if (isGrounded)
        {
            rightLeg.AddForce(new Vector2(0, -20));
            leftLeg.AddForce(new Vector2(0, -20));
            if (Mathf.Abs(body.transform.rotation.eulerAngles.z) > 30)
            {
                head.AddForce(new Vector2(0, 65-head.velocity.y));
                float restoringTorque = -getTorque()*250;
                body.AddTorque(restoringTorque);
                //The body's rotation will be slowed down scaled based on the magnitude of it's angular velocity 
                body.AddTorque(-body.angularVelocity);
            }
            else
            {
                head.AddForce(new Vector2(0, 90));
                //body.AddForce(new Vector2(0, 20));
            }
        }

    }
    float getTorque()
    {
        //Get the current rotation, and add a desired rotation to move to
        float restoringTorque = body.transform.rotation.eulerAngles.z;
        restoringTorque = Mathf.Sin(0.01745f*restoringTorque);
        float restoringTorqueVel = body.angularVelocity;
        restoringTorqueVel = Mathf.Sin(0.01745f * restoringTorqueVel);

        /*torque = spring coeff * dist from desired angle * axis of rot
         *      + damping coeff * dist from desired angvel * axis of rot
         */
        float springTorque = 1f * restoringTorque + 1f * restoringTorqueVel;
        Debug.Log(springTorque);
        //Debug.Log(springTorque);
        return springTorque;
    }

}