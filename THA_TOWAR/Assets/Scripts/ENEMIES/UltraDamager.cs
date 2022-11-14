using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UltraDamager : MonoBehaviour
{
    private float damage = 15;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<HP>().TomarDaño(damage);
        }
    }
}
