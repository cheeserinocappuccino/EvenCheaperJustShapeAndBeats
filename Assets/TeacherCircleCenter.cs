using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeacherCircleCenter : MonoBehaviour {

    private GameObject[] childBalls;
    private LineRenderer[] lineRenderer;
    private Vector3[] theDirection;
    private Ray[] laserColliderRays;
    RaycastHit[] hits;
    public  bool activate;

    private int playerMask;

    public Transform center;

    public GameObject theColliderObject;
    void Start () {
        activate = false;
        childBalls = new GameObject[transform.childCount];
        lineRenderer = new LineRenderer[transform.childCount];
        theDirection = new Vector3[transform.childCount];
        laserColliderRays = new Ray[transform.childCount];
        hits = new RaycastHit[transform.childCount];
        playerMask = LayerMask.GetMask("Player");
    }
	
	// Update is called once per frame
	void Update () {

        if (activate == true)
        {
            theColliderObject.SetActive(true);

           
        }
        else if(activate == false)
        {
            theColliderObject.SetActive(false);
        }


        if (Input.GetKeyDown(KeyCode.J))
        {
            if (activate == false)
            {
                activate = true;
            }
            else
            {
                activate = false;
            }
        }
	}
}
