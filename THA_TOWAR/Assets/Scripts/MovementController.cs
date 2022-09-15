using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    //Crea el objeto rigidbody
    private new Rigidbody rigidbody;
    //Variable de velocidad
    public float speed = 850f;
    public float true_speed = 850f;
    bool canJump;
    public float jump_speed = 50f;
    public float jump_movement_speed = 50f;

    void Start()
    {
        Debug.Log("Inicializando");
        //Guarda el objeto Rigidbody en una variable
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //Obtenemos el parametro de las teclas "A", "D", "<-" y "->"
        float hor = Input.GetAxisRaw("Horizontal");
        //Verificamos que no este vacio
        if (hor != 0.0f)
        {
            //Obtenemos la direccion del vector
            int direction = Direction(hor);
            //añadimos un vector tridimencional a nuestro rigidbody para generar movimiento
            rigidbody.AddForce(new Vector3(0, 0, (direction * speed) * Time.deltaTime));
        }
        //Salto
        if(Input.GetKeyDown("up") && canJump){
                Debug.Log("salto");
                canJump = false;
                speed = jump_movement_speed;
                rigidbody.AddForce(new Vector3(0, jump_speed, 0));
        }

    }

    //Determinamos la direccion en la que ira el personaje
    private int Direction(float hor)
    {
        if (hor < 0){/*Izquierda*/return 1;}
        else{/*Derecha*/return -1;}
    }

    private void OnCollisionEnter(Collision collision) {
        float hor = Input.GetAxisRaw("Horizontal");
        if (collision.transform.tag == "ground"){
                rigidbody.AddForce(new Vector3(0, 0, (hor * -11000) * Time.deltaTime));
                canJump = true; 
                Debug.Log("canjump:" + canJump);
                speed = true_speed;
        }
    }
}
