using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pl : MonoBehaviour
{
    public float acceleration = 15f;
    public float jumpForce = 20f;
    public bool jumpEnabled = true;
    private Rigidbody rPlayer;
    private float InputX;

    void Start()
    {
        Debug.Log("Inicializando");
        rPlayer = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //**MOVIMIENTO LATERAL**
        //Obtenemos eje de movimiento
        InputX = Input.GetAxis("Horizontal");
        /*Generamos el Movimiento multiplicando el vector horizontal normalizado * la aceleracion
          y el eje de movimiento (esto para determinar la direccion)*/
        transform.Translate(Vector3.right * Time.deltaTime * acceleration * InputX);

        //**MOVIMIENTO VERTICAL**
        //Verificamos si esta tocando el suelo y el boton esta presionado
        if (Input.GetButton("Jump") && jumpEnabled)
        {
            //Desactivamos el salto para que no lo haga de nuevo
            jumpEnabled = false;
            //Añadimos un vector vertical normalizado, multiplicado por la furza de salto
            rPlayer.AddForce((Vector3.up).normalized * jumpForce);
        }
    }

    //Detecta colisiones
    private void OnCollisionEnter(Collision collision)
    {
        /*En caso de colisionar con algun obajeto con el tag ground, le devuelve sus ((Derechos humanos)) 
          privilegios de salto y desactiva la animacion de salto*/
        if (collision.transform.tag == "ground")
        {
            jumpEnabled = true;
        }
        if (collision.transform.tag == "dead")
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "platamov")
        {
            transform.parent = collision.transform;
        }
    }

    //Sale de la colisión de plataforma
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "platamov")
        {
            transform.parent = null;
        }
    }
}
