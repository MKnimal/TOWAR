using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller_v2 : MonoBehaviour
{
    bool canJump;
    public float absolute_movement_value = 8000f;
    public float movement_value = 8000f;
    public float temp_movement_value = 3000f;
    public float jump_value = 3000f;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Inicializando");
    }

    // Update is called once per frame
    void Update()
    {
         //Movimiento
        if(Input.GetKey("left")){
                //movement
                gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2((-1 * movement_value) * Time.deltaTime, 0));
                //animacion movimiento
                //gameObject.GetComponent<Animator>().SetBool("moving", true);
        }
        if(Input.GetKey("right")){
                //movement
                gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(movement_value * Time.deltaTime, 0));
                //animacion movimiento
                //gameObject.GetComponent<Animator>().SetBool("moving", true);
        }

        //parar animacion movimiento
        if(!Input.GetKey("left") && !Input.GetKey("right")){
            //gameObject.GetComponent<Animator>().SetBool("moving", true);
        }

        //Salto
        if(Input.GetKeyDown("up") && canJump){
                canJump = false;
                movement_value = temp_movement_value;
                gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jump_value));
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.transform.tag == "ground"){
                canJump = true; 
                movement_value = absolute_movement_value;
        }
    }
}
