using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

    public float forceMultiply;
    private Rigidbody playerRigidbody;
    private float moveHorizontal;
    // Use this for initialization
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        Physics.IgnoreLayerCollision(0, 0);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        moveHorizontal = Input.GetAxis("Horizontal");
        Vector3 force = new Vector3(moveHorizontal, 0, 0);

        playerRigidbody.AddForce(force * forceMultiply);
    }
}
