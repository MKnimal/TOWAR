using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemigopru : MonoBehaviour
{
    private Rigidbody EnemigoRB;
    private GameObject Jugador;
    private float speed = 3;
    // Start is called before the first frame update
    void Start()
    {

        EnemigoRB = GetComponent<Rigidbody>();
        Jugador = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        EnemigoRB.AddForce((Jugador.transform.position - transform.position).normalized * speed);
    }
}
