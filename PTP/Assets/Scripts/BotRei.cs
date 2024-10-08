using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BotRei : Boton // INHERITANCE
{
    // Start is called before the first frame update

    protected override void Hacer() // POLYMORPHISM
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Update is called once per frame

}