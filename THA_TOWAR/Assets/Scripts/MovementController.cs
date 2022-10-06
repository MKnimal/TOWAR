using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    //Crea el objeto rigidbody
    //private new Rigidbody rigidbody;

    //Variable de velocidad
    public float varSpeed = 850f;
    public float trueSpeed = 850f;
    bool canJump;
    public float jumpSpeed = 1000f;
    public float jumpMovSpeed = 500f;

    void Start()
    {
        Debug.Log("Inicializando");
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Translate(Vector3.left * Time.deltaTime * velocidad);
        //Obtenemos el parametro de las teclas "A", "D", "<-" y "->"
        float varInput = Input.GetAxisRaw("Horizontal");
            //añadimos un vector tridimencional a nuestro rigidbody para generar movimiento
            GetComponent<Rigidbody>().AddForce(new Vector3((varInput * varSpeed) * Time.deltaTime, 0, 0));
        //Salto
        if(Input.GetButtonDown("Jump") && canJump){
                Debug.Log("Salto");
                canJump = false;
                varSpeed = jumpMovSpeed;
                GetComponent<Rigidbody>().AddForce(new Vector3(0, (jumpSpeed * Time.deltaTime), 0));
        }

    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.transform.tag == "ground"){
                canJump = true; 
                Debug.Log("canjump:" + canJump);
                varSpeed = trueSpeed;
        }
    }
}
