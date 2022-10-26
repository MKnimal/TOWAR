using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flyingEnemyIAInverted : MonoBehaviour
{
    private Rigidbody EnemigoRB;
    private GameObject Jugador;
    private SpriteRenderer eRender;
    private float speed = 15;
    private float post;
    private Vector3 normalRotation;
    private Vector3 inverseRotation;
    
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Inicializando Enemigo volador");
        eRender = GetComponent<SpriteRenderer>();
        EnemigoRB = GetComponent<Rigidbody>();
        normalRotation = new Vector3(0, 180, 0);
        inverseRotation = new Vector3(0, 0, 0);
        Jugador = GameObject.Find("Player");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        post = (Jugador.transform.position - transform.position).normalized.x;
        EnemigoRB.AddForce((Jugador.transform.position - transform.position).normalized * speed);
        if (post != 0f){
                            if(post < 0){
                                transform.eulerAngles = normalRotation;
                            }
                            if(post > 0){
                                transform.eulerAngles = inverseRotation;
                            }
                        }
    }
}
