using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    public float acceleration = 15;
    private Rigidbody rPlayer;

    void Start()
    {
        Debug.Log("Inicializando");
        rPlayer = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
       float vert = Input.GetAxis("Horizontal");
       rPlayer.AddForce((Vector3.right).normalized * acceleration * vert);

    }
}
