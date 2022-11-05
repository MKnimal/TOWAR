using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plata : MonoBehaviour
{
    public GameObject MoverOb;
    public Transform Puntoini;
    public Transform Puntofin;
    public float velocidad;
    private Vector3 MoverHacia;
    // Start is called before the first frame update
    void Start()
    {
        //Movimiento inicial de la plataforma
        MoverHacia = Puntofin.position;
    }

    // Update is called once per frame
    void Update()
    {
        //Movimiento de la plataforma siguiendo el púnto inicial y el punto final desde objetos vacios creados en Unity
        MoverOb.transform.position = Vector3.MoveTowards(MoverOb.transform.position, MoverHacia, velocidad * Time.deltaTime);
        //Si la plataforma se encuentra en la posición del punto final se moverá al punto inicial
        if (MoverOb.transform.position == Puntofin.position)
        {
            MoverHacia = Puntoini.position;
        }
        //Si la plataforma se encuentra en la posición del punto inicial se moverá al punto final
        if (MoverOb.transform.position == Puntoini.position)
        {
            MoverHacia = Puntofin.position;
        }
    }
}
