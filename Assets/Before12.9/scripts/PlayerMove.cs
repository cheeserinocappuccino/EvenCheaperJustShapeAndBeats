using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

    public float speed;
    private Rigidbody playerRigidbody;
    private float moveHorizontal;
    Vector3 force;
    // Use this for initialization
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        //Physics.IgnoreLayerCollision(0, 0);
        force = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (transform.position.x < 15 && transform.position.x > -15)
        {
            moveHorizontal = Input.GetAxis("Horizontal");
            force = new Vector3(moveHorizontal, 0, 0);


        }
        /*
        moveHorizontal = Input.GetAxis("Horizontal");
        Vector3 force = new Vector3(moveHorizontal, 0, 0);
        */


        transform.position += force * speed;
    }
}
