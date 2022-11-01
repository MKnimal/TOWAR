using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pr : MonoBehaviour
{
    public GameObject Mover;
    public Transform puntoinicio;
    public Transform puntofinal;
    public float velocidad;
    private Vector3 Moverhacia;

    // Start is called before the first frame update
    void Start()
    {
        Moverhacia = puntofinal.position;
    }

    // Update is called once per frame
    void Update()
    {
        Mover.transform.position = Vector3.MoveTowards(Mover.transform.position, Moverhacia, velocidad * Time.deltaTime);
        if (Mover.transform.position == puntofinal.position)
        {
            Moverhacia = puntoinicio.position;
        }
        if (Mover.transform.position == puntoinicio.position)
        {
            Moverhacia = puntofinal.position;
        }
    }
}
