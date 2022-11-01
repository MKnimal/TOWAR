using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttom : MonoBehaviour
{
    private Animator animator;

    private void Start(){
        animator = GetComponent<Animator>();
    }

    private void OnCollisionEnter(Collision collision) {
        Debug.Log("Hubo una colision" + collision.transform.tag);
        if (collision.transform.tag == "Hammer")
        {
            animator.SetTrigger("Push");
        }
    }
}
