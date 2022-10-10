using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    public GameObject[] enemigos;
    public float inicio = 2f;
    public float interval = 1.5f;
    public Text texto;
    // Start is called before the first frame update
    void Start()
    {
        texto = GameObject.Find("Text").GetComponent<Text>();
        texto.text = "Initializasing...";
        InvokeRepeating("Generate", inicio, interval);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void Generate(){
            Vector3 posicion = new Vector3(Random.Range(0, 20), Random.Range(1, 5), -34f);    
            //Necesita 2 parametros, desde que numero y hasta que numero X, Y, Z
            int index = Random.Range(0, enemigos.Length);
            //Necesita que le mandes un parametro con que va a instanciar, la posicion y la direccion
            Instantiate(enemigos[index], posicion, enemigos[index].transform.rotation);
    }
}
