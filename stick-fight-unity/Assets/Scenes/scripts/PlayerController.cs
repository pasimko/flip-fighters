using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D head;
    public Transform leftLeg, rightLeg;
    bool isGrounded;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (isGrounded)
        {
            head.AddForce(new Vector2(0, 40));
            Debug.Log(1);
        }
        head.AddForce(new Vector2(0, 40));
    }

    void GroundCheck()
    {
        RaycastHit hit;
        float distance = 1f;
        Vector3 dir = new Vector3(0, -1);

        if (Physics.Raycast(leftLeg.position, dir, out hit, distance))
        {
            isGrounded = true;
        }
        else if (Physics.Raycast(rightLeg.position, dir, out hit, distance))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
    }
}
