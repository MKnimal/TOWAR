using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Este es un código fallido jaja lo siento
public class ActivarPlataforma : MonoBehaviour
{
    public float limiteizqx = 30.05433f;
    public float limitederx = 60f;
    public float velocidad = 4;
    public bool activar = false;
    private GameObject plataforma;
    public Vector3 izq = Vector3.left;
    public Vector3 der = Vector3.right;

    void Start()
    {

        plataforma = GameObject.Find("Movimiento2");
    }

    
    void Update()
    {
        if (activar)
        {
            plataforma.transform.Translate(izq * Time.deltaTime * velocidad);
            if (transform.position.x == limiteizqx)
            {
                plataforma.transform.Translate(der * Time.deltaTime * velocidad);
                if (transform.position.x == limitederx)
                {
                    plataforma.transform.Translate(izq * Time.deltaTime * velocidad);
                }
                activar = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Hammer"))
        {
            activar = true;
        }
    }
}
