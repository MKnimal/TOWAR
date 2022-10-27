using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atack : MonoBehaviour
{
    [SerializeField] private Transform ControladorAtaque;

    [SerializeField] private float radioGolpe;

    [SerializeField] private float dañoGolpe;

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

        Collider[] objetos = Physics.OverlapSphere(ControladorAtaque.position, radioGolpe);

        foreach (Collider colisionador in objetos)
        {
            if (colisionador.CompareTag("Enemy"))
            {
                colisionador.transform.GetComponent<Enemigo>().TomarDaño(dañoGolpe);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(ControladorAtaque.position, radioGolpe);
    }
}
