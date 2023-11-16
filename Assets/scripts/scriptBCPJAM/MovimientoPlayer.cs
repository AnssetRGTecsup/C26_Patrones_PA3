using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoPlayer : MonoBehaviour
{
    public playerBarrera barrera;
    public float velocidad;
    //public float direccion;
    public Rigidbody2D rb;
    public float fuerza;
    public bool dobleSalto=true;

    private Animator animator;
    private SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        /*direccion = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(direccion * velocidad, rb.velocity.y);


        if (Input.GetKeyDown("w"))
        {
            if (dobleSalto)
            {
                rb.AddForce(Vector2.up * fuerza, ForceMode2D.Impulse);
                dobleSalto = false;
            }
        }*/
        if (Time.timeScale == 1f)
        {
            CuysitoMove();
        }
    }
    private void CuysitoMove()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey("left"))
        {
            spriteRenderer.flipX = true;
            rb.velocity = new Vector2(-velocidad, rb.velocity.y);
            animator.SetBool("Run", true);
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey("right"))
        {
            spriteRenderer.flipX = false;
            rb.velocity = new Vector2(velocidad, rb.velocity.y);
            animator.SetBool("Run", true);
        }
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
            animator.SetBool("Run", false);
        }
        if (Input.GetKeyDown(KeyCode.W) && dobleSalto == true || Input.GetKeyDown("space") && dobleSalto == true)
        {
            rb.velocity = Vector3.zero;
            barrera.audioSource.clip = barrera.salto;
            barrera.audioSource.Play();
            rb.AddForce(Vector2.up * fuerza, ForceMode2D.Impulse);
            dobleSalto = false;
           // dobleSalto = false;
            animator.SetBool("Run", true);
        }
        if (dobleSalto == false)
        {
            animator.SetBool("Jump", true);
            animator.SetBool("Run", true);
        }
        else if (dobleSalto == true)
        {
            animator.SetBool("Jump", false);
        }
    }
    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "piso")
        {
            dobleSalto = true;
        }
    }*/
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "piso")
        {
            dobleSalto = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "piso")
        {
            dobleSalto = false;
        }
    }


}
