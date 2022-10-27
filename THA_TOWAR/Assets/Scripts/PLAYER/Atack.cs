using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atack : MonoBehaviour
{
    [SerializeField] private Transform ControladorAtaque;

    [SerializeField] private float radioGolpe;

    [SerializeField] LayerMask enemyLayers;

    [SerializeField] private float dañoGolpe;

    private Color gizColor = Color.yellow;

    private Animator animator;

    private void Start(){
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate(){
        if (Input.GetButtonDown("Fire1"))
        {
            Hit();
        }

    }

    private void Hit(){
        animator.SetTrigger("Att");
        gizColor = Color.red;

        //Collider[] objetos = Physics.OverlapSphere(ControladorAtaque.position, radioGolpe, enemyLayers);
        /*
        foreach (Collider colisionador in objetos)
        {
                Debug.Log("Golpeaste a: " + colisionador.name);
                 colisionador.transform.GetComponent<Enemigo>().TomarDaño(dañoGolpe);
        }*/
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = gizColor;
        //Gizmos.DrawWireSphere(ControladorAtaque.position, radioGolpe);
    }
}
