using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    public float acceleration = 15f;
    public float jumpForce = 20f;
    public bool jumpEnabled = true;
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

        if (Input.GetButton("Jump") && jumpEnabled){
            jumpEnabled = false;
            rPlayer.AddForce((Vector3.up).normalized * jumpForce);
        }
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.transform.tag == "ground"){
            jumpEnabled = true;
        }
    }
}
