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
            
        }
        else if (Rana.Instance.ubiJug.x > 66f)
        {
            winTexto.enabled = true;
            Rana.Instance.vivo = false;
            Rana.Instance.playerAnim.SetBool("Corre", false);
            Rana.Instance.rb.velocity = new Vector2(0, Rana.Instance.rb.velocity.y);
            
        }
    }

}