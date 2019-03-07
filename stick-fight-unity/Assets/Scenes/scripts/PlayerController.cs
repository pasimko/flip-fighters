using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D head, torso;
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
        standUp();
    }

    void standUp()
    {
        if (isGrounded)
        {
            float restoringTorque = getTorque()/25;
            head.AddForce(new Vector2(0, 40));
            torso.AddTorque(restoringTorque);
        }

    }
    float getTorque()
    {
        float restoringTorque = torso.transform.rotation.eulerAngles.z;
        Debug.Log(restoringTorque);
        float restoringTorqueVel = torso.angularVelocity;

        /*torque = spring coeff * dist from desired angle * axis of rot
         *      + damping coeff * dist from desired angvel * axis of rot
         */
        float springTorque = 0.5f * restoringTorque + 0.1f * restoringTorqueVel;
        //Debug.Log(springTorque);
        return springTorque;
    }

}