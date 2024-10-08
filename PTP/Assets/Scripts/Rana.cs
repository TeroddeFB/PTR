using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rana : MonoBehaviour
{
    public Rigidbody2D rb;
    public bool isGrounded = true;
    public float horizontalInput;
    public Animator playerAnim;
    public bool tocPared;
    public static Rana Instance;
    public Vector3 ubiJug;
    public GameObject onCollectEffect;
    private Animator enemigoAnimator;
    private Enemigo enem;
    private BoxCollider2D enemBox;
    private GameObject malvado;
    public bool vivo = true;


    void Start()
    {
        Instance = this;

        rb = GetComponent<Rigidbody2D>();
        playerAnim = GetComponent<Animator>();


    }

    void Update()
    {
        ubiJug = transform.position;
        horizontalInput = Input.GetAxisRaw("Horizontal") * 5f;

        // Movimiento horizontal si el jugador está vivo
        if (vivo)
        {
            rb.velocity = new Vector2(horizontalInput, rb.velocity.y);
        }

        // Verificar si el jugador ha caído por debajo del límite
        if (transform.position.y < -9)
        {
            vivo = false;
            Destroy(gameObject);
        }

        // Evaluar acciones basadas en el input del jugador
        int action = 0;

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            action = 1; // Saltar
        }
        else if (horizontalInput != 0 && vivo)
        {
            action = 2; // Correr
        }
        else if (horizontalInput == 0)
        {
            action = 3; // No está corriendo
        }

        // Usar switch para manejar las acciones
        switch (action)
        {
            case 1:
                Saltar();
                break;

            case 2:
                Correr();
                break;

            case 3:
                playerAnim.SetBool("Corre", false);
                break;

            default:
                // No hacer nada por defecto
                break;
        }


    }
    private void Saltar()
    {
        playerAnim.SetTrigger("Salta");
        playerAnim.SetBool("Saltando", true);
        rb.AddForce(Vector2.up * 6f, ForceMode2D.Impulse);
        isGrounded = false;
    }
    private void Correr()
    {
        playerAnim.SetBool("Corre", true);
        if (horizontalInput > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (horizontalInput < 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Piso"))
        {
            isGrounded = true;
            playerAnim.SetBool("Saltando", false);
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Verifica si el objeto que entra al trigger tiene la etiqueta "Player"
        if (collision.gameObject.CompareTag("Cabeza"))
        {
            
            malvado = collision.transform.parent.gameObject;
            enemigoAnimator = collision.transform.parent.gameObject.GetComponent<Animator>();           
            enem = collision.transform.parent.gameObject.GetComponent<Enemigo>();
            enemBox = collision.transform.parent.gameObject.GetComponent<BoxCollider2D>();
            Matar();
            StartCoroutine(Moricion());


            rb.AddForce(Vector2.up * 6f, ForceMode2D.Impulse);
        }
        else if (collision.gameObject.CompareTag("Piso"))
        {
            isGrounded = true;
            playerAnim.SetBool("Saltando", false);
        }
        else if (collision.gameObject.CompareTag("Cereza"))
        {
            Instantiate(onCollectEffect, collision.gameObject.transform.position, transform.rotation);
            Destroy(collision.gameObject);


        }

    }
    private void Matar()
    {
        enemigoAnimator.SetBool("Muerto", true);
        enem.puedeMatar = false;
        enemBox.enabled = false;
    }
    IEnumerator Moricion()
    {
        yield return new WaitForSeconds(4.0f);
        Destroy(malvado);
    }



}