using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunSpawn : MonoBehaviour
{
    private float nextActionTime = 0.0f;
    public float period = 0.1f;
    public GameObject auto;
    float fakeTime;

    void Start()
    {
        fakeTime = Time.time;
        nextActionTime = 0f;
        period = 15f;
    }
    void Update()
    {
        if (Time.time - fakeTime > nextActionTime)
        {
            nextActionTime += period;
            Instantiate(auto, transform.position, transform.rotation);
        }


    }
}
