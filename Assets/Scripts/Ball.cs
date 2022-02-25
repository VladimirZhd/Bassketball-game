using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float pushForce;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void onCollisionEnter2D(Collision2D other) 
    {
        System.Console.WriteLine("I'm here");
        Debug.Log(other);
        if (other.gameObject.tag == "WallRight")
        {
            Debug.Log("push left");
            rb.AddForce(Vector2.left * pushForce, ForceMode2D.Impulse);
        }
        else if (other.gameObject.tag == "WallLeft")
        {
            Debug.Log("push right");
            rb.AddForce(Vector2.right * pushForce, ForceMode2D.Impulse);
        }
    }
}
