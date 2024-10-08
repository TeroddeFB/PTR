using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    public TextMeshProUGUI gameOver;
    public RectTransform uiElemento;
    public TextMeshProUGUI reiTexto;
    public TextMeshProUGUI winTexto;
    void Start()
    {
        gameOver.enabled = false;
        winTexto.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Rana.Instance == null)
        {
            gameOver.enabled = true;
            CentrarEnCanvas();
        }
        else if (Rana.Instance.ubiJug.x > 66f)
        {
            winTexto.enabled = true;
            CentrarEnCanvas();
        }
    }
    public void CentrarEnCanvas()
    {
        if (uiElemento != null)
        {
            uiElemento.offsetMin = new Vector2(790f, 560f); // left y bottom
            uiElemento.offsetMax = new Vector2(-760f, -485f); // right y top
            uiElemento.anchoredPosition = Vector2.zero;
            reiTexto.alignment = TextAlignmentOptions.Center;
            if (Rana.Instance != null)
            {
                Rana.Instance.vivo = false;
                Rana.Instance.playerAnim.SetBool("Corre", false);
                Rana.Instance.rb.velocity = new Vector2(0, 0);
            }

        }
    }
}