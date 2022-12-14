using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoAnimationEnemy : MonoBehaviour
{
    [SerializeField] private float vida;
    [SerializeField] private float Defensa = 1;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    public void TomarDaño(float dañoGolpe)
    {
        vida = vida - dañoGolpe;
        if (vida <= 0){
            Invoke("Muerte", 0.5f);
        }
    }

    private void Muerte(){
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision) {
        Debug.Log("Enemigo: Hubo una colision [" + collision.transform.tag + "]");
        if (collision.transform.tag == "Weapon")
        {
            TomarDaño(Defensa);
        }
    }
}
