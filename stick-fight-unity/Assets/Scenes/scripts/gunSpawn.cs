using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunSpawn : MonoBehaviour
{
    private float nextActionTime = 0.0f;
    public float period = 0.1f;
    public GameObject auto;

    void Start()
    {

    }
    void Update()
    {
        if (Time.time > nextActionTime)
        {
            nextActionTime += period;
            Instantiate(auto, transform.position, transform.rotation);
        }


    }
}
