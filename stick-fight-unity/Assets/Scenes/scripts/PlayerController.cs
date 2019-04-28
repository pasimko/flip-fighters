using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D head, body, leftLeg, rightLeg;
    public Transform rightToe, leftToe;

    public KeyCode right, left, jump, attack, block;

    public bool isGrounded = false;
    public bool isJumping = false;

    private float totalDegrees = 0;
    private Vector3 lastPoint;

    public LayerMask groundLayer; // The map - Layer for checking collisions with any of the map

    void Start()
    {
        lastPoint = transform.TransformDirection(Vector3.right);
        lastPoint.y = 0;
    }

    public void Initialize(Transform prefab, Vector3 location)
    {
        Instantiate(prefab, location, Quaternion.identity);
    }

    void Update()
    {
        isGrounded = (Physics2D.OverlapCircle(leftToe.position, 0.2f, groundLayer) || Physics2D.OverlapCircle(rightToe.position, 0.2f, groundLayer));
        standUp();
        HandleMovement();
        if (!isGrounded)
        {
            CountFlips();
            Debug.Log(nrOfRotations.ToString());
        }
        else
        {
            totalDegrees = 0;
        }     
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
    }

    public int nrOfRotations
    {
        get
        {
            return ((int)totalDegrees) / 360;
        }
    }

    void CountFlips()
    {
        Transform tempBody = body.GetComponent<Transform>();
        Vector3 facing = tempBody.TransformDirection(Vector3.right);
        facing.y = 0;

        float angle = Vector3.Angle(lastPoint, facing);
        if (Vector3.Cross(lastPoint, facing).y < 0)
            angle *= -1;

        totalDegrees += angle;
        lastPoint = facing;

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