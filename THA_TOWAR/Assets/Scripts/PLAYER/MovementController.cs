using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    //Variables
    public float acceleration = 15f;
    public float jumpForce = 20f;
    public bool jumpEnabled = true;
    //Componentes 
    private Rigidbody rPlayer;
    private Animator rAnimator;
    private AudioSource rAudioSource;
    [SerializeField] private GameObject GamePlayer;
    [SerializeField] private Material material_a;
    [SerializeField] private Material material_b;
    //Vectores
    private Vector3 normalRotation;
    private Vector3 inverseRotation;

    void Start()
    {
        Debug.Log("Inicializando Player");
        rPlayer = GetComponent<Rigidbody>();
        rAnimator = GetComponent<Animator>();
        rAudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        normalRotation = new Vector3(0, 180, 0);
        inverseRotation = new Vector3(0, 0, 0);
        //**MOVIMIENTO LATERAL**
        //Obtenemos eje de movimiento
        float vert = Input.GetAxis("Horizontal");
        Render(vert);
        /*Generamos el Movimiento multiplicando el vector horizontal normalizado * la aceleracion
          y el eje de movimiento (esto para determinar la direccion)*/
        rPlayer.AddForce((Vector3.right).normalized * acceleration * vert);

        //**ANIMACION**
        //Verificamos si existe una direccion, en caso de que si, activamos el animador
        if (vert != 0f){
                            if(vert < 0){
                                transform.eulerAngles = normalRotation;
                                rAnimator.SetBool("Moving", true);
                                Audio();
                            }
                            if(vert > 0){ 
                                transform.eulerAngles = inverseRotation;
                                rAnimator.SetBool("Moving", true);
                                Audio();
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
    }

    private void Render(float ert)
    {
        if (ert < 0)
        {
            GamePlayer.GetComponent<SpriteRenderer>().material = material_b;
        }
        if (ert > 0)
        {
            GamePlayer.GetComponent<SpriteRenderer>().material = material_a;
        }
    }

    private void Audio(){
        if(!rAudioSource.isPlaying && jumpEnabled){
        rAudioSource.Play();
        }
    }
}
