using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grabController : MonoBehaviour
{
    public Transform grabPoint;
    public Transform rayPoint;
    public float rayDistance;
    private GameObject grabbedObject;
    private int layerIndex;
    public float throwForce;


    // Start is called before the first frame update
    void Start()
    {
        layerIndex = LayerMask.NameToLayer("Ball");
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(rayPoint.position, transform.right, rayDistance);


        if (hitInfo.collider != null && hitInfo.collider.gameObject.layer == layerIndex)
        {
            if (grabbedObject == null)
            {
                // pick up the ball
                grabbedObject = hitInfo.collider.gameObject;
                grabbedObject.GetComponent<Rigidbody2D>().isKinematic = true;
                grabbedObject.transform.position = grabPoint.position;
                grabbedObject.transform.SetParent(transform);

            }
            else if (Input.GetKey(KeyCode.Space))
            {
                Debug.Log("Pressed");
                // release the ball
                grabbedObject.GetComponent<Rigidbody2D>().isKinematic = false;
                grabbedObject.transform.SetParent(null);
                grabbedObject.GetComponent<Rigidbody2D>().velocity = new Vector2(transform.localScale.x, 1) * throwForce;
                grabbedObject = null;
            }

        }
    }
}
