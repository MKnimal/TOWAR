using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalDamager : MonoBehaviour
{
    private float damage = 5;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<HP>().TomarDaño(damage);
        }
    }
}
