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

    private MeshRenderer meshRenderer;

    public float immortalTime;
    private float setImmortalTime;
    private AudioSource audiosource;
    void Start () {
        setImmortalTime = immortalTime;
        meshRenderer = GetComponent<MeshRenderer>();
        theDJObject = GameObject.FindGameObjectWithTag("DJ");
        gameController = GameObject.FindGameObjectWithTag("GameController");
        _holdBoundary = gameController.GetComponent<HoldBoundary>();
        theDJ = theDJObject.GetComponent<DJ>();
        playerRidgid = GetComponent<Rigidbody>();
        force = new Vector3(0, 0, 0);
        audiosource = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
       // Debug.Log(DJ.floorExist);
        //測試閃動

        immortalTime -= Time.deltaTime;
        /*if (theDJ.nowTargetFloor == null && Input.GetButtonDown("Jump"))
        {
            PlayerNotOnTempo();

        }*/
        if (Input.GetButtonDown("Jump") && DJ.gameStart == true && theDJ.nowTargetFloor != null)
        {
            /*if (theDJ.nowTargetFloor == null)
            {
                playerGetHurt();
            }*/
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
                //Debug.Log("你死了");
                

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
        else if (collision.gameObject.tag == "Enemy")
        {
            theDJ.ScoreChange(-1);
        }



    }

    public void playerGetHurt()
    {
        immortalTime = setImmortalTime;
       CameraShake CameraShake = GameObject.FindGameObjectWithTag("Camera").GetComponent<CameraShake>();

        StartCoroutine(playerFlash());
        audiosource.Play();
        StartCoroutine(CameraShake.Shake(0.35f, 0.35f));
        
    }

    public void PlayerNotOnTempo()
    {
        CameraShake CameraShake = GameObject.FindGameObjectWithTag("Camera").GetComponent<CameraShake>();

        //StartCoroutine(playerFlash());
        audiosource.Play();
        StartCoroutine(CameraShake.Shake(0.35f, 0.35f));
        theDJ.ScoreChange(-1);
    }

    IEnumerator playerFlash()
    {
        for(int i = 0; i < 10; i++)
        {
            if (i % 2 == 0)
            {
                //meshRenderer.material.color = new Color(80, 178, 50, 1);
                meshRenderer.material.color = new Color(meshRenderer.material.color.a, meshRenderer.material.color.b, meshRenderer.material.color.maxColorComponent, 0);
                //Debug.Log("A");
            }
            else if (i % 2 == 1)
            {
                //meshRenderer.material.color = new Color(80, 178, 50, 1);
                meshRenderer.material.color = new Color(meshRenderer.material.color.a, meshRenderer.material.color.b, meshRenderer.material.color.maxColorComponent, 1);
                //Debug.Log("B");
            }
           // Debug.Log("閃了 " + i + " 次");
            yield return new WaitForSeconds(0.15f);    
        }
    }

}

