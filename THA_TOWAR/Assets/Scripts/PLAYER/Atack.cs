using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atack : MonoBehaviour
{
    [SerializeField] private Transform ControladorAtaque;
    [SerializeField] private float radioGolpe;
    [SerializeField] LayerMask enemyLayers;
    [SerializeField] private float dañoGolpe;
    [SerializeField] private AudioSource rAudioSource;
    private Color gizColor = Color.yellow;
    private Animator animator;

    private void Start(){
        animator = GetComponent<Animator>();
    }

    private void Update(){
        if (Input.GetButtonDown("Fire1"))
        {
            rAudioSource.Play();
            animator.SetTrigger("Att");
            gizColor = Color.red;
        }

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = gizColor;
        //Gizmos.DrawWireSphere(ControladorAtaque.position, radioGolpe);
    }
}
