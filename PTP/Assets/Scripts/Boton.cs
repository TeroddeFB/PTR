using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public abstract class Boton : MonoBehaviour
{
    protected Button button;

    public TextMeshProUGUI tmpText;  // El TMP que cambiar� de texto
    public string hoverText;  // Texto cuando el mouse est� encima
    public string originalText;  // Texto original

    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(Hacer);
    }

    protected abstract void Hacer();
}