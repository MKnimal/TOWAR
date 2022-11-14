using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Inicio : MonoBehaviour
{
    public void Iniciar()
    {
        SceneManager.LoadScene("Nivel_1");
    }

    public void salir()
    {
        Debug.Log("sliendo del juego....");
        Application.Quit();
    }
}
