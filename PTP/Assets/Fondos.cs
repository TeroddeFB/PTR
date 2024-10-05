using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fondos : MonoBehaviour
{
    public GameObject jugador;
    public float enex = 9.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (jugador.gameObject.transform.position.x > enex)
        {
            enex += 9.0f;
            Debug.Log("Hola");
            transform.position = new Vector3(transform.position.x + 22.79f, transform.position.y, transform.position.z);
        }
    }
}
