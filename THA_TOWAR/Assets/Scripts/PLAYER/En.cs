using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class En : MonoBehaviour
{
    private Rigidbody EnemigoRB;
    private GameObject Player;
    private float speed = 1;
    // Start is called before the first frame update
    void Start()
    {
        EnemigoRB = GetComponent<Rigidbody>();
        Player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        EnemigoRB.AddForce((Player.transform.position - transform.position).normalized * speed);
        
    }
}
