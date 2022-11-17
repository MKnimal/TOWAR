using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicTool : MonoBehaviour
{
    [SerializeField] private AudioSource rAudioSource1;
    private GameObject Jugador;
    private float distancia;
    [SerializeField] private float Aggro = 10.0f;
    // Start is called before the first frame update
    void Start()
    {
        rAudioSource1.Play();
        Jugador = GameObject.Find("Player");
    }

    void FixedUpdate()
    {
        distancia = Vector3.Distance(Jugador.transform.position, transform.position);

        if (distancia < Aggro){
            if (rAudioSource1.isPlaying)
            { rAudioSource1.Stop(); }
        }

        if (distancia > Aggro){
            if (!rAudioSource1.isPlaying)
            { rAudioSource1.Play(); }
        }
    }
}
