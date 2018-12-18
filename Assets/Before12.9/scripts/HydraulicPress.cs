using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HydraulicPress : MonoBehaviour {

    private Rigidbody hydraulicRigidbody;
    private Vector3 movement;
    public float speed;

    private PlayerBehave playerBehave;
	// Use this for initialization
	void Start () {
        hydraulicRigidbody = GetComponent<Rigidbody>();
        movement = new Vector3(0, -1, 0) * speed;
        Physics.IgnoreLayerCollision(9, 8);
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        hydraulicRigidbody.MovePosition(transform.position + movement);
        
	}
    

    //  角色死亡
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerBehave = other.gameObject.GetComponent<PlayerBehave>();
            playerBehave.Damaged(100);
            Debug.Log("dasdasd");
            

        }
        Debug.Log("PlayerDead");
    }

}

