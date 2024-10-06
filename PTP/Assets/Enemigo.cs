using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    private Rigidbody2D rb;
    public float maximoEnemigo;
    public float minimoJugador;
    private Animator playerAnim;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerAnim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Rana.Instance.ubiJug.x > minimoJugador && transform.position.x > maximoEnemigo)
        {
            rb.velocity = new Vector2(-2, rb.velocity.y);
            playerAnim.SetBool("Corriendo", true);
        }
        else
        {
            playerAnim.SetBool("Corriendo", false);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(collision.gameObject);
        }

    }
}
