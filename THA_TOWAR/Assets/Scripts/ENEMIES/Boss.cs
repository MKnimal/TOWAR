using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading.Tasks;

public class Boss : MonoBehaviour
{
    private Rigidbody EnemigoRB;
    private GameObject Jugador;
    private Animator eAnimator;
    private float post;
    private float distancia;
    private bool Soundflag = true;
    [SerializeField] private bool Activo = false;
    [SerializeField] private float Aggro = 10.0f;
    [SerializeField] private AudioSource rMusic;
    [SerializeField] private AudioSource rAudio;
    [SerializeField] private int Delay = 500;
    [SerializeField] private GameObject[] EnemyObject;
    [SerializeField] private float startAtack = 2f;
    [SerializeField] private float intervalAtack = 1.5f;
    [SerializeField] private float[] ejeX = new float[2] {0, 0};
    [SerializeField] private float[] ejeY = new float[2] {0, 0};
    [SerializeField] private float ejeZ = 0;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Inicializando Jefe");
        eAnimator = GetComponent<Animator>();
        EnemigoRB = GetComponent<Rigidbody>();
        Jugador = GameObject.Find("Player");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        post = (Jugador.transform.position - transform.position).normalized.x;
        distancia = Vector3.Distance(Jugador.transform.position, transform.position);

        if (distancia < Aggro){
            Activo = true;
        }

        if (Activo == true){
                eAnimator.SetTrigger("Boot");
                if (Soundflag == true)
                { 
                Soundflag = false;
                asyncEvents();  
                }
        }

    }

    async void asyncEvents(){
        await Task.Delay(Delay);
        if (!rMusic.isPlaying)
        { 
        rAudio.Play(); 
        await Task.Delay(1000);
        rMusic.Play();
        }
        InvokeRepeating("randomAtack", startAtack, intervalAtack);
    }

    void randomAtack(){
        int random = Random.Range(1, 3);
        Debug.Log(random);
        if (random == 1){
            spAtack1();
        }else
        {
            spAtack2();
        }
    }

    void spAtack1(){
        eAnimator.SetTrigger("at1");
    }

    void spAtack2(){
        eAnimator.SetTrigger("at2");

        Vector3 posicion = new Vector3(Random.Range(ejeX[0], ejeX[1]), Random.Range(ejeY[0], ejeY[1]), ejeZ);    
        //Necesita 2 parametros, desde que numero y hasta que numero X, Y, Z
        int index = Random.Range(0, EnemyObject.Length);
        //Necesita que le mandes un parametro con que va a instanciar, la posicion y la direccion
        Instantiate(EnemyObject[index], posicion, EnemyObject[index].transform.rotation);
    }
}
