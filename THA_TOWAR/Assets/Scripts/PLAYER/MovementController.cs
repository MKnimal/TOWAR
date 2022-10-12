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
    private Animator rAnimator;

    void Start()
    {
        Debug.Log("Inicializando");
        rPlayer = GetComponent<Rigidbody>();
        rAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float vert = Input.GetAxis("Horizontal");
        rPlayer.AddForce((Vector3.right).normalized * acceleration * vert);
        if (vert != 0f){
            if(vert < 0){rAnimator.SetBool("Moving", true);}
            if(vert > 0){rAnimator.SetBool("Moving", true);}
        }else{
            rAnimator.SetBool("Moving", false);
        }

        if (Input.GetButton("Jump") && jumpEnabled){
            jumpEnabled = false;
            rPlayer.AddForce((Vector3.up).normalized * jumpForce);
            if(vert < 0){rAnimator.SetBool("Jumping", true);}
            if(vert > 0){rAnimator.SetBool("Jumping", true);}
        }else{
            rAnimator.SetBool("Jumping", false);
        }
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.transform.tag == "ground"){
            jumpEnabled = true;
        }
    }
}
