using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class At : MonoBehaviour
{
    [SerializeField] private Transform ControladorAtaque;

    [SerializeField] private float radioGolpe;

    [SerializeField] LayerMask enemyLayers;

    [SerializeField] private float dañoGolpe;

    private Color gizColor = Color.yellow;

    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        if (Input.GetButtonDown("Fire1"))
        {
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
