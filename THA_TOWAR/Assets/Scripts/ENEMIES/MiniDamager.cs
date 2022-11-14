using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniDamager : MonoBehaviour
{
    private float damage = 1;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<HP>().TomarDaño(damage);
        }
    }
}
