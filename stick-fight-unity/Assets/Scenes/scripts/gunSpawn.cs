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
        //Time that this object was instantiated
        fakeTime = Time.time;
        nextActionTime = 15f;
        period = 15f;
    }
    void Update()
    {
        //Spawn a gun once the count has reached, then increment the waiting period
        if (Time.time - fakeTime > nextActionTime)
        {
            nextActionTime += period;
            Instantiate(auto, transform.position, transform.rotation);
        }


    }
}
