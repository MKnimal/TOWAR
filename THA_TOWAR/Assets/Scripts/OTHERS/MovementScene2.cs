using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScene2 : MonoBehaviour
{
    public float acceleration = 15;
    private Rigidbody rPlayer;
    private GameObject vCentro;

    void Start()
    {
        Debug.Log("Inicializando");
        rPlayer = GetComponent<Rigidbody>();
        vCentro = GameObject.Find("Centro");
    }

    // Update is called once per frame
    void Update()
    {
       float vert = Input.GetAxis("Mouse X");
       rPlayer.AddForce(vCentro.transform.forward * acceleration * vert);

    }
}
