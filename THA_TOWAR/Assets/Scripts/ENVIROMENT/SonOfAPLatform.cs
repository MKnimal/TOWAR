using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonOfAPLatform : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Plataforma: Colision Con el PLayer");
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.transform.SetParent(null);
        }
    }
}
