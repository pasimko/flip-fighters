using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunSpawn : MonoBehaviour
{
    public GameObject longGun;
    
    void Start()
    {
        Instantiate(longGun, transform.position, transform.rotation);
    }

    
    void Update()
    {
        
    }
}
