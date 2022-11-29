using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntiDamager : MonoBehaviour
{
    private float damage = -20;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<HP>().TomarDaño(damage);
        }
    }
}
