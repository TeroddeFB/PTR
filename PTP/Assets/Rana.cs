using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rana : MonoBehaviour
{
    private Rigidbody2D rb;
    public bool isGrounded = true;
    public float horizontalInput;
    private Animator playerAnim;
    public bool tocPared;
    public static Rana Instance;
    public Vector3 ubiJug;

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
        rb.velocity = new Vector2(horizontalInput, rb.velocity.y);
        

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            playerAnim.SetTrigger("Salta");
            playerAnim.SetBool("Saltando", true);
            rb.AddForce(Vector2.up * 6f, ForceMode2D.Impulse);
            isGrounded = false;

        }
        else if (horizontalInput != 0)
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
        else if (horizontalInput == 0)
        {
            playerAnim.SetBool("Corre", false);

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
            // Destruye el objeto que ha activado el trigger
            Destroy(collision.transform.parent.gameObject);
            rb.AddForce(Vector2.up * 6f, ForceMode2D.Impulse);
        }
        else if (collision.gameObject.CompareTag("Piso"))
        {
            isGrounded = true;
            playerAnim.SetBool("Saltando", false);
        }
        else if (collision.gameObject.CompareTag("Cereza"))
        {
            Destroy(collision.gameObject);
        }

    }



}
