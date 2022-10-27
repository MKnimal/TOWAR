using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    [SerializeField] private float vida;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void TomarDaño(float dañoGolpe)
    {
        vida -= dañoGolpe;

        if(vida <= 0){
            Muerte();
        }
    }

    private void Muerte(){
        Destroy(gameObject);
    }
}
