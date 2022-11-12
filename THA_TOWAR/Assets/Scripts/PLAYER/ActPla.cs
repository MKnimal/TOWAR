using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ActPla : MonoBehaviour
{
    public bool Mover = false;
    //Con las variable de velocidad se le asigna desde el Unity cuánto va a ser su nivel
    //Mientras que con Puntoini se establece que sea cero para que pueda trasladarse
    //En el arreglo de puntos se le asigna cuáles serán los puntos a donde se va a trasladar
    [SerializeField] float velocidad;
    [SerializeField] int Puntoini;
    [SerializeField] Transform[] puntos;
    private GameObject plataforma;
    public TextMeshProUGUI texto;

    int i;
    bool reversa;
    // Start is called before the first frame update
    void Start()
    {
        //Se encuentra el GameObject del objeto el cual tenga por su nombre Plata Mov2
        plataforma = GameObject.Find("Plata Mov2");
        //Se establece que el punto inicial de la plataforma sea el que tenga asignado la variable puntos
        plataforma.transform.position = puntos[Puntoini].position;
        i = Puntoini;
    }

    // Update is called once per frame
    void Update()
    {

        
        if (Mover)
        {
            //Con este if se asigna cada cuanto se va a mover la plataforma y hacia qué dirección
            plataforma.transform.position = Vector3.MoveTowards(plataforma.transform.position, puntos[i].position, velocidad * Time.deltaTime);
            if (Vector3.Distance(plataforma.transform.position, puntos[i].position) < 0.01f)
            {

                if (i == puntos.Length - 1)
                {
                    reversa = true;
                    i--;
                    return;
                }
                else if (i == 0)
                {
                    reversa = true;
                    i++;
                    return;
                }
                if (reversa)
                {
                    i--;
                }
                else
                {
                    i++;
                }
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        //Con este if se establece que cuando el collider del Gameobject (El cual es un objeto vacio dentro de Unity)
        //se tope con un objeto el cual su Tag se llame Player mostrará un texto
            if (other.tag == "Player")
            {
                texto.gameObject.SetActive(true);
            }
        //En cuanto el jugador haga el ataque y el objeto con el Tag Hammer haga contacto con el collider del Gameobject
        //la acción de Mover sera verdadera para que la plataforma se mueva
        //mientras que al mismo tiempo el texto que se mostró con anterioridad se desactivará
        if (other.gameObject.CompareTag("Hammer"))
        {
            Mover = true;
            texto.gameObject.SetActive(false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //Cuando el jugador no esté haciendo contacto con el Collider del Gameobject, el texto no se mostrará
        if (other.tag == "Player")
        {
            texto.gameObject.SetActive(false);
        }
    }
}
