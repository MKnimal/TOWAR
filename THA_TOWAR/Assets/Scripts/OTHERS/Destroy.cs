using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
private void OnCollisionEnter(Collision collision) {
        if (collision.transform.tag == "dead")
        {
            Destroy(gameObject);
        }
    }
}
