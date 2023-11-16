using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Jump validation")]
    [SerializeField] private LayerMask groundLayers;
    [SerializeField] private float raycastLength;

    [Header("Movement parameters")]
    [SerializeField] private float velocidad;
    [SerializeField] private float fuerza;
    [SerializeField] private Rigidbody2D rb;

    [Header("Visual components")]
    [SerializeField] private Animator animator;
    [SerializeField] private SpriteRenderer spriteRenderer;

    [Header("Other Components")]
    [SerializeField] private int dashPrice;
    [SerializeField] private ManagerCoins coins;
    [SerializeField] private AudioClip coinSfx;
    [SerializeField] private AudioClip dashSfx;
    [SerializeField] private AudioSource sfxPlayer;

    private float _horizontalMovement;
    private bool _isGrounded = true;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (Time.timeScale == 0) return;

        RaycastHit2D raycastHit2D = Physics2D.Raycast(transform.position, Vector2.down, raycastLength, groundLayers);

        if(raycastHit2D)
        {
            _isGrounded = true;
        }
        else
        {
            _isGrounded = false;
        }

        PowerDash();
        PlayerMove();
    }

    private void PlayerMove()
    {
        _horizontalMovement = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(_horizontalMovement, rb.velocity.y);

        spriteRenderer.flipX = rb.velocity.x > 0;

        animator.SetBool("Run", rb.velocity.magnitude > 0);

        if (Input.GetButtonDown("Jump") && _isGrounded == true)
        {
            rb.AddForce(Vector2.up * fuerza, ForceMode2D.Impulse);
            _isGrounded = false;
        }

        animator.SetBool("Jump", _isGrounded);
    }

    private void PowerDash()
    {
        if (Input.GetButtonDown("Power"))
        {
            if (coins.PayCoins(dashPrice))
            {
                sfxPlayer.PlayOneShot(dashSfx);
                rb.AddForce(Vector2.right * fuerza * _horizontalMovement, ForceMode2D.Impulse);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("coin"))
        {
            coins.AddCoins(+1);
            sfxPlayer.PlayOneShot(coinSfx);
        }
    }
}
