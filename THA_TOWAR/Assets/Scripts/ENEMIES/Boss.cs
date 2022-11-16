using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    private Rigidbody EnemigoRB;
    private GameObject Jugador;
    private Animator eAnimator;
    private float post;
    private float distancia;
    [SerializeField] private bool Activo = false;
    [SerializeField] private float Aggro = 10.0f;
    [SerializeField] private AudioSource rMusic;
    [SerializeField] private AudioSource rAudio;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Inicializando Jefe");
        eAnimator = GetComponent<Animator>();
        EnemigoRB = GetComponent<Rigidbody>();
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
            Debug.Log("Jefe activado");
            if (!rMusic.isPlaying)
            { rMusic.Play(); }
        }

    }
}
