using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BotVolver : Boton
{
    protected override void Hacer()
    {
        SceneManager.LoadScene(0);
    }
}