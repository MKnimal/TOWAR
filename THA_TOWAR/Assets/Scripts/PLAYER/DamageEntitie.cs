using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageEntitie : MonoBehaviour
{
    [SerializeField] private float dañoGolpe;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision) 
    {
        Debug.Log("Hizo colision");
        if (collision.transform.tag == "Enemy"){
            Debug.Log("Toco un enemigo");
            collision.transform.GetComponent<Enemigo>().TomarDaño(dañoGolpe);
        }
    }
}
