using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class Boss : MonoBehaviour
{
    private Rigidbody EnemigoRB;
    private GameObject Jugador;
    private Animator eAnimator;
    private float post;
    private float distancia;
    private bool Soundflag = true;
    [SerializeField] private bool Activo = false;
    [SerializeField] private float Aggro = 10.0f;
    [SerializeField] private AudioSource rMusic;
    [SerializeField] private AudioSource rAudio;
    [SerializeField] private int Delay = 500;

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
            Debug.Log("Jefe activado");
        }

        if (Activo == true){
                eAnimator.SetTrigger("Boot");
                if (Soundflag == true)
                { 
                Soundflag = false;
                music();  
                }
        }

    }

    async void music(){
        await Task.Delay(Delay);
        if (!rMusic.isPlaying)
        { 
        rAudio.Play(); 
        await Task.Delay(1000);
        rMusic.Play();}
    }
}
