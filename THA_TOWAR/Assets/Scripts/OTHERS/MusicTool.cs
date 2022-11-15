using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicTool : MonoBehaviour
{
    [SerializeField] private AudioSource rAudioSource1;
    [SerializeField] private AudioSource rAudioSource2;
    private GameObject Jugador;
    private float distancia;
    [SerializeField] private bool Activo = false;
    [SerializeField] private float Aggro = 10.0f;
    // Start is called before the first frame update
    void Start()
    {
        rAudioSource1.Play();
        Jugador = GameObject.Find("Player");
    }

    private void OnCollisionEnter(Collision collision) 
    {
        Debug.Log("MusicBox: Hizo colision");
        if (collision.transform.tag == "Player"){
            rAudioSource1.Stop();
            rAudioSource2.Play();
        }
    }
}
