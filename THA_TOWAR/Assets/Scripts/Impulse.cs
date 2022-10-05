using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Impulse : MonoBehaviour
{
    public float velocidad = 20;
    private int limiteX = 50;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * Time.deltaTime * velocidad);

        if(transform.position.x > limiteX){
            Destroy(gameObject);
        }
        if(transform.position.x < -limiteX){
            Destroy(gameObject);
        }
    }

    /*
    private void OnTriggerEnter(Collider other){
        Destroy(gameObject);
        Destroy(other.gameObject);
    }*/
}
