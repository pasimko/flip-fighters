using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D head, body;
    public Transform leftLeg, rightLeg, rightToe, leftToe;

    bool isGrounded = false;
    public LayerMask groundLayer; // The map - Layer for checking collisions with any of the map

    void Update()
    {
        isGrounded = (Physics2D.OverlapCircle(leftToe.position, 0.2f, groundLayer) || Physics2D.OverlapCircle(rightToe.position, 0.2f, groundLayer));
        standUp();
    }

    void standUp()
    {
        if (isGrounded)
        {
            head.AddForce(new Vector2(0, 30));
            float restoringTorque = -getTorque()*250;
            body.AddTorque(restoringTorque);
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
        //Debug.Log(springTorque);
        return springTorque;
    }

}