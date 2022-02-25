using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float speed;
    public float jumpSpeed;
    private float input;

    [SerializeField] private LayerMask floorLayerMask;
    Rigidbody2D rb;
    Animator anim;
    BoxCollider2D boxCollider2D;
    
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        boxCollider2D = transform.GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        if (input != 0)
        {
            anim.SetBool("isRunning", true);
        } else
        {
            anim.SetBool("isRunning", false);
        }

        if (input > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        if (input < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        if (isGrounded() && Input.GetKey(KeyCode.Space))
        {
            rb.velocity = Vector2.up * jumpSpeed;
            anim.SetBool("isJumping", true);
        }
        else
        {
            anim.SetBool("isJumping", false);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        input = Input.GetAxisRaw("Horizontal");


        // Moving player
        rb.velocity = new Vector2(input * speed, rb.velocity.y);
    }

    private bool isGrounded()
    {
        RaycastHit2D raycastHit2D = Physics2D.BoxCast(boxCollider2D.bounds.center, boxCollider2D.bounds.size, 0f, Vector2.down, .1f, floorLayerMask);
        return raycastHit2D.collider != null;
    }
}
