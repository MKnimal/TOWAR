using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    void Start()    {    }
    void Update()    {    }

    public void funclick(){
        Debug.Log("Eureka");
        Destroy(gameObject);
    }
}
