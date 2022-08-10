using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D body;
    public SpriteRenderer sprite;
    public new Collider2D collider;
    public HealthBar healthBar;

    [Range(1, 5)]
    public float walkSpeed;
    [Range(1, 3)]
    public float runMultiplier;
    [Range(1, 10)]
    public float jumpForce;

    public int maxHealth = 15;
    public int currentHealth;

    private Animator animator;
    private bool isGrounded;
    private float walkForce;

    void Awake()
    {
        body = gameObject.GetComponent<Rigidbody2D>();
        collider = gameObject.GetComponent<CapsuleCollider2D>();
        animator = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            isGrounded = true;
            animator.SetBool("IsGrounded", true);
            animator.SetBool("IsFalling", false);
        }
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            isGrounded = false;
            animator.SetBool("IsGrounded", false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        walkForce = walkSpeed * Input.GetAxisRaw("Horizontal");

        if(Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(2);
        }
    }

    void FixedUpdate()
    {
        // FIX - Still moves after death
        if(animator.GetFloat("Health") < 0.1f)
        {   
            // Sprite direction
            if(walkForce < -0.1f)
                sprite.flipX = true;
            else if(walkForce > 0.1f)
                sprite.flipX = false;

            // Walk & Run
            if (Input.GetButton("Sprint"))
                body.AddForce(new Vector2(walkForce * runMultiplier, 0), ForceMode2D.Impulse);
            else
                body.AddForce(new Vector2(walkForce, 0), ForceMode2D.Impulse);

            // Jump
            if (Input.GetButton("Jump") && isGrounded)
                body.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);

            // Animations
            if(walkForce != 0.0f)
                animator.SetBool("IsMoving", true);
            else
                animator.SetBool("IsMoving", false);
        }   
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);

        animator.SetFloat("Health", currentHealth);
    }
}
