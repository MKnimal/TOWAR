using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemigopru : MonoBehaviour
{
    private Rigidbody EnemigoRB;
    private GameObject Jugador;
    private Animator eAnimator;
    private SpriteRenderer eRender;
    private float speed = 15;
    private float post;
    private Vector3 normalRotation;
    private Vector3 inverseRotation;
    private float distancia;
    public bool Activo = false;
    public float Aggro = 10.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Inicializando Enemigo");
        eAnimator = GetComponent<Animator>();
        eRender = GetComponent<SpriteRenderer>();
        EnemigoRB = GetComponent<Rigidbody>();
        normalRotation = new Vector3(0, 0, 0);
        inverseRotation = new Vector3(0, 180, 0);
        Jugador = GameObject.Find("Player");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        post = (Jugador.transform.position - transform.position).normalized.x;
        distancia = Vector3.Distance(Jugador.transform.position, transform.position);

        if (distancia < Aggro){
            Activo = true;
        }

        if (Activo == true){
            EnemigoRB.AddForce((Vector3.right).normalized * speed * post);
            if (post != 0f){
                                if(post < 0){
                                    transform.eulerAngles = normalRotation;
                                    eAnimator.SetBool("Moving", true);
                                }
                                if(post > 0){
                                    transform.eulerAngles = inverseRotation;
                                    eAnimator.SetBool("Moving", true);
                                }
                            }else{
                                eAnimator.SetBool("Moving", false);
                            }
        }

    }
}
