using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D body;
    public new Collider2D collider;

    [Range(1, 5)]
    public float walkSpeed;
    [Range(1, 3)]
    public float runMultiplier;
    [Range(1, 10)]
    public float jumpForce;

    private bool isGrounded;
    private float walkForce;

    void Awake()
    {
        body = gameObject.GetComponent<Rigidbody2D>();
        collider = gameObject.GetComponent<CapsuleCollider2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Floor")
            isGrounded = true;
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Floor")
            isGrounded = false;
    }

    // Update is called once per frame
    void Update()
    {
        walkForce = walkSpeed * Input.GetAxisRaw("Horizontal");
    }

    void FixedUpdate()
    {
        // Walk & Run
        if (Input.GetButton("Sprint"))
            body.AddForce(new Vector2(walkForce * runMultiplier, 0), ForceMode2D.Impulse);
        else
            body.AddForce(new Vector2(walkForce, 0), ForceMode2D.Impulse);

        // Jump
        if (Input.GetButton("Jump") && isGrounded)
            body.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
    }
}
