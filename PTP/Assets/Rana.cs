using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rana : MonoBehaviour
{
    private Rigidbody2D rb;
    public bool isGrounded = true;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal") * 5f;
        rb.velocity = new Vector2(horizontalInput, rb.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector2.up * 6f, ForceMode2D.Impulse);
            isGrounded = false;

        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Piso")) 
        {
            isGrounded = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Verifica si el objeto que entra al trigger tiene la etiqueta "Player"
        if (collision.CompareTag("Cabeza"))
        {
            // Destruye el objeto que ha activado el trigger
            Destroy(collision.transform.parent.gameObject);
        }
    }
}
