using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class v2PController : MonoBehaviour
{
    public GameObject[] wayPoints;
    public float platFormSpeed = 2f;
    private int wayIndex = 0;

    // Update is called once per frame
    void Update()
    {
        MovePlatform();
    }

    private void MovePlatform()
    {
        //Verificamos la distancia entre el objeto y el limite, y si la distancia es menor a 0.1, se cumple
        if (Vector3.Distance(transform.position,wayPoints[wayIndex].transform.position) < 0.1f)
        {
            wayIndex++;

            //Asi nos aseguramos de que siempre tenga a donde ir
            if(wayIndex >= wayPoints.Length)
            {
                wayIndex = 0;
            }
        }

        //MOvemos el objeto con esto
        //Argumentos: 1. Posicion PLataforma | 2. Posicion Referencia | Velocidad
        transform.position = Vector3.MoveTowards(transform.position, wayPoints[wayIndex].transform.position, platFormSpeed * Time.deltaTime);
    }
}
