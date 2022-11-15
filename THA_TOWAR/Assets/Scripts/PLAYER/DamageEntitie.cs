using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageEntitie : MonoBehaviour
{
    [SerializeField] private float dañoGolpe;
    [SerializeField] private AudioSource rAudioSource1;
    [SerializeField] private AudioSource rAudioSource2;

    private void OnCollisionEnter(Collision collision) 
    {
        Debug.Log("Arma: Hizo colision");
        if (collision.transform.tag == "Enemy"){
            Debug.Log("Arma: Toco un enemigo");
            rAudioSource1.Play();
            collision.transform.GetComponent<Enemigo>().TomarDaño(dañoGolpe);
        }else{
            rAudioSource2.Play();
        }
    }
}
