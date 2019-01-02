using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSmash : MonoBehaviour {

    public GameObject theCollidedFloor;
    private GameObject theDJObject;
    private GameObject gameController;
    private HoldBoundary _holdBoundary;
    private DJ theDJ;
    private Rigidbody playerRidgid;

    public float speed;
    private float moveHorizontal;
    private float moveVerticle;

    private FloorFlash nextTargetedFloorFlash;

    public GameObject hitGroundEffect;

    Vector3 force;
    void Start () {
        theDJObject = GameObject.FindGameObjectWithTag("DJ");
        gameController = GameObject.FindGameObjectWithTag("GameController");
        _holdBoundary = gameController.GetComponent<HoldBoundary>();
        theDJ = theDJObject.GetComponent<DJ>();
        playerRidgid = GetComponent<Rigidbody>();
        force = new Vector3(0, 0, 0);
    }
	
	// Update is called once per frame
	void Update () {
        
        
    










        if (Input.GetButtonDown("Jump"))
        {
            try
            {
                Physics.IgnoreCollision(theCollidedFloor.GetComponent<Collider>(), GetComponent<Collider>(), true);
                //Destroy(theCollidedFloor);
            }
            catch
            {
                Debug.Log("目前抓不到thecolliderFloor");
            }

            /*
            for (int i = 0; i < 3; i++)
            {
                playerRidgid.MovePosition(playerRidgid.transform.position += new Vector3( 0, - 1, 0));
            }
            */
            try
            {
                if (theDJ.nowTargetFloor != null)
                {

                    playerRidgid.MovePosition(new Vector3(transform.position.x, theDJ.nowTargetFloor.transform.position.y - 0.01f, transform.position.z));

                    //PlayerRush(theDJ.nowTargetFloor.transform.position.y);
                    nextTargetedFloorFlash = theDJ.nowTargetFloor.GetComponent<FloorFlash>();
                    nextTargetedFloorFlash.iftouched = 1;
                }
            }
            catch
            {
                Debug.Log("你死了");

            }

        }
        else {
            moveHorizontal = Input.GetAxis("Horizontal");
            force = new Vector3(moveHorizontal, 0, 0);
            
            if (transform.position.x + (force.x * speed) < _holdBoundary.rightBoundary && transform.position.x + (force.x * speed) > _holdBoundary.leftBoundary)
            {

                
                transform.position += force * speed;
                

                //transform.position += new Vector3(transform.position.x + 0.01f, 0, 0);

            }
            
            /*
            playerRidgid.position = new Vector3(Mathf.Clamp(playerRidgid.position.x, _holdBoundary.leftBoundary, _holdBoundary.rightBoundary)
            ,transform.position.y
            ,transform.position.z
            );*/
        }
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            theCollidedFloor = collision.gameObject;
          
            Instantiate(hitGroundEffect, transform.position, transform.rotation);

            theDJ.ScoreChange(1);
        }



    }

    private void PlayerRush(float targetFloorY)
    {


    }


}
