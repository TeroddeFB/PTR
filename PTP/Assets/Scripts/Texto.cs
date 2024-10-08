using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class Texto : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private TextMeshProUGUI tmpText;  // El TMP que cambiar� de texto
    // private string hoverText;  // Texto cuando el mouse est� encima
    // private string originalText;  // Texto original
    // Start is called before the first frame update
    void Start()
    {
        tmpText = GetComponent<TextMeshProUGUI>();
        // originalText = tmpText.text;
        // hoverText = "-" + originalText;
    }
    public void OnPointerEnter(PointerEventData eventData)
    {

        // tmpText.text = hoverText;
        tmpText.color = Color.yellow;
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        // tmpText.text = originalText;
        tmpText.color = Color.white;
    }


}