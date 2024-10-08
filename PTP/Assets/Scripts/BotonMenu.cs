using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BotonMenu : Boton // INHERITANCE
{
    public int escena;
    protected override void Hacer() // POLYMORPHISM
    {
        SceneManager.LoadScene(escena);
    }
}