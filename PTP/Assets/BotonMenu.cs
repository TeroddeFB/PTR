using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BotonMenu : Boton
{
    public int escena;
    // Start is called before the first frame update
    protected override void Hacer()
    {
        SceneManager.LoadScene(escena);
    }
}
