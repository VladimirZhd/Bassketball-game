using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hoop : MonoBehaviour
{
    Rigidbody2D ball;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "ball")
        {
            ball = collider.gameObject.GetComponent<Rigidbody2D>();
            Destroy(ball);   
        }
    }
}
