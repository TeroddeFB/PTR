using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class Texto : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public TextMeshProUGUI tmpText;  // El TMP que cambiará de texto
    public string hoverText = "Mouse está sobre mí";  // Texto cuando el mouse está encima
    private string originalText;  // Texto original
    // Start is called before the first frame update
    void Start()
    {
        originalText = tmpText.text;

    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        tmpText.text = hoverText;
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        tmpText.text = originalText;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
