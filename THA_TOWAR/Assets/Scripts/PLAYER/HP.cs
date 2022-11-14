using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HP : MonoBehaviour
{
    //panel del GameOver
    public GameObject gameOver;
    //vida que tiene el jugador en cualquier momento
    private float vida;
    //vida con la que empezara  nuestro jugador
    [SerializeField] private float maximoVida;
    //controlar barra de vida 
    public Vida barradeVida;

    // Start is called before the first frame update
    void Start()
    {
        //inicializamos la vida 
        vida = maximoVida;
        barradeVida.IniciarBarraVida(vida);
    }

    //daño que recive el jugador 
    public void TomarDaño(float daño)
    {
        vida = vida - daño;
        barradeVida.CambiarVidaActual(vida);
        //si la vida llega a cero destruimos al jugador, detenemos el juego y se abre el panel del gameover
        if (vida <= 0)
        {
            Destroy(gameObject);
            Time.timeScale = 0f;
            gameOver.SetActive(true);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("dead"))
        {
            //si el jugador cae la vida llega a cero, destruimos al jugador, detenemos el juego y se abre el panel del gameover
            Destroy(gameObject);
            vida = 0;
            barradeVida.CambiarVidaActual(vida);
            Time.timeScale = 0f;
            gameOver.SetActive(true);

        }
    }
}
