using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Centro : MonoBehaviour
{
    public float vel = 10f;
    // Start is called before the first frame update
    void Start()
    {    }

    // Update is called once per frame
    void Update()
    {
        float hor = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up * Time.deltaTime * vel * hor);
    }
}
