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
    private SpriteRenderer rRender;

    void Start()
    {
        Debug.Log("Inicializando");
        rPlayer = GetComponent<Rigidbody>();
        rAnimator = GetComponent<Animator>();
        rRender = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //**MOVIMIENTO LATERAL**
        //Obtenemos eje de movimiento
        float vert = Input.GetAxis("Horizontal");
        /*Generamos el Movimiento multiplicando el vector horizontal normalizado * la aceleracion
          y el eje de movimiento (esto para determinar la direccion)*/
        rPlayer.AddForce((Vector3.right).normalized * acceleration * vert);

                        //**ANIMACION**
                        //Verificamos si existe una direccion, en caso de que si, activamos el animador
                        if (vert != 0f){
                            if(vert < 0){
                                rRender.flipX = true;
                                rAnimator.SetBool("Moving", true);
                            }
                            if(vert > 0){
                                rRender.flipX = false;
                                rAnimator.SetBool("Moving", true);
                            }
                        }else{
                            rAnimator.SetBool("Moving", false);
                        }

        //**MOVIMIENTO VERTICAL**
        //Verificamos si esta tocando el suelo y el boton esta presionado
        if (Input.GetButton("Jump") && jumpEnabled){
            //Desactivamos el salto para que no lo haga de nuevo
            jumpEnabled = false;
            //Añadimos un vector vertical normalizado, multiplicado por la furza de salto
            rPlayer.AddForce((Vector3.up).normalized * jumpForce);

                        //**ANIMACION**
                        //Activamos la animacion de salto
                        rAnimator.SetBool("Jumping", true);
        }
    }

    //Detecta colisiones
    private void OnCollisionEnter(Collision collision) {
        /*En caso de colisionar con algun obajeto con el tag ground, le devuelve sus ((Derechos humanos)) 
          privilegios de salto y desactiva la animacion de salto*/
        if (collision.transform.tag == "ground"){
            jumpEnabled = true;
            rAnimator.SetBool("Jumping", false);
        }
        if (collision.transform.tag == "dead")
        {
            Destroy(gameObject);
        }
    }
}
