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
    public float jumpSpeed = 500f;
    public float jumpMovSpeed = 500f;

    void Start()
    {
        Debug.Log("Inicializando");
    }

    // Update is called once per frame
    void Update()
    {
        float varSalto;
        //Obtenemos el parametro de las teclas "A", "D", "<-" y "->"
        float varInput = Input.GetAxisRaw("Horizontal");
        varSalto = Input.GetAxisRaw("Vertical");
            //Obtenemos la direccion del vector
            int direction = Direction(varInput);
            //añadimos un vector tridimencional a nuestro rigidbody para generar movimiento
            GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, (direction * varSpeed) * Time.deltaTime));
        //Salto
        if((varSalto > 0) && canJump){
                Debug.Log("Salto" + varSalto);
                canJump = false;
                varSpeed = jumpMovSpeed;
                GetComponent<Rigidbody>().AddForce(new Vector3(0, (jumpSpeed * varSalto), 0));
        }

    }

    //Determinamos la direccion en la que ira el personaje
    private int Direction(float hor)
    {
        if (hor < 0){
            //Izquierda
            return 1;
        }
        else{
            if (hor == 0){
                //Neutral
                return 0;
            }
            else{
                //Derecha
                return -1;
            }
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
