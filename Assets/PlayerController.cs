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
    private float lastYPos;

    void Awake()
    {
        body = gameObject.GetComponent<Rigidbody2D>();
        collider = gameObject.GetComponent<CapsuleCollider2D>();
        animator = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        lastYPos = transform.position.y;
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
        if(animator.GetFloat("Health") > 0.1f)
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

            if (lastYPos > transform.position.y + 0.1f)
                animator.SetBool("IsFalling", true);
            else
                animator.SetBool("IsFalling", false);

            lastYPos = transform.position.y;
        }   
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);

        animator.SetFloat("Health", currentHealth);
    }
}
