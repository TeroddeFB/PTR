using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BotVolver : Boton // INHERITANCE
{
    protected override void Hacer() // POLYMORPHISM
    {
        SceneManager.LoadScene(0);
    }
}